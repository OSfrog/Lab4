using System;
using VocabularyTrainerLibrary;

namespace VocabularyTrainerConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            if (args.Length != 0)
            {


                switch (ToLowerArguments(args)[0])
                {
                    case "-lists":
                        if (args.Length == 1)
                        {
                            Console.WriteLine();
                            if (WordList.GetLists() != null)
                            {
                                foreach (var file in WordList.GetLists())
                                {
                                    Console.WriteLine(file);
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            PrintInfo();
                        }
                        break;

                    case "-new":
                        if (args.Length > 2)
                        {
                            var languages = new string[args.Length - 2];

                            for (int i = 0; i < args.Length - 2; i++)
                            {
                                languages[i] = args[i + 2];
                            }

                            var wordList = new WordList(args[1], languages);
                            var input = "init";
                            var words = new string[wordList.Languages.Length];

                            Console.WriteLine("\nPress Enter (empty line) to stop input of new words.\n");
                            while (input != "")
                            {
                                for (int i = 0; i < wordList.Languages.Length; i++)
                                {
                                    Console.Write(i == 0 ? $"Add a new word ({wordList.Languages[i]}): " : $"Add the {wordList.Languages[i]} translation: ");
                                    input = Console.ReadLine();
                                    if (input != "")
                                    {
                                        words[i] = input;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                if (input != "")
                                {
                                    wordList.Add(words);
                                    wordList.Save();
                                }
                            }
                        }
                        else
                        {
                            PrintInfo();
                        }
                        break;

                    case "-add":
                        if (args.Length == 2 && WordList.LoadList(args[1]) != null)
                        {
                            var count = 0;
                            var input = "init";
                            var wordList = WordList.LoadList(args[1]);
                            var words = new string[wordList.Languages.Length];

                            Console.WriteLine("\nPress Enter (empty line) to stop input of new words.\n");
                            while (input != "")
                            {
                                for (int i = 0; i < wordList.Languages.Length; i++)
                                {
                                    Console.Write(i == 0 ? $"Add a new word ({wordList.Languages[i]}): " : $"Add the {wordList.Languages[i]} translation: ");
                                    input = Console.ReadLine();
                                    if (input != "")
                                    {
                                        words[i] = input;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                if (input != "")
                                {
                                    wordList.Add(words);
                                    wordList.Save();
                                    count++;
                                }
                            }

                            Console.WriteLine(count == 1 ? $"\n-added {count} word to list '{wordList.Name}'\n" : $"\n-added {count} words to list '{wordList.Name}'\n");
                        }
                        else if (args.Length > 2)
                        {
                            PrintInfo();
                        }
                        else
                        {

                            Console.WriteLine($"\n-list '{args[1]}' is invalid, use the '-new' command to append languages to the list before adding words\n");
                        }
                        break;
                    case "-remove":
                        if (args.Length >= 2 && WordList.LoadList(args[1]) != null)
                        {
                            var removeInLanguage = 0;
                            var wordList = WordList.LoadList(args[1]);
                            for (int i = 0; i < wordList.Languages.Length; i++)
                            {
                                if (args[2].ToLower() == wordList.Languages[i].ToLower())
                                {
                                    removeInLanguage = i;
                                }
                            }

                            for (int i = 3; i < args.Length; i++)
                            {
                                wordList.Remove(removeInLanguage, args[i]);

                            }
                            break;
                        }
                        else
                        {
                            PrintInfo();
                        }
                        break;
                    case "-words":
                        if (args.Length >= 2 && WordList.LoadList(args[1]) != null)
                        {
                            var sortByLanguage = 0;
                            var wordList = WordList.LoadList(args[1]);
                            if (args.Length == 3)
                            {
                                for (int i = 0; i < wordList.Languages.Length; i++)
                                {
                                    if (args[2].ToLower() == wordList.Languages[i])
                                    {
                                        sortByLanguage = i;
                                    }
                                }

                                wordList.List(sortByLanguage, x =>
                                {
                                    foreach (var words in x)
                                    {
                                        Console.Write(words.PadRight(20));
                                    }
                                    Console.WriteLine();
                                });

                            }
                            else
                            {
                                foreach (var language in wordList.Languages)
                                {
                                    Console.Write(language.ToUpper().PadRight(20));
                                }
                                Console.WriteLine();
                                foreach (var word in wordList.ReturnWords())
                                {
                                    foreach (var translation in word.Translations)
                                    {
                                        Console.Write(translation.PadRight(20));
                                    }
                                    Console.WriteLine();
                                }
                            }
                        }
                        else if (args.Length == 2 && WordList.LoadList(args[1]) == null)
                        {
                            Console.WriteLine($"\n-list '{args[1]}' is empty or does not exist\n");
                        }
                        else
                        {
                            PrintInfo();
                        }
                        break;

                    case "-count":
                        if (args.Length == 2)
                        {
                            var wordList = WordList.LoadList(args[1]);

                            if (wordList != null && wordList.Count(args[1]) != 0)
                            {
                                var words = wordList.Count(args[1]);

                                Console.WriteLine(words == 1 ? $"\n-there is {words} word in list '{wordList.Name}'\n" :
                                    $"\n-there are {words} words in list '{wordList.Name}'\n");
                            }
                            else
                            { 
                                Console.WriteLine(wordList.Languages.Length != 0 ? $"\n-the list '{args[1]}' is empty\n" :
                                    $"\n-the list '{args[1]}' does not exist\n");
                                break;
                            }
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
            else
            {
                PrintInfo();
            }


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

        static string[] ToLowerArguments(string[] args)
        {
            var arguments = new string[args.Length];
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = args[i].ToLower();
            }

            return arguments;
        }
    }
}
