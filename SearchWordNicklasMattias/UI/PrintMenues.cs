using SearchWordNicklasMattias.Utility;
using System;
using System.Collections.Generic;

namespace SearchWordNicklasMattias.UI
{
    public class PrintMenues
    {
        /// <summary>
        /// Prints out the alternatives for the user.
        /// Options 4
        /// </summary>
        public void PrintMainMenu()
        {
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
        /// Options 4
        /// </summary>
        public void PrintPreviousResults()
        {
            Console.Clear();
            Console.WriteLine("=====================================================");
            Console.WriteLine("|| 1. Print out all results from previous search. ||");
            Console.WriteLine("|| 2. Print out a specific search result......... ||");
            Console.WriteLine("|| 3. Back to main menu.......................... ||");
            Console.WriteLine("|| 4. Exit application........................... ||");
            Console.WriteLine("=====================================================");
        }

        public void PrintList(List<string> l)
        {
            foreach (var row in l)
            {
                Console.WriteLine(row);
            }
        }

        public void PrintDocInOrder()
        {
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("|| Choose wich document to print ||");
            Console.WriteLine("||===============================||");
            Console.WriteLine("|| 1. Text1000.txt.............. ||");
            Console.WriteLine("|| 2. Text1500.txt.............. ||");
            Console.WriteLine("|| 3. Text3000.txt.............. ||");
            Console.WriteLine("==================================");
        }

        public int HowManyWords()
        {
            Console.WriteLine("\nHow many words would you like to sort?");
            return Helper.GetUserInput(1, int.MaxValue);
        }
                
        public void PrintSpecificResult(List<string> searchResultCollection)
        {
            Console.WriteLine("Press [Q] to go back to previous menu");

            var index = 1;
            foreach (var r in searchResultCollection)
            {
                Console.WriteLine($"|| {index++}. {r}");
            }
            Console.WriteLine("\nChoose your result to inspect further");
            Console.Write("Option: ");
            var result = Helper.GetUserInput(1, searchResultCollection.Count);
            //if (result == 0)
            //    new MenuOptions().OptionForMainMenu();
            //else
            //    ChosenResultOptions(searchResultCollection[result - 1]);
            Helper.PressAnyKeyToContinue();
        }

        public void SelectAText()
        {
            Console.Clear();
            DB.GetStream();
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
