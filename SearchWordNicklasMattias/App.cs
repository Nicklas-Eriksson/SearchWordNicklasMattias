using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWordNicklasMattias
{
    public class App
    {
        //public static Tree Main = new Tree();
        public void Start()
        {
            new WordSearcher().GetSearhWord(Console.ReadLine());
            Print();
            //Main.DisplayTree(Main.Root);
        }
        public void Print()
        {
            WordSearcher.MainTree.DisplayTree(WordSearcher.MainTree.Root);
        }
    }
}
