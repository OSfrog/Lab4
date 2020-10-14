using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VocabularyTrainerLibrary
{
    public class WordList   //Endast private metoder som inte finns med i PDFen.
    {
        private static readonly char[] charSeparator = new char[] { ';' };

        private List<Word> words = new List<Word>(); //Implementera i Save och Add.

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

                var fileArray = Directory.EnumerateFiles(Folder.FileDirectory).ToArray();
                var fileNames = new string[fileArray.Count()];

                for (int i = 0; i < fileNames.Length; i++)
                {
                    fileNames[i] = Path.GetFileNameWithoutExtension(fileArray[i]);
                }

                return fileNames;
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

                if (languageArray.Length != 0 && wordList.words.Count != 0)
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
                streamWriter.Write($"{Languages[i]};");
            }
            foreach (var wordArray in words)
            {
                for (int i = 0; i < wordArray.Translations.Length; i++)
                {
                    streamWriter.Write( i % Languages.Length == 0 ? $"{wordArray.Translations[i]};" : $"{wordArray.Translations[i]};{Environment.NewLine}");
                }
            }

        }

        public void Add(params string[] translations) //Lägger till ord i listan. Kasta ArgumentException om det är fel antal translations. 
        { //Add argumentexception and refactor the shit out of this!!!!
            if (translations.Length % Languages.Length == 0)
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
            var languages = new string[Languages.Length];

            using var streamReader = new StreamReader(Folder.GetFilePath(Name));

            languages = streamReader.ReadLine().Split(charSeparator, StringSplitOptions.RemoveEmptyEntries);

            while (!streamReader.EndOfStream)
            {
                words.Add(new Word(streamReader.ReadLine().Split(charSeparator, StringSplitOptions.RemoveEmptyEntries)));
            }

            streamReader.Close();

            var newArray = words.Where(x => x.Translations[translation] != word).ToArray();

            using StreamWriter streamWriter = new StreamWriter(Folder.GetFilePath(Name));
            for (int i = 0; i < Languages.Length; i++)
            {
                streamWriter.Write($"{languages[i]};");
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                for (int j = 0; j < newArray[i].Translations.Length; j++)
                {
                    streamWriter.Write(j == 0 ? $"{Environment.NewLine}{newArray[i].Translations[j]};" : $"{newArray[i].Translations[j]};");
                }
            }
        }
        public int Count(string listName) //Räknar och returnerar antal ord i listan.
        {
            var counter = -1;

            if (File.Exists(Folder.GetFilePath(listName)))
            {
                using var streamReader = new StreamReader(Folder.GetFilePath(listName));

                while (streamReader.ReadLine() != null)
                {
                    counter++;
                }

                return counter;
            }

            return 0;
        }

        public void List(int sortByTranslation, Action<string[]> showTranslations) //sortByTranslation = Vilket språk listan ska sorteras på.
        {                                                                         //showTranslations = Callback som anropas för varje ord i listan.
            {
                var languages = new string[Languages.Length];

                var words = ReturnWords();


                showTranslations(languages);
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
