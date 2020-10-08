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
            return null;
        }

        public void Save() //Sparar listan till en fil med samma namn som listan och filändelse .dat
        {

        }

        public void Add(params string[] translations) //Lägger till ord i listan. Kasta ArgumentException om det är fel antal translations. 
        {

        }

        public bool Remove(int translation, string word) //translation motsvarar index i Languages. Sök igenom språket och ta bort ordet. 
        {
            return false;
        }
        public int Count() //Räknar och returnerar antal ord i listan.
        {
            return 0;
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
