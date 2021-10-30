using SearchWordNicklasMattias.Utility;
using System;

namespace SearchWordNicklasMattias.UI
{
    internal class MenuOptions
    {
        /// <summary>
        /// Prompts user to choose a option.
        /// </summary>
        internal void MainMenu()
        {
            var ws = new WordSearcher();
            ws.LoadFiles();
            bool loop = true;
            do
            {
                Console.Clear();
                new PrintMenues().PrintMainMenu();
                var input = Helper.GetUserInput(1, 5);
                OptionForMainMenu(input);
            } while (loop);
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
            var docs = DB.Docs[option-1];
            Console.WriteLine();

            foreach (var row in docs.Item2)
            {
                Console.WriteLine(row);
            }
        }

        internal void OptionForPrintPreviousResults()
        {
            switch (Helper.GetUserInput(1, 4))
            {
                case 1:
                    new App().Print();
                    Helper.PressAnyKeyToContinue();
                    break;
                case 2:
                    //PrintASpecificSearchResult(FileNameSearchWordAndCounter.SearchWords);
                    MainMenu();
                    break;
                case 3:
                    MainMenu();
                    break;
                case 4:
                    Helper.ExitProgram();
                    break;
            }
        }

        //private void PrintOutPriorSearches()
        //{
        //    var data = new WordSearcher().GetPriorSearchesFromData();

        //    //Display så som vi vill
        //    //________________________________
        //    //Word: xxxx
        //    //Titels:
        //    //  xxxxx1.txt got 3 hits
        //    //  xxxxx2.txt got 2 hits
        //    //  xxxxx3.txt got 12 hits
        //    //Total hits: xx

        //    //var xxxx = new Tuple<string, string, int>("Namn", "Adress", 070123123);

        //    string word = "";
        //    List<string> titles = new List<string>();
        //    int count = default;
        //    int totalCount = default;

        //    foreach (var item in data)
        //    {
        //        Console.WriteLine("________________________________");
        //        Console.WriteLine($"|| Word: {word}");
        //        Console.WriteLine("|| Titles:");

        //        foreach (var title in collection)
        //        {
        //            Console.WriteLine($"||     {title} got {count} hits");
        //        }

        //        Console.WriteLine("|| Sentences containing word:");

        //        foreach (var sentences in collection)//Här kan man ju markera orden om man vill med
        //        {
        //            Console.WriteLine($"||{sentences}");
        //        }

        //        Console.WriteLine($"|| Total hits: {totalCount}");
        //    }
        //}

        private void ChosenResult(string chosenOption)
        {
          
        }

    }
}
