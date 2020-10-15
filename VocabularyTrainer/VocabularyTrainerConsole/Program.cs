using System;
using System.IO;
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
                        Lists(args);
                        break;

                    case "-new":
                        New(args);
                        break;

                    case "-add":
                        Add(args);
                        break;
                    case "-remove":
                        Remove(args);
                        break;
                    case "-words":
                        Words(args);
                        break;

                    case "-count":
                        Count(args);
                        break;

                    case "-practice":
                        Practice(args);
                        break;

                    default:
                        Console.Clear();
                        PrintInfo();
                        break;
                }
            }
            else
            {
                PrintInfo();
            }


        }


        static void Lists(string[] args)
        {
            if (args.Length == 1)
            {
                if (WordList.GetLists() != null && WordList.GetLists().Length != 0)
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
                    Console.WriteLine($"\n-no files found, directory is empty\n");
                }
            }
            else
            {
                PrintInfo();
            }
        }

        static void New(string[] args)
        {
            if (args.Length > 2)
            {
                var languages = new string[args.Length - 2];

                for (int i = 0; i < args.Length - 2; i++)
                {
                    languages[i] = args[i + 2];
                }

                var wordList = new WordList(args[1], languages);
                var input = "init";

                Console.WriteLine("\nPress Enter (empty line) to stop input of new words.\n");
                while (input != "")
                {
                    var words = new string[wordList.Languages.Length];
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
        }

        static void Add(string[] args)
        {
            if (args.Length == 2 && WordList.LoadList(args[1]) != null)
            {
                var count = 0;
                var input = "init";
                var wordList = WordList.LoadList(args[1]);

                Console.WriteLine("\nPress Enter (empty line) to stop input of new words.\n");
                while (input != "")
                {
                    var words = new string[wordList.Languages.Length];
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
            else if (args.Length == 2 && WordList.LoadList(args[1]) == null)
            {
                var filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\VocabularyTrainer\\{args[1]}.dat";

                Console.WriteLine(File.Exists(filePath) ? $"\n-list '{args[1]}' is invalid, use the '-new' command to add languages to the list before adding words\n" :
                   $"\n-list '{args[1]}' does not exist, use the '-new' command to add a new list\n");
            }
            else
            {
                PrintInfo();
            }
        }

        static void Remove(string[] args)
        {
            if (args.Length >= 2 && WordList.LoadList(args[1]) != null)
            {
                var removeInLanguage = 0;
                var wordList = WordList.LoadList(args[1]);
                var words = wordList.Count(args[1]);
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

                words -= wordList.Count(args[1]);

                var result = words > 1 ? $"\n-removed {words} words from list '{args[1]}'\n" :
                   words == 1 ? $"\n-removed {words} word from list '{args[1]}'\n" :
                   $"\n-no words removed from list '{args[1]}'\n";

                Console.WriteLine(result);
            }
            else
            {
                PrintInfo();
            }
        }

        static void Words(string[] args)
        {
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
        }

        static void Count(string[] args)
        {
            if (args.Length == 2)
            {
                var filePath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\VocabularyTrainer\\{args[1]}.dat";
                var wordList = WordList.LoadList(args[1]);

                if (wordList != null && wordList.Count(args[1]) != 0)
                {
                    var words = wordList.Count(args[1]);

                    Console.WriteLine(words == 1 ? $"\n-there is {words} word in list '{wordList.Name}'\n" :
                        $"\n-there are {words} words in list '{wordList.Name}'\n");
                }
                else
                {
                    Console.WriteLine(File.Exists(filePath) ? $"\n-the list '{args[1]}' is empty\n" :
                        $"\n-the list '{args[1]}' does not exist\n");
                }
            }
            else
            {
                PrintInfo();
            }
        }

        static void Practice(string[] args)
        {
            var correctCounter = 0;
            var wordCounter = 0;
            var wordList = WordList.LoadList(args[1]);
            Console.WriteLine("\n-press Enter (empty line) to stop practicing\n");

            while (true)
            {
                var word = wordList.GetWordToPractice();

                Console.Write($"-translate the {wordList.Languages[word.FromLanguage]} word {word.Translations[word.FromLanguage]} to {wordList.Languages[word.ToLanguage]}: ");
                var input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }
                else if (input == word.Translations[word.ToLanguage])
                {
                    Console.WriteLine("-correct answer");
                    correctCounter++;
                    wordCounter++;
                }
                else
                {
                    wordCounter++;
                    Console.Write($"-wrong answer, the correct translation was '{word.Translations[word.ToLanguage]}'" +
                        $"      (press enter to stop or any other key to continue)");
                     var keyInput = Console.ReadKey().Key;

                    if (keyInput == ConsoleKey.Enter)
                    {
                        break;
                    }

                    ClearCurrentConsoleLine();
                    Console.WriteLine("-wrong answer");
                }
            }

            Console.WriteLine($"-{wordCounter} words were practiced on");
            Console.WriteLine(correctCounter != 0 ? $"-{100 / correctCounter:N0}% of answers were correct" 
                : $"-no answers were correct");
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

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor-1);
        }
    }
}
