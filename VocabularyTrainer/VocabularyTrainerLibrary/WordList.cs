using System;
using System.IO;
using System.Linq;

namespace VocabularyTrainerLibrary
{
    public class WordList
    {
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

                var languageArray = streamReader.ReadLine().Split(';');

                return new WordList(name, languageArray);
            }

            return null;
        }

        public void Save(params Word[] word) //Sparar listan till en fil med samma namn som listan och filändelse .dat
        {
            if (File.Exists($"{Folder.FileDirectory}\\{Name}.dat") && word.Length != 0) //Saves the words
            {
                using StreamWriter sWriter = new StreamWriter($"{Folder.FileDirectory}\\{Name}.dat", true);
                for (int i = 0; i < word[0].Translations.Length; i++)
                {
                    sWriter.Write(i == 0 ? $"{Environment.NewLine}{word[0].Translations[i]};" : $"{word[0].Translations[i]};" );
                }
            }

            if(!File.Exists($"{Folder.FileDirectory}\\{Name}.dat")) //Saves the languages
            {
                using StreamWriter sWriter = File.CreateText($"{Folder.FileDirectory}\\{Name}.dat");
                for (int i = 0; i < Languages.Length; i++)
                {
                    sWriter.Write($"{Languages[i]};");
                }
            }

            //Logic for saving the words


        }

        public void Add(params string[] translations) //Lägger till ord i listan. Kasta ArgumentException om det är fel antal translations. 
        { //Add argumentexception and refactor the shit out of this!!!!
            bool loop = true;
            var translatedWords = new string[Languages.Length];
            
             
            while (loop)
            {
                for (int i = 0; i < Languages.Length; i++)
                {
                    Console.WriteLine(i == 0 ? $"Add a new word ({Languages[i]}): " : $"Add the {Languages[i]} translation: "); 
                    string input = Console.ReadLine();
                    if (input != "")
                    {
                        translatedWords[i] = input;
                        Save();
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

        public void List(int sortByTranslation, Action<string[]> showTranslations) //sortByTranslation = Vilket språk listan ska sorteras på.
        {                                                                         //showTranslations = Callback som anropas för varje ord i listan.

        }

        public Word GetWordToPractice()  //Returnerar slumpmässigt Word från listan, med slumpmässigt valda 
        {                               // FromLanguage och ToLanguage (dock inte samma). 

            return null;
        }
    }
}
