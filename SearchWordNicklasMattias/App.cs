using System;

namespace SearchWordNicklasMattias
{
    internal class App
    {
        internal void Start()
        {
            new WordSearcher().GetSearhWord(Console.ReadLine());
        }

        /// <summary>
        /// Calls a print of the results in tree.
        /// </summary>
        internal void Print()
        {
            WordSearcher.MainTree.DisplayTree(WordSearcher.MainTree.Root);
        }
    }
}
