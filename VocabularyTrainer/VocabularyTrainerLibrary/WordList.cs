using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VocabularyTrainerLibrary
{
    public class WordList   //Endast private metoder som inte finns med i PDFen.
    {
        private static readonly char[] charSeparator = new char[] { ';' };

        private List<Word> words = new List<Word>();
        public WordList(string name, params string[] languages)
        {
            Name = name;
            Languages = languages;
        }

        public string Name { get; }

        public string[] Languages { get; }



        public static string[] GetLists()
        {
            Folder.CreateDirectory();

            var files = Directory.EnumerateFiles(Folder.FileDirectory)
                .Select(Path.GetFileNameWithoutExtension)
                .ToArray();
            return files;

        }

        public static WordList LoadList(string name) //Laddar in ordlistan (name anges utan filändelse) och returnerar som WordList. 
        {
            Folder.CreateDirectory();

            if (File.Exists(Folder.GetFilePath(name)) && new FileInfo(Folder.GetFilePath(name)).Length != 0)
            {
                using var streamReader = new StreamReader(Folder.GetFilePath(name));
                var languageArray = streamReader.ReadLine().Split(charSeparator, StringSplitOptions.RemoveEmptyEntries);
                var wordList = new WordList(name, languageArray);

                while (!streamReader.EndOfStream)
                {
                    wordList.Add(streamReader.ReadLine().Split(charSeparator, StringSplitOptions.RemoveEmptyEntries));
                }

                if (languageArray.Length != 0)
                {
                    return wordList;
                }
                else
                {
                    return null;
                }
            }

            return null;
        }

        public void Save() //Sparar listan till en fil med samma namn som listan och filändelse .dat
        {
            Folder.CreateDirectory();

            var filePath = Folder.GetFilePath(Name);

            using var streamWriter = new StreamWriter(filePath, false);

            for (int i = 0; i < Languages.Length; i++)
            {
                streamWriter.Write(i != Languages.Length - 1 ? $"{Languages[i]};" : $"{Languages[i]};{Environment.NewLine}");
            }

            foreach (var wordArray in words)
            {
                for (int i = 0; i < wordArray.Translations.Length; i++)
                {
                    streamWriter.Write(i != Languages.Length - 1 ? $"{wordArray.Translations[i]};" : $"{wordArray.Translations[i]};{Environment.NewLine}");
                }
            }

        }

        public void Add(params string[] translations) //Lägger till ord i listan. Kasta ArgumentException om det är fel antal translations. 
        {
            if (translations.Length == Languages.Length && !translations.Any(x => string.IsNullOrWhiteSpace(x)))
            {
                words.Add(new Word(translations));
            }
            else
            {
                throw new InvalidOperationException("\n-invalid amounts of translations\n");
            }
        }

        public bool Remove(int translation, string word) //translation motsvarar index i Languages. Sök igenom språket och ta bort ordet. 
        {
            if (words.Any(x => x.Translations[translation] == word)) //Checks the word objects in the List if argument is in Translation.
            {
                var wordObjectIndex = words.IndexOf(words.First(x => x.Translations[translation] == word)); //Returns index of the first word object found that matches the condition.
                words.RemoveAt(wordObjectIndex);

                Save();
                return true;
            }

            return false;
        }
        public int Count() //Räknar och returnerar antal ord i listan.
        {
            return words.Count();
        }

        public void List(int sortByTranslation, Action<string[]> showTranslations) //sortByTranslation = Vilket språk listan ska sorteras på.
        {                                                                         //showTranslations = Callback som anropas för varje ord i listan.
            {
                showTranslations(Languages);
                var sortedList = words.OrderBy(x => x.Translations[sortByTranslation]).ToArray();

                foreach (var word in sortedList)
                {
                    showTranslations(word.Translations);
                }
            }
        }


        public void List(Action<string[]> showTranslations)
        {
            showTranslations(Languages);

            foreach (var word in words)
            {
                showTranslations(word.Translations);
            }
        }
        public Word GetWordToPractice()
        {
            var random = new Random();
            var int1 = random.Next(Languages.Length);
            var int2 = random.Next(Languages.Length);
            var randomTranslations = words[random.Next(words.Count)].Translations;

            while (int1 == int2)
            {
                int1 = random.Next(Languages.Length);
            }

            return new Word(int1, int2, randomTranslations);
        }
    }
}
