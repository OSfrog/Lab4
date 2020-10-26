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
                var lowerArgs = ToLowerArguments(args);

                switch (lowerArgs[0])
                {
                    case "-lists":
                        Lists(lowerArgs);
                        break;

                    case "-new":
                        New(lowerArgs);
                        break;

                    case "-add":
                        Add(lowerArgs);
                        break;
                    case "-remove":
                        Remove(lowerArgs);
                        break;
                    case "-words":
                        Words(lowerArgs);
                        break;

                    case "-count":
                        Count(lowerArgs);
                        break;

                    case "-practice":
                        Practice(lowerArgs);
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
            if (args.Length > 3)
            {
                var languages = new string[args.Length - 2];

                for (int i = 0; i < args.Length - 2; i++)
                {
                    languages[i] = args[i + 2];
                }

                var wordList = new WordList(args[1], languages);

                AddWords(wordList);

                Console.WriteLine($"-created list '{wordList.Name}' and added {wordList.Count()} words\n");
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
                var wordList = WordList.LoadList(args[1]);
                var count = wordList.Count();

                AddWords(wordList);

                count = wordList.Count() - count;

                Console.WriteLine(count > 1 ? $"\n-added {count} words to list '{args[1]}'\n"
                    : count == 1 ? $"\n-added {count} word to list '{args[1]}'\n"
                    : $"\n-no words added to list '{args[1]}'\n");
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
            if (args.Length > 2 && WordList.LoadList(args[1]) != null)
            {
                var languageIndex = 0;
                var wordList = WordList.LoadList(args[1]);
                var words = wordList.Count();

                for (int i = 0; i < wordList.Languages.Length; i++)
                {
                    if (args[2].ToLower() == wordList.Languages[i].ToLower())
                    {
                        languageIndex = i;
                    }
                }

                for (int i = 3; i < args.Length; i++)
                {
                    wordList.Remove(languageIndex, args[i]);
                }

                words -= wordList.Count();

                var result = words > 1 ? $"\n-removed {words} words from list '{args[1]}'\n" :
                   words == 1 ? $"\n-removed {words} word from list '{args[1]}'\n" :
                   $"\n-no words removed from list '{args[1]}'\n";

                Console.WriteLine(result);
            }
            else if (args.Length >= 2 && WordList.LoadList(args[1]) == null)
            {
                Console.WriteLine($"\n-list '{args[1]}' does not exist\n");
            }
            else
            {
                Console.WriteLine("\n-listname, language and word(s) is needed for -remove command\n");
            }
        }

        static void Words(string[] args)
        {
            if (args.Length >= 2 && WordList.LoadList(args[1]) != null) //Refactor this
            {
                var sortByLanguage = 0;
                var wordList = WordList.LoadList(args[1]);

                if (args.Length == 3 && wordList.Count() != 0)
                {
                    for (int i = 0; i < wordList.Languages.Length; i++)
                    {
                        if (args[2].ToLower() == wordList.Languages[i])
                        {
                            sortByLanguage = i;
                        }
                    }

                    Console.WriteLine();
                    foreach (var language in wordList.Languages)
                    {
                        Console.Write(language.ToUpper().PadRight(20));
                    }
                    Console.WriteLine();

                    wordList.List(sortByLanguage, x =>
                    {
                        foreach (var words in x)
                        {
                            Console.Write(words.PadRight(20));
                        }
                        Console.WriteLine();
                    });
                    Console.WriteLine();
                }
                else if (wordList.Count() != 0)
                {
                    Console.WriteLine();
                    foreach (var language in wordList.Languages)
                    {
                        Console.Write(language.ToUpper().PadRight(20));
                    }
                    Console.WriteLine();

                    wordList.List(x =>
                    {
                        foreach (var words in x)
                        {
                            Console.Write(words.PadRight(20));
                        }
                        Console.WriteLine();
                    });
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(WordList.LoadList(args[1]) != null ? $"\n-list '{args[1]}' is empty\n"
                        : $"\n-the list '{args[1]}' does not exist\n");
                }
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

                if (wordList != null)
                {
                    var words = wordList.Count();

                    Console.WriteLine(words == 1 ? $"\n-there is {words} word in list '{wordList.Name}'\n"
                        : words > 1 ? $"\n-there are {words} words in list '{wordList.Name}'\n"
                       : $"\n-list '{args[1]}' is empty\n");
                }
                else
                {
                    Console.WriteLine($"\n-list '{args[1]}' does not exist\n");
                }
            }
            else
            {
                Console.WriteLine("\n-listname is needed for -count command\n");
            }
        }

        static void Practice(string[] args)
        {
            var correctWordsCounter = 0f;
            var wordCounter = 0f;
            var wordList = WordList.LoadList(args[1]);
            if (wordList != null)
            {
                if (wordList.Count() != 0)
                {
                    Console.WriteLine("\n-press Enter (empty line) to stop practicing\n");
                    while (true)
                    {
                        var word = wordList.GetWordToPractice();

                        Console.Write($"-translate the {wordList.Languages[word.FromLanguage]} word " +
                            $"{word.Translations[word.FromLanguage]} to {wordList.Languages[word.ToLanguage]}: ");
                        var input = Console.ReadLine();
                        if (input == "")
                        {
                            break;
                        }
                        else if (input == word.Translations[word.ToLanguage])
                        {
                            Console.WriteLine("-correct answer");
                            correctWordsCounter++;
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
                                ClearCurrentConsoleLine();
                                Console.WriteLine();
                                break;
                            }

                            ClearCurrentConsoleLine();
                            Console.WriteLine("-wrong answer");
                        }
                    }

                    Console.WriteLine($"-{wordCounter} words were practiced on");
                    Console.WriteLine(correctWordsCounter != 0 ? $"-{correctWordsCounter / wordCounter:0%} of answers were correct"
                        : $"-no answers were correct");
                }
                else
                {
                    Console.WriteLine("\n-selected list is empty, use -add to populate list first\n");
                }
            }
            else
            {
                Console.WriteLine("\n-list does not exist\n");
            }
        }
        static void PrintInfo()
        {
            Console.WriteLine("\nUse any of the following parameters:");
            Console.WriteLine("-lists");
            Console.WriteLine("-new <list name> <language 1> <language2> .. <language n>");
            Console.WriteLine("-add <list name>");
            Console.WriteLine("-remove <list name> <language> <word 1> <word 2> .. <word n>");
            Console.WriteLine("-words <listname> <sortByLanguage>");
            Console.WriteLine("-count <listname>");
            Console.WriteLine("-practice <listname>\n");
        }

        static void AddWords(WordList wordList)
        {

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
        static string[] ToLowerArguments(string[] args)
        {
            var arguments = new string[args.Length];
            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = args[i].ToLower();
            }

            return arguments;
        }

        static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
