using System;

namespace SearchWordNicklasMattias
{
    internal class App
    {
        internal void Start()
        {
            var res = new WordSearcher().GetResultFromSearchWord(Console.ReadLine());
            Console.WriteLine(res);
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
