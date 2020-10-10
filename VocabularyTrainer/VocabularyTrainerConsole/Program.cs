using System;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Folder.AppDirectoryExists())   
                Folder.CreateDirectory();

            if (args.Length != 0)
            {


                switch (args[0])
                {
                    case "-lists":
                        if (args.Length == 1)
                        {
                            Console.WriteLine();
                            foreach (var file in WordList.GetLists())
                            {
                                Console.WriteLine(file);
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            PrintInfo();
                        }
                        break;

                    case "-new":
                        if (args.Length > 2)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Press Enter (empty line) to stop input of new words.\n");


                            var languages = new string[args.Length - 2];

                            for (int i = 0; i < args.Length - 2; i++)
                            {
                                languages[i] = args[i + 2];
                            }

                            var wordList = new WordList(args[1], languages);

                            wordList.Add();

                        }
                        else
                        {
                            PrintInfo();
                        }
                        break;

                    case "-add":
                        if (args.Length > 1)
                        {

                        }
                        break;
                    case "-remove":
                        break;
                    case "-words":
                        break;

                    case "-count":
                        if (args.Length == 2)
                        {
                            var wordList = WordList.LoadList(args[1]);

                            var words = wordList.Count(wordList.Name);

                            Console.WriteLine($"There are {words} words in list '{wordList.Name}'.");
                        }
                        else
                        {
                            PrintInfo();
                        }
                        break;

                    case "-practice":
                        break;

                    default:
                        //Console.Clear();
                        PrintInfo();
                        break;
                }
            }

            PrintInfo();

        }

        static void PrintInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Use any of the following parameters:");
            Console.WriteLine("-lists");
            Console.WriteLine("-new <list name> <language 1> <language2> .. <language n>");
            Console.WriteLine("-add <list name>");
            Console.WriteLine("-remove <list name> <language> <word 1> <word 2> .. <word n>");
            Console.WriteLine("-words <listname> <sortByLanguage>");
            Console.WriteLine("-count <listname>");
            Console.WriteLine("-practice <listname>\n");
        }

    }
}
