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
                        Console.WriteLine();
                        foreach (var file in WordList.GetLists())
                        {
                            Console.WriteLine(file);
                        }
                        Console.WriteLine();
                        break;
                    case "-new":
                        break;
                    case "-add":
                        break;
                    case "-remove":
                        break;
                    case "-words":
                        break;
                    case "-count":
                        break;
                    case "-practice":
                        break;

                    default:
                        Console.WriteLine();
                        break;
                }
            }
            else
            {
                //Console.Clear();
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
}
