using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchWordNicklasMattias
{
    public class WordSearcher
    {
        private static string word;
        public static string Word
        {
            get => word.Trim().ToLower();
            set => word = value;
        }
        public List<string> SerchedWords = new List<string>();

        public int Counter;
        public int TotalCount;

        

        //Workflow 
        public void LoadFiles()
        {
            DB.GetStream();
        }

        internal void GetSearhWord(string searchWord)
        {
            //Bearbeta ordert så att det är redo för nästa steg
            WordSearcher.Word = searchWord;
            var resultExists = CheckForDuplicateWord();

            if (resultExists)
            {
                //Ordet är redan sökt på, hämta den sparade datan å gå vidare med den.
            }
            else
            {
                ExtractData();
                //var myNode = new Node();
                //myNode.AddNode("1");
                //myNode.AddNode("2");
                //myNode.AddNode("3");
                //myNode.AddNode("4");
                //myNode.AddNode("5");


                //myNode.PrintNode();

                //Console.ReadLine();


                Tree btObj = new Tree();
                //Node iniRoot = btObj.addNode("5");


                //btObj.AddNode(btObj.Root, iniRoot);
                //btObj.AddNode(btObj.Root, btObj.addNode("6"));
                //btObj.AddNode(btObj.Root, btObj.addNode("7"));
                //btObj.AddNode(btObj.Root, btObj.addNode("8"));
                //btObj.AddNode(btObj.Root, btObj.addNode("9"));
                ExtractData();
                btObj.displayTree(btObj.Root);
                
                Console.ReadLine();
            }

            //return data
        }

        private void ExtractData()
        {
            Tree btObj = new Tree();
            Node iniRoot = btObj.addNode("5");
            //få ut data från alla docs
            foreach (var document in DB.Docs)
            {
                var word = WordSearcher.Word;
                var docTitle = document.Item1;
                var rows = SearchDocForMatch(word, document.Item2);
                var sentences = FindMatchInRows(rows);
                var wordCount = FindMatchInSentence(sentences);

                var result = $"Serch word : {word}\n{docTitle} got {wordCount} hits.\n{word} was found in these sentences: _______.";
                btObj.AddNode(btObj.Root, btObj.addNode(result));
            }
        }

        

        private List<string> SearchDocForMatch(string searchWord, List<string> doc)
        {
            foreach (var row in doc)
            {

            }
            return null;
        }


        private List<string> FindMatchInRows(List<string> rows)
        {
            foreach (var row in rows)
            {

            }
            return null;
        }

        private int FindMatchInSentence(List<string> sentence)
        {
            foreach (var word in sentence)
            {

            }
            return 0;
        }

        internal void PrintResult()
        {
            throw new NotImplementedException();
        }

        //Anropa en lista med tidigare sökta ord, om den finns med i listan return true, annars false
        public bool CheckForDuplicateWord() => new WordSearcher().SerchedWords.Contains(WordSearcher.Word);
    }
}
