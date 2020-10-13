using System;
using System.IO;
using System.Linq;

namespace VocabularyTrainerLibrary
{
    public class WordList
    {
        private static readonly char[] charSeparator = new char[] { ';' };

        public WordList(string name, params string[] languages)
        {
            Name = name;
            Languages = languages;
        }

        public string Name { get; }

        public string[] Languages { get; }


        public static string[] GetLists()
        {
            var fileArray = Directory.EnumerateFiles(Folder.FileDirectory).ToArray();
            var fileNames = new string[fileArray.Count()];

            for (int i = 0; i < fileNames.Length; i++)
            {
                fileNames[i] = Path.GetFileNameWithoutExtension(fileArray[i]);
            }

            return fileNames;
        }

        public static WordList LoadList(string name) //Laddar in ordlistan (name anges utan filändelse) och returnerar som WordList. 
        {

            if (File.Exists($"{Folder.FileDirectory}\\{name}.dat"))
            {
                using var streamReader = new StreamReader($"{Folder.FileDirectory}\\{name}.dat");

                if (!streamReader.EndOfStream)
                {
                    var languageArray = streamReader.ReadLine().Split(charSeparator, StringSplitOptions.RemoveEmptyEntries);

                    return new WordList(name, languageArray);
                }
            }

            return null;
        }

        public void Save(params Word[] word) //Sparar listan till en fil med samma namn som listan och filändelse .dat
        {
            var filePath = Path.Combine(Folder.FileDirectory, Name + ".dat");

            if (!File.Exists(filePath)) //Creates the file and saves the languages
            {
                using StreamWriter streamWriter = File.CreateText(filePath);
                for (int i = 0; i < Languages.Length; i++)
                {
                    streamWriter.Write($"{Languages[i]};");
                }
            }

            else if (File.Exists(filePath) && word.Length == 0 && new FileInfo(filePath).Length == 0) //If file exists and is empty; save the languages. 
            {
                using StreamWriter streamWriter = File.CreateText(filePath);

                for (int i = 0; i < Languages.Length; i++)
                {
                    streamWriter.Write($"{Languages[i]};");
                }
            }

            else if (File.Exists(filePath) && word.Length != 0) //Saves the words
            {
                using StreamWriter streamWriter = new StreamWriter(filePath, true);
                for (int i = 0; i < word[0].Translations.Length; i++)
                {
                    streamWriter.Write(i == 0 ? $"{Environment.NewLine}{word[0].Translations[i]};" : $"{word[0].Translations[i]};");
                }
            }
        }

        public void Add(params string[] translations) //Lägger till ord i listan. Kasta ArgumentException om det är fel antal translations. 
        { //Add argumentexception and refactor the shit out of this!!!!
            bool loop = true;
            var translatedWords = new string[Languages.Length];

            Console.WriteLine();
            Console.WriteLine("Press Enter (empty line) to stop input of new words.\n");
            Save();

            while (loop)
            {
                for (int i = 0; i < Languages.Length; i++)
                {
                    Console.Write(i == 0 ? $"Add a new word ({Languages[i]}): " : $"Add the {Languages[i]} translation: ");
                    string input = Console.ReadLine();
                    if (input != "")
                    {
                        translatedWords[i] = input;
                    }
                    else
                    {
                        loop = false;
                        break;
                    }
                }

                if (loop)
                {
                    var word = new Word(translatedWords);
                    Save(word);
                }
            }

        }

        public void Remove(int translation, string word) //translation motsvarar index i Languages. Sök igenom språket och ta bort ordet. 
        {
            var filePath = Folder.GetFilePath(Name);

            var languages = new string[Languages.Length];
            var wordsArray = ReturnWords(out languages);

            var newArray = wordsArray.Where(x => x.Translations.Contains(word)).ToArray();

            using StreamWriter streamWriter = new StreamWriter(filePath);
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

                var words = ReturnWords(out languages);


                showTranslations(languages);
                var sortedList = words.OrderBy(x => x.Translations[sortByTranslation]).ToArray();


                foreach (var word in sortedList)
                {
                    showTranslations(word.Translations);
                }
            }
        }

        //public void List(Action<string[]> showTranslations)
        //{
        //    var languages = new string[Languages.Length];
        //    var words = ReturnWords(out languages);

        //    showTranslations(languages);

        //    foreach (var translations in words)
        //    {
        //        showTranslations(translations.Translations);
        //    }
        //}

        public Word[] ReturnWords(out string[] languagesArray)
        {
            using var streamReader = new StreamReader($"{Folder.FileDirectory}\\{Name}.dat");
            var wordArray = new Word[Count(Name)];
            var translations = new string[Languages.Length];
            var languages = streamReader.ReadLine().ToUpper().Split(charSeparator, StringSplitOptions.RemoveEmptyEntries);

            while (!streamReader.EndOfStream)
            {
                for (int i = 0; i < Count(Name); i++)
                {
                    translations = streamReader.ReadLine().Split(charSeparator, StringSplitOptions.RemoveEmptyEntries);
                    wordArray[i] = new Word(translations);
                }
            }
            languagesArray = languages;
            return wordArray;
        }
        public Word GetWordToPractice()  //Returnerar slumpmässigt Word från listan, med slumpmässigt valda 
        {                               // FromLanguage och ToLanguage (dock inte samma). 

            return null;
        }
    }
}
