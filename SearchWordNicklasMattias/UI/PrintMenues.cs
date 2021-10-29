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
            Console.WriteLine("===============================");
            Console.WriteLine("|| 1. Search for a new word. ||");
            Console.WriteLine("|| 2. Print out a text...... ||");
            Console.WriteLine("|| 3. Previous results...... ||");
            Console.WriteLine("|| 4. Exit application...... ||");
            Console.WriteLine("===============================");
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

            Console.WriteLine("What txt you want to print out?\n");
            Console.WriteLine("==========================");
            Console.WriteLine("|| 1. 1000 words text.. ||");
            Console.WriteLine("|| 2. 1500 words text.. ||");
            Console.WriteLine("|| 3. 3000 words text.. ||");
            Console.WriteLine("|| 4. Back to menu..... ||");
            Console.WriteLine("==========================");
        }
    }
}
