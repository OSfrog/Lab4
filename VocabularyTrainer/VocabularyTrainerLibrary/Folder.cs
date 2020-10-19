using System;
using System.IO;

namespace VocabularyTrainerLibrary
{
    internal static class Folder 
    {
        public static string FileDirectory  => Path.Combine(LocalAppDirectory, "VocabularyTrainer");
        public static string LocalAppDirectory  => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static void CreateDirectory() => Directory.CreateDirectory(FileDirectory);

        public static string GetFilePath(string name) => $"{FileDirectory}\\{name}.dat";
    }
}
