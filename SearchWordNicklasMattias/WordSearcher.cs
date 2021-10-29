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

        internal Tree GetSearhWord(string searchWord)
        {
            //Bearbeta ordert så att det är redo för nästa steg
            WordSearcher.Word = searchWord;
            Tree tree = new Tree();
            var resultExists = CheckForDuplicateWord();

            if (resultExists)
            {
                //Ordet är redan sökt på, hämta den sparade datan å gå vidare med den.
                //tree = GetData();
            }
            else
            {//Ordet är inte sökt på
                tree = ExtractData(tree);
            }

            return tree;
        }

        private Tree ExtractData(Tree btObj)
        {
            //få ut data från alla docs
            foreach (var document in DB.Docs)
            {
                var word = WordSearcher.Word;
                var docTitle = document.Item1;
                var rows = SearchDocForMatch(word, document.Item2);
                var sentences = FindMatchInRows(rows);
                var wordCount = FindMatchInSentence(sentences);
                
                var sentencesString = "";
                for (int i = 0; i < sentences.Count; i++)
                {
                    if(sentences[i] != "")
                        sentencesString += 
                            $"|| Sentences {i +1}:\n" +
                            $"|| \t{sentences[i].Trim()}\n";
                }
                var result = 
                    $"______________________________\n" +
                    $"|| Word: {word}\n" +
                    $"|| Title:{docTitle}\n" +
                    $"|| Words Found: {wordCount}\n" +
                    $"{sentencesString}\n";
                
                btObj.AddNode(btObj.Root, btObj.AddNode(result));
            }

            return btObj;
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

        //Anropa en lista med tidigare sökta ord, om den finns med i listan return true, annars false
        public bool CheckForDuplicateWord() => new WordSearcher().SerchedWords.Contains(WordSearcher.Word);

        public void GetPriorSearchesFromData()
        {
            //all info spard.
        }
    }
}
