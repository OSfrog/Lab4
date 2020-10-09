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
            var fileArray = new string[Directory.EnumerateFiles(Folder.FileDirectory).Count()];
            var i = 0;

            foreach (var file in Directory.EnumerateFiles(Folder.FileDirectory))
            {
                fileArray[i] = Path.GetFileNameWithoutExtension(file);
                i++;
            }



            return fileArray;
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

        public void Save() //Sparar listan till en fil med samma namn som listan och filändelse .dat
        {

        }

        public void Add(params string[] translations) //Lägger till ord i listan. Kasta ArgumentException om det är fel antal translations. 
        {
            bool loop = true;
             
            while (loop)
            {
                for (int i = 0; i < translations.Length; i++)
                {
                    Console.WriteLine(i == 0 ? $"Add a new word ({translations[i]}): " : $"Add the {translations[i]} translation: "); 
                    string input = Console.ReadLine();
                    if (input != "")
                    {
                        //logic to put word in the list
                    }
                    else
                    {
                        loop = false;
                    }
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
