using System;

namespace SearchWordNicklasMattias.UI
{
    /// <summary>
    /// Logotypes for a nice looking UI :D
    /// </summary>
    internal static class Logo
    {
        internal static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@"___  ___      _        ___  ___                 
|  \/  |     (_)       |  \/  |                 
| .  . | __ _ _ _ __   | .  . | ___ _ __  _   _ 
| |\/| |/ _` | | '_ \  | |\/| |/ _ \ '_ \| | | |
| |  | | (_| | | | | | | |  | |  __/ | | | |_| |
\_|  |_/\__,_|_|_| |_| \_|  |_/\___|_| |_|\__,_|
                                                
                                                ");
            Console.ResetColor();
        }

        internal static void WordSearch()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@" _    _               _   _____                     _           
| |  | |             | | /  ___|                   | |          
| |  | | ___  _ __ __| | \ `--.  ___  __ _ _ __ ___| |__        
| |/\| |/ _ \| '__/ _` |  `--. \/ _ \/ _` | '__/ __| '_ \       
\  /\  / (_) | | | (_| | /\__/ /  __/ (_| | | | (__| | | |_ _ _ 
 \/  \/ \___/|_|  \__,_| \____/ \___|\__,_|_|  \___|_| |_(_|_|_)
                                                                
                                                                ");
            Console.ResetColor();
        }

        internal static void History()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@" _   _ _     _                   
| | | (_)   | |                  
| |_| |_ ___| |_ ___  _ __ _   _ 
|  _  | / __| __/ _ \| '__| | | |
| | | | \__ \ || (_) | |  | |_| |
\_| |_/_|___/\__\___/|_|   \__, |
                            __/ |
                           |___/ ");
            Console.ResetColor();
        }

        internal static void FullTexts()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@"______     _       _     _____       _    ______     _ _    _        _           __ _ _           
| ___ \   (_)     | |   |  _  |     | |   |  ___|   | | |  | |      | |         / _(_) |          
| |_/ / __ _ _ __ | |_  | | | |_   _| |_  | |_ _   _| | |  | |___  _| |_ ______| |_ _| | ___  ___ 
|  __/ '__| | '_ \| __| | | | | | | | __| |  _| | | | | |  | __\ \/ / __|______|  _| | |/ _ \/ __|
| |  | |  | | | | | |_  \ \_/ / |_| | |_  | | | |_| | | |  | |_ >  <| |_       | | | | |  __/\__ \
\_|  |_|  |_|_| |_|\__|  \___/ \__,_|\__| \_|  \__,_|_|_| (_)__/_/\_\\__|      |_| |_|_|\___||___/
                                                                                                  
                                                                                                  ");
            Console.ResetColor();
        }

        internal static void SortIt()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@" _____            _     _____ _     _ 
/  ___|          | |   |_   _| |   | |
\ `--.  ___  _ __| |_    | | | |_  | |
 `--. \/ _ \| '__| __|   | | | __| | |
/\__/ / (_) | |  | |_   _| |_| |_  |_|
\____/ \___/|_|   \__|  \___/ \__| (_)
                                      
                                      ");
            Console.ResetColor();
        }

        internal static void Exit()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($@" _____               _               _____                   _             _           _ 
/  ___|             (_)             |_   _|                 (_)           | |         | |
\ `--.  ___  ___ ___ _  ___  _ __     | | ___ _ __ _ __ ___  _ _ __   __ _| |_ ___  __| |
 `--. \/ _ \/ __/ __| |/ _ \| '_ \    | |/ _ \ '__| '_ ` _ \| | '_ \ / _` | __/ _ \/ _` |
/\__/ /  __/\__ \__ \ | (_) | | | |   | |  __/ |  | | | | | | | | | | (_| | ||  __/ (_| |
\____/ \___||___/___/_|\___/|_| |_|   \_/\___|_|  |_| |_| |_|_|_| |_|\__,_|\__\___|\__,_|
                                                                                         
                                                                                         ");
            Console.ResetColor();
        }
    }
}
