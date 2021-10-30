using System;

namespace SearchWordNicklasMattias
{
    internal class App
    {
        internal void Start()
        {
            var res = new WordSearcher().GetSearhWord(Console.ReadLine());
            Console.WriteLine(res);
        }

        internal void Print()
        {
            WordSearcher.MainTree.DisplayTree(WordSearcher.MainTree.Root);
        }
    }
}
