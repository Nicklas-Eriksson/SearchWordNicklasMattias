using System;
using System.Collections.Generic;

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
        public static Tree MainTree = new Tree();
        public int Counter;
        public int TotalCount;

        public void LoadFiles()
        {
            DB.GetStream();
        }

        internal void GetSearhWord(string searchWord)
        {
            //Bearbeta ordert så att det är redo för nästa steg
            WordSearcher.Word = searchWord;
            //Tree tree = new Tree();
            var resultExists = CheckForDuplicateWord();

            if (resultExists)
            {
                //Ordet är redan sökt på, hämta den sparade datan å gå vidare med den.
                //tree = GetData();
            }
            else
            {//Ordet är inte sökt på
                ExtractData(MainTree);
            }
        }

        private void ExtractData(Tree tree)
        {
            //få ut data från alla docs
            foreach (var document in DB.Docs)
            {
                var word = WordSearcher.Word;
                var docTitle = document.Item1;
                var rows = SearchDocRowsForMatch(word, document.Item2);
                var sentencesFromRows = SplitRowsIntoSentences(rows);
                var sentences = FindMatchInSentence(sentencesFromRows);
                var wordCount = CountWordInSentences(sentences);

                var sentencesString = "";
                for (int i = 0; i < sentences.Count; i++)
                {
                    if (sentences[i] != "")
                        sentencesString +=
                            $"|| Sentences {i + 1}:\n" +
                            $"|| \t{sentences[i].Trim()}\n";
                }
                var result =
                    $"______________________________\n" +
                    $"|| Word: {word}\n" +
                    $"|| Title:{docTitle}\n" +
                    $"|| Words Found: {wordCount}\n" +
                    $"{sentencesString}\n" +
                    $"______________________________"
                    ;

                tree.AddNode(tree.Root, tree.AddNode(result));
            }
        }

        public List<string> GetDocInOrder(int index, int numberOfWords)
        {
            var doc = DB.Docs[index - 1].Item2;
            var sentences = SplitRowsIntoSentences(doc);
            var words = SplitSentencesIntoWords(sentences);

            var sorted = SortingAlgorithm.Quick(words, 0, 0);

            var requistedList = new List<string>();
            if (numberOfWords <= words.Count - 1)
            {
                for (int i = 0; i < numberOfWords; i++)
                {
                    requistedList.Add(sorted[i]);
                }
            }

            return requistedList;
        }

        private List<string> SplitSentencesIntoWords(List<string> sentences)
        {
            var words = new List<string>();
            for (int i = 0; i < sentences.Count; i++)
            {
                var temp = sentences[i].Split(' ');
                temp = temp[temp.Length-1].Split('"');
                temp = temp[temp.Length-1].Split(',');
                temp = temp[temp.Length-1].Split('-');
                temp = temp[temp.Length-1].Split('.');
                temp = temp[temp.Length-1].Split('!');
                temp = temp[temp.Length-1].Split('?');
                temp = temp[temp.Length-1].Split('_');
                temp = temp[temp.Length-1].Split('\'');

                foreach (var word in temp)
                {
                    if (word == "" || word == " " || word == "-" || word == "\"")
                    {
                        continue;
                    }
                    else
                    {
                        if (words.Contains(word.Trim().ToLower()) || words.Contains(word.Trim().ToUpper()))
                        {
                            continue;
                        }
                        else
                        {
                            var c = word?.Trim().ToUpper()[0];
                            var rest = word?.Trim().Substring(1);
                            words.Add(c+rest);
                        }
                    }
                }
            }

            return words;
        }

        private List<string> SearchDocRowsForMatch(string searchWord, List<string> doc)
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

        private List<string> SplitRowsIntoSentences(List<string> rows)
        {
            var sentences = new List<string>();
            foreach (var row in rows)
            {
                sentences.AddRange(row.Split('.', '!', '?'));
            }
            return sentences;
        }

        private List<string> FindMatchInSentence(List<string> sentence)
        {
            var sentencesContainingWord = new List<string>();
            for (int i = 0; i < sentence.Count; i++)
            {
                if (sentence[i].ToLower().Contains(Word))
                {
                    sentencesContainingWord.Add(sentence[i]);
                }
            }

            var sentencesWithExactWord = new List<string>();
            for (int i = 0; i < sentencesContainingWord.Count; i++)
            {
                var word = sentencesContainingWord[i].Split(' ');
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j].ToLower().Equals(Word) || word[j].ToLower().Equals(Word + ','))
                    {
                        sentencesWithExactWord.Add(sentencesContainingWord[i]);
                    }
                }
            }

            return sentencesWithExactWord;
        }

        private int CountWordInSentences(List<string> sentences)
        {
            int counter = 0;
            for (int i = 0; i < sentences.Count; i++)
            {
                var words = sentences[i].Split(' ');
                for (int j = 0; j < words.Length; j++)
                    if (words[j].ToLower().Equals(WordSearcher.Word)) counter++;
            }

            return counter;
        }

        //Anropa en lista med tidigare sökta ord, om den finns med i listan return true, annars false
        public bool CheckForDuplicateWord() => new WordSearcher().SerchedWords.Contains(WordSearcher.Word);
    }
}
