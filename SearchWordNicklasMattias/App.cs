using System;

namespace SearchWordNicklasMattias
{
    public class App
    {
        public void Start()
        {
            new WordSearcher().GetSearhWord(Console.ReadLine());
            Print();
        }

        public void Print()
        {
            WordSearcher.MainTree.DisplayTree(WordSearcher.MainTree.Root);
        }
    }
}
