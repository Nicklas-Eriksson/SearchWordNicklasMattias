using System.Collections.Generic;
using System.Linq;

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
        public static List<string> SearchedWords = new List<string>();
        public static Tree MainTree = new Tree();
        public int Counter;
        public int TotalCount;
        public static string ResultString = "";

        public void LoadFiles() => DB.GetStream();

        public string GetSearhWord(string searchWord)
        {
            WordSearcher.Word = searchWord;

            if (CheckForDuplicateWord())
            {
                return ResultString;
            }
            else
            {
                return ExtractData(MainTree);
            }
        }

        private string ExtractData(Tree tree)
        {
            var sortingDict = new Dictionary<string, (string, int)>();

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
                sortingDict.Add(result, (word, wordCount));
            }

            SearchedWords.Add(Word);
            ResultString = SortResultsForInsertion(sortingDict);
            tree.AddNode(tree.Root, tree.AddNode(ResultString));

            return ResultString;
        }

        public string SortResultsForInsertion(Dictionary<string, (string, int)> dict)
        {
            string resultString = null;
            var sortByValue = from entry in dict orderby entry.Value descending select entry;

            foreach (var item in sortByValue)
            {
                resultString += item;
            }

            return resultString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="numberOfWords"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Separates signs to compile a list of all single words within list.
        /// </summary>
        /// <param name="sentences"></param>
        /// <returns>List</returns>
        private List<string> SplitSentencesIntoWords(List<string> sentences)
        {
            var words = new List<string>();

            for (int i = 0; i < sentences.Count; i++)
            {
                var temp = sentences[i].Split(' ');
                temp = temp[temp.Length - 1].Split('"');
                temp = temp[temp.Length - 1].Split(',');
                temp = temp[temp.Length - 1].Split('-');
                temp = temp[temp.Length - 1].Split('.');
                temp = temp[temp.Length - 1].Split('!');
                temp = temp[temp.Length - 1].Split('?');
                temp = temp[temp.Length - 1].Split('_');
                temp = temp[temp.Length - 1].Split('\'');

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
                            words.Add(c + rest);
                        }
                    }
                }
            }

            return words;
        }

        /// <summary>
        /// Adds rows with a Contains match to list.
        /// </summary>
        /// <param name="searchWord"></param>
        /// <param name="doc"></param>
        /// <returns>List</returns>
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

        /// <summary>
        /// Iterates over list to separate complete rows to a list of sentences.
        /// </summary>
        /// <param name="rows"></param>
        /// <returns>List</returns>
        private List<string> SplitRowsIntoSentences(List<string> rows)
        {
            var sentences = new List<string>();

            foreach (var row in rows)
            {
                sentences.AddRange(row.Split('.', '!', '?'));
            }

            return sentences;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns>List</returns>
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

        /// <summary>
        /// Counts the number of equal mentions of current search word within a list of words within current document.
        /// O()
        /// </summary>
        /// <param name="sentences"></param>
        /// <returns>int</returns>
        private int CountWordInSentences(List<string> sentences)
        {
            int counter = 0;

            for (int i = 0; i < sentences.Count; i++)
            {
                var words = sentences[i].Split(' ');

                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j].ToLower().Equals(WordSearcher.Word)) counter++;
                }
            }

            return counter;
        }

        //Anropa en lista med tidigare sökta ord, om den finns med i listan return true, annars false
        public bool CheckForDuplicateWord() => SearchedWords.Contains(WordSearcher.Word);
    }
}
