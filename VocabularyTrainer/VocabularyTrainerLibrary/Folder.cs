using System;
using System.IO;

namespace VocabularyTrainerLibrary
{
    internal static class Folder 
    {
        public static string FileDirectory  => Path.Combine(LocalAppDirectory, "VocabularyTrainer");
        public static string LocalAppDirectory  => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static bool AppDirectoryExists()
        {
            if (!Directory.Exists(LocalAppDirectory + "\\vocabularytrainer"))
            {
                Console.WriteLine("-directory does not exist.");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void CreateDirectory()
        {
            Directory.CreateDirectory(FileDirectory);
            Console.WriteLine($"-creating directory VocabularyTrainer at path: {FileDirectory}\n");
        }

        public static string GetFilePath(string name)
        {
            return $"{FileDirectory}\\{name}.dat";
        }
    }
}
