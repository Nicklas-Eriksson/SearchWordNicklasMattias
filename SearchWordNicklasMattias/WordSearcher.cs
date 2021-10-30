﻿using System.Collections.Generic;
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

        /// <summary>
        /// Returns the result when user searches for a specific word in the txt documents.
        /// </summary>
        /// <param name="searchWord">Word for searching.</param>
        /// <returns>Results.</returns>
        public string GetResultFromSearchWord(string searchWord)
        {
            WordSearcher.Word = searchWord;

            //If results already exists
            if (CheckForDuplicateWord())
            {
                return ResultString;
            }
            else //If results does not exists prior to current search.
            {
                return ExtractData(MainTree);
            }
        }

        /// <summary>
        /// Extracts data from the documents when user searches for matches on a specific word.
        /// </summary>
        /// <param name="tree">Active tree to be filled up with nodes containing results.</param>
        /// <returns>Result.</returns>
        private string ExtractData(Tree tree)
        {
            var sortingDict = new Dictionary<string, (string, int)>();

            foreach (var document in DB.Docs)
            {
                var word = WordSearcher.Word;
                var docTitle = document.Item1;
                var rows = SearchDocRowsForMatch(document.Item2);
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
                    $"______________________________\n"
                    ;
                sortingDict.Add(result, (word, wordCount));
            }

            SearchedWords.Add(Word);
            ResultString = SortResultsForInsertion(sortingDict);
            tree.AddNode(tree.Root, tree.AddNode(ResultString));

            return ResultString;
        }

        /// <summary>
        /// Sorts the results prior to adding it into the tree.
        /// After sorting the result with most hits gets sorted to the top.
        /// </summary>
        /// <param name="dict">Dictionary to be sorted.</param>
        /// <returns>Results sorted by word occurence frequency.</returns>
        public string SortResultsForInsertion(Dictionary<string, (string, int)> dict)
        {
            string resultString = null;
            var sortByValue = from entry in dict orderby entry.Value descending select entry;

            foreach (var item in sortByValue)
            {
                resultString += item.Key;
            }

            return resultString;
        }

        /// <summary>
        /// Sorts a requested document by its words in order based on how many words user wants to display.
        /// Example: Also, Be, Can't, Do.
        /// </summary>
        /// <param name="index">Chosen document.</param>
        /// <param name="numberOfWords">Number of words user wants to display.</param>
        /// <returns>List of sorted words from document.</returns>
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
        /// <param name="sentences">Sentences to be split into words.</param>
        /// <returns>List of words.</returns>
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
        /// <param name="doc">Document to be searched.</param>
        /// <returns>List with rows containing search word..</returns>
        private List<string> SearchDocRowsForMatch(List<string> doc)
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
        /// <param name="rows">Rows to be splited into sentences.</param>
        /// <returns>List with sentences containing search word.</returns>
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
        /// Finds all the sentences that contains the search word.
        /// </summary>
        /// <param name="sentence">List of sentences to be searched for match.</param>
        /// <returns>List of sentence containing the exact match of the word.</returns>
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
        /// <param name="sentences">Sentences containing search word.</param>
        /// <returns>Number of words found.</returns>
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

       /// <summary>
       /// Checks the list of prior search words.
       /// </summary>
       /// <returns>True if word is in list.</returns>
        public bool CheckForDuplicateWord() => SearchedWords.Contains(WordSearcher.Word);
    }
}
