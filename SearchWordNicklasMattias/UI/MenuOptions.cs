using SearchWordNicklasMattias.Utility;
using System;

namespace SearchWordNicklasMattias.UI
{
    /// <summary>
    /// Manages the menu options.
    /// </summary>
    internal class MenuOptions
    {
        /// <summary>
        /// Prompts user to choose a option.
        /// </summary>
        internal void MainMenu()
        {
            new WordSearcher().LoadFiles();

            do
            {
                Console.Clear();
                new PrintMenues().PrintMainMenu();
                OptionForMainMenu(Helper.GetUserInput(1, 5));
            } while (true);
        }

        /// <summary>
        /// Menu options for main menu.
        /// </summary>
        /// <param name="option"></param>
        internal void OptionForMainMenu(int option)
        {
            var pm = new PrintMenues();

            switch (option)
            {
                case 1:
                    Console.Clear();
                    Logo.WordSearch();
                    Console.Write("Word: ");
                    new App().Start();
                    Helper.PressAnyKeyToContinue();
                    break;
                case 2:
                    pm.PrintFullText();
                    OptionForPrintFullTxtMenu();
                    Helper.PressAnyKeyToContinue();
                    break;
                case 3:
                    pm.PrintPreviousResults();
                    OptionForPrintPreviousResults();
                    break;
                case 4:
                    pm.PrintDocInOrder();
                    var docInOrder = new WordSearcher().GetDocInOrder(Helper.GetUserInput(1, 3), pm.HowManyWords());
                    pm.PrintList(docInOrder);
                    Helper.PressAnyKeyToContinue();
                    break;
                case 5:
                    Console.Clear();
                    Logo.Exit();
                    Console.ReadLine();
                    Helper.ExitProgram();
                    break;
            }
        }

        /// <summary>
        /// Method for wich txt the user wants to print out.
        /// </summary>
        internal void OptionForPrintFullTxtMenu()
        {
            var option = Helper.GetUserInput(1, 4);
            switch (option)
            {
                case 1:
                case 2:
                case 3:
                    PrintChosenTxt(option);
                    break;
                case 4:
                    MainMenu();
                    break;
            }
        }

        /// <summary>
        /// Prints out each row from chosen document.
        /// </summary>
        /// <param name="option">User input.</param>
        private void PrintChosenTxt(int option)
        {
            Console.WriteLine();

            foreach (var row in DB.Docs[option - 1].Item2)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// Manages the print out the previous results call.
        /// </summary>
        internal void OptionForPrintPreviousResults()
        {
            switch (Helper.GetUserInput(1, 3))
            {
                case 1:
                    new App().Print();
                    Helper.PressAnyKeyToContinue();
                    break;
                case 2:
                    MainMenu();
                    break;
                case 3:
                    Helper.ExitProgram();
                    break;
            }
        }
    }
}
