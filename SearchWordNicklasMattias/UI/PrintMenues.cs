using SearchWordNicklasMattias.Utility;
using System;
using System.Collections.Generic;

namespace SearchWordNicklasMattias.UI
{
    /// <summary>
    /// Manages the print methods for the menus.
    /// </summary>
    internal class PrintMenues
    {
        /// <summary>
        /// Prints out the alternatives for the user.
        /// Options 5.
        /// </summary>
        internal void PrintMainMenu()
        {
            Console.Clear();
            Logo.MainMenu();
            Console.WriteLine("==================================");
            Console.WriteLine("|| 1. Search for a new word.... ||");
            Console.WriteLine("|| 2. Print out a text......... ||");
            Console.WriteLine("|| 3. Previous results......... ||");
            Console.WriteLine("|| 4. Print doc words in order. ||");
            Console.WriteLine("|| 5. Exit application......... ||");
            Console.WriteLine("==================================");
        }

        /// <summary>
        /// Prints out the previous results for the user.
        /// Options 3.
        /// </summary>
        internal void PrintPreviousResults()
        {
            Console.Clear();
            Logo.History();
            Console.WriteLine("====================================");
            Console.WriteLine("|| 1. Print out previous results. ||");
            Console.WriteLine("|| 2. Back to main menu.......... ||");
            Console.WriteLine("|| 3. Exit application........... ||");
            Console.WriteLine("====================================");
        }

        /// <summary>
        /// Print outs a list.
        /// </summary>
        /// <param name="l"></param>
        internal void PrintList(List<string> l)
        {
            int i = 0;
            Console.WriteLine();
            foreach (var row in l)
            {
                Console.WriteLine($"{++i}. {row}");
            }
        }

        /// <summary>
        /// Displays to user documents available for printing.
        /// </summary>
        internal void PrintDocInOrder()
        {
            Console.Clear();
            Logo.SortIt();
            Console.WriteLine("==================================");
            Console.WriteLine("|| Choose wich document to print ||");
            Console.WriteLine("||===============================||");
            Console.WriteLine("|| 1. Text1000.txt.............. ||");
            Console.WriteLine("|| 2. Text1500.txt.............. ||");
            Console.WriteLine("|| 3. Text3000.txt.............. ||");
            Console.WriteLine("==================================");
        }

        /// <summary>
        /// Prompts the user on how many words it would like to sort.
        /// </summary>
        /// <returns></returns>
        internal int HowManyWords()
        {
            Console.WriteLine("\nHow many words would you like to sort?");
            return Helper.GetUserInput(1, int.MaxValue);
        }

        /// <summary>
        /// Prompts the user on what txt doc they want to print out all of the text from.
        /// </summary>
        internal void PrintFullText()
        {
            Console.Clear();
            Logo.FullTexts();
            Console.WriteLine("=====================================");
            Console.WriteLine("|| What txt you want to print out? ||");
            Console.WriteLine("||=================================||");
            Console.WriteLine("|| 1. 1000 words text............. ||");
            Console.WriteLine("|| 2. 1500 words text............. ||");
            Console.WriteLine("|| 3. 3000 words text............. ||");
            Console.WriteLine("|| 4. Back to menu................ ||");
            Console.WriteLine("=====================================");
        }
    }
}
