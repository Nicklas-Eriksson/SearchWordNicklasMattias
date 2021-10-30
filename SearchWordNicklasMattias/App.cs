using System;

namespace SearchWordNicklasMattias
{
    internal class App
    {
        internal void Start()
        {
            new WordSearcher().GetSearhWord(Console.ReadLine());
        }

        internal void Print()
        {
            WordSearcher.MainTree.DisplayTree(WordSearcher.MainTree.Root);
        }
    }
}
