using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
            if (Folder.AppDirectoryExists())
            {
                var files = Directory.EnumerateFiles(Folder.FileDirectory)
                    .Select(Path.GetFileNameWithoutExtension).ToArray();
                return files;
            }
            else
            {
                Folder.CreateDirectory();
                return null;
            }
        }

        public static WordList LoadList(string name) //Laddar in ordlistan (name anges utan filändelse) och returnerar som WordList. 
        {

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
            else
            {
                if (!Folder.AppDirectoryExists())
                    Folder.CreateDirectory();
            }
            return null;
        }

        public void Save() //Sparar listan till en fil med samma namn som listan och filändelse .dat
        {

            if (!Folder.AppDirectoryExists())
            {
                Folder.CreateDirectory();
            }
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
                    streamWriter.Write( i != Languages.Length - 1 ? $"{wordArray.Translations[i]};" : $"{wordArray.Translations[i]};{Environment.NewLine}");
                }
            }

        }

        public void Add(params string[] translations) //Lägger till ord i listan. Kasta ArgumentException om det är fel antal translations. 
        { //Add argumentexception and refactor the shit out of this!!!!
            if (translations.Length == Languages.Length)
            {
                words.Add(new Word(translations));
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void Remove(int translation, string word) //translation motsvarar index i Languages. Sök igenom språket och ta bort ordet. 
        {
            if (words.Where(x => x.Translations[translation] == word).Any()) //Checks the word objects in words List if word is in translation.
            {
                var wordObjectIndex = words.IndexOf(words.Where(x => x.Translations[translation] == word).First());
                words.RemoveAt(wordObjectIndex);
                Save();
            }
        }
        public int Count(string listName) //Räknar och returnerar antal ord i listan.
        {
            if (File.Exists(Folder.GetFilePath(listName)))
            {
                var list = LoadList(listName);
                return list.words.Count();
            }

            return -1;
        }

        public void List(int sortByTranslation, Action<string[]> showTranslations) //sortByTranslation = Vilket språk listan ska sorteras på.
        {                                                                         //showTranslations = Callback som anropas för varje ord i listan.
            {
                var words = ReturnWords();

                showTranslations(Languages);
                var sortedList = words.OrderBy(x => x.Translations[sortByTranslation]).ToArray();

                foreach (var word in sortedList)
                {
                    showTranslations(word.Translations);
                }
            }
        }


        public List<Word> ReturnWords()
        {
            var list = LoadList(Name);
            return list.words;
        }
        public Word GetWordToPractice()  //Returnerar slumpmässigt Word från listan, med slumpmässigt valda 
        {                               // FromLanguage och ToLanguage (dock inte samma). 

            return null;
        }
    }
}
