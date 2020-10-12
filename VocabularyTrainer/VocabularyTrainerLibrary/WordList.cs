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

        public bool Remove(int translation, string word) //translation motsvarar index i Languages. Sök igenom språket och ta bort ordet. 
        {
            return false;
        }
        public int Count(string listName) //Räknar och returnerar antal ord i listan.
        {
            var counter = -1;

            if (File.Exists($"{Folder.FileDirectory}\\{listName}.dat"))
            {
                using var streamReader = new StreamReader($"{Folder.FileDirectory}\\{listName}.dat");

                while (streamReader.ReadLine() != null)
                {
                    counter++;
                }

                return counter;
            }
            else
            {
                return 0;
            }
        }

        public void List(int sortByTranslation)//, Action<string[]> showTranslations) //sortByTranslation = Vilket språk listan ska sorteras på.
        {                                                                         //showTranslations = Callback som anropas för varje ord i listan.
            using var streamReader = new StreamReader($"{Folder.FileDirectory}\\{Name}.dat");
            for (int i = 0; i < Languages.Length; i++)
            {
                //if (userInput == Languages[i])
                //{
                //    //sort by languages[i]
                //    //sortedArray = i.Sort(); där i är namnet på språket och vårt Word objekt
                //}
            }

            if (sortByTranslation != 0)
            {
                var i = 0;
                var wordArray = new Word[Count(Name)];
                var languages = streamReader.ReadLine().Split(charSeparator, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine();
                foreach (var language in languages)
                {
                    Console.Write(language.ToUpper().PadRight(10));
                }

                while (!streamReader.EndOfStream)
                {
                    Console.WriteLine();
                    var translations = streamReader.ReadLine().Split(charSeparator, StringSplitOptions.RemoveEmptyEntries);
                    var word = new Word(translations);
                    wordArray[i] = word;
                    i++;
                    foreach (var translation in word.Translations)
                    {
                        Console.Write(translation.PadRight(10));
                    }
                }
                Console.WriteLine("\n");

            }
        }

        public Word GetWordToPractice()  //Returnerar slumpmässigt Word från listan, med slumpmässigt valda 
        {                               // FromLanguage och ToLanguage (dock inte samma). 

            return null;
        }
    }
}
