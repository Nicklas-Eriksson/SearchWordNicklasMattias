using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWordNicklasMattias
{
    public class App
    {
        public void Start()
        {
            //Menu.MainMenu();
            var ws = new WordSearcher();
            ws.LoadFiles();
            Console.Write("Word: ");
            ws.GetSearhWord(Console.ReadLine());
            Console.ReadLine();
           // ws.PrintResult();
        }
    }
}
