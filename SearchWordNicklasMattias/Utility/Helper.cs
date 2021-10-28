using System;
using System.Threading;

namespace SearchWordNicklasMattias.Utility
{
    /// <summary>
    /// Utility classes to help with programming.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Prompts user with an error.
        /// Default error = "Error! Wrong input."
        /// </summary>
        /// <param name="e">"" for default error or optional.</param>
        /// <returns></returns>
        internal static void Error(string e)
        {
            if (e == "")
            {
                Console.WriteLine("Error! Wrong input.");
                Thread.Sleep(1200);
            }

            Console.WriteLine(e);
        }

        /// <summary>
        /// For menu options.
        /// if input is not able to be parsed the method is called again.
        /// if number is lower than minInput or higher than maxOutput is called again.
        /// if input == q user wants to go back to previous menu.
        /// </summary>
        internal static int GetUserInput(int minInput, int maxOutput)
        {
            Console.Write("Option: ");
            var input = Console.ReadLine().Trim().ToLower();
            if (!Int32.TryParse(input, out int number) || number < minInput || number > maxOutput)
            {
                //if (input.StartsWith("q")) new DisplayToUser().MainMenu(); //user wants to go back
                //Error("");
                //number = GetUserInput(minInput, maxOutput);
            }

            return number;
        }

        internal static void PressAnyKeyToContinue()
        {
            Console.WriteLine("\nPress any key to go back!");
            Console.ReadLine();
        }

        /// <summary>
        /// Exits the application with exit code 0.
        /// </summary>
        internal static void ExitProgram() => Environment.Exit(0);
    }
}
