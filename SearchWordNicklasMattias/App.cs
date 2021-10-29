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
            Console.Write("Word: ");
            var tree = new WordSearcher().GetSearhWord(Console.ReadLine());

            tree.DisplayTree(tree.Root);
        }
    }
}
