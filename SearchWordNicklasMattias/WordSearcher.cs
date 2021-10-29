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
                //var myNode = new Node();
                //myNode.AddNode("1");
                //myNode.AddNode("2");
                //myNode.AddNode("3");
                //myNode.AddNode("4");
                //myNode.AddNode("5");

                

                //myNode.PrintNode();

                //Console.ReadLine();


                Tree btObj = new Tree();
                Node iniRoot = btObj.AddNode("5");
                btObj.AddNode(btObj.Root, iniRoot);
                ExtractData(btObj);
                //btObj.AddNode(btObj.Root, btObj.addNode("6"));
                //btObj.AddNode(btObj.Root, btObj.addNode("7"));
                //btObj.AddNode(btObj.Root, btObj.addNode("8"));
                //btObj.AddNode(btObj.Root, btObj.addNode("9"));
                btObj.DisplayTree(btObj.Root);
                
                Console.ReadLine();
            }

            //return data
        }

        private void ExtractData(Tree btObj)
        {
            //Tree btObj = new Tree();
            //Node iniRoot = btObj.addNode("5");
            //få ut data från alla docs
            foreach (var document in DB.Docs)
            {
                var word = WordSearcher.Word;
                var docTitle = document.Item1;
                var rows = SearchDocForMatch(word, document.Item2);
                var sentences = FindMatchInRows(rows);
                var wordCount = FindMatchInSentence(sentences);

                var result = $"Search word : {word}\n{docTitle} got {wordCount} hits.\n{word} was found in these sentences: _______.";
                btObj.AddNode(btObj.Root, btObj.AddNode(result));
            }
        }

        private List<string> SearchDocForMatch(string searchWord, List<string> doc)
        {
            var rows = new List<string>();
            foreach (var row in doc)
            {
                if (row.ToLower().Contains(WordSearcher.Word))
                {
                    rows.Add(row);
                }
            }
            return rows;
        }


        private List<string> FindMatchInRows(List<string> rows)
        {
            var sentences = new List<string>();
            foreach (var row in rows)
            {
                sentences = row.Split('.').ToList();
            }
            return sentences;
        }

        private int FindMatchInSentence(List<string> sentence)
        {
            int counter = 0;
            for (int i = 0; i < sentence.Count; i++)
            {
                var words = sentence[i].Split(' ');
                for (int j = 0; j < words.Length; j++)
                    if (words[j].ToLower().Equals(WordSearcher.Word)) counter++;
            }
            return counter;
        }

        internal void PrintResult()
        {
            throw new NotImplementedException();
        }

        //Anropa en lista med tidigare sökta ord, om den finns med i listan return true, annars false
        public bool CheckForDuplicateWord() => new WordSearcher().SerchedWords.Contains(WordSearcher.Word);
    }
}
