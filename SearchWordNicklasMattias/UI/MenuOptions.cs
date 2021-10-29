using SearchWordNicklasMattias.Utility;
using System;

namespace SearchWordNicklasMattias.UI
{
    public class MenuOptions
    {
        /// <summary>
        /// Prompts user to choose a option.
        /// </summary>
        public void MainMenu()
        {
            var ws = new WordSearcher();
            ws.LoadFiles();
            bool loop = true;
            do
            {
                Console.Clear();
                new PrintMenues().PrintMainMenu();
                var input = Helper.GetUserInput(1, 4);
                OptionForMainMenu(input);
            } while (loop);
        }

        /// <summary>
        /// Menu options for main menu.
        /// </summary>
        /// <param name="option"></param>
        public void OptionForMainMenu(int option)
        {
            switch (option)
            {
                case 1:
                    new App().Start();
                    Helper.PressAnyKeyToContinue();
                    break;
                case 2:
                    new PrintMenues().SelectAText();
                    OptionForPrintFullTxtMenu();
                    break;
                case 3:
                    //PrintPreviousResults();
                    //OptionForPrintPreviousResults();
                    break;
                case 4:
                    Helper.ExitProgram();
                    break;
            }
        }

        public void OptionForPrintFullTxtMenu()
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
        /// <param name="option"></param>
        private void PrintChosenTxt(int option)
        {
            var docs = DB.Docs[option-1];
            foreach (var row in docs.Item2)
            {
                Console.WriteLine(row);
            }
        }

        //public void OptionForPrintPreviousResults()
        //{
        //    switch (Helper.GetUserInput(1, 4))
        //    {
        //        case 1:
        //            PrintOutPriorSearches(FileNameSearchWordAndCounter.MyCollection, 0);
        //            Helper.PressAnyKeyToContinue();
        //            break;
        //        case 2:
        //            PrintASpecificSearchResult(FileNameSearchWordAndCounter.SearchWords);
        //            MainMenu();
        //            break;
        //        case 3:
        //            MainMenu();
        //            break;
        //        case 4:
        //            Helper.ExitProgram();
        //            break;
        //    }
        //}

        private void ChosenResult(string chosenOption)
        {
          
        }

    }
}
