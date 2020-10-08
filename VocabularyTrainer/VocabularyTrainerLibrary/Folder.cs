using System;
using System.IO;

namespace VocabularyTrainerLibrary
{
    public static class Folder
    {

        public static string FileDirectory { get; private set; }
        public static string LocalAppDirectory { get; private set; }

        public static bool AppDirectoryExists()
        {
            LocalAppDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (!Directory.Exists(LocalAppDirectory + "\\vocabularytrainer"))
            {
                Console.WriteLine("Directory does not exist.");
                return false;
            }

            FileDirectory = Path.Combine(LocalAppDirectory, "VocabularyTrainer");
            return true;
        }

        public static void CreateDirectory()
        {
            FileDirectory = Path.Combine(LocalAppDirectory, "VocabularyTrainer");

            Directory.CreateDirectory(FileDirectory);
            Console.WriteLine($"Creating directory VocabularyTrainer at path: {FileDirectory}");
        }
    }
}
