using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SearchWordNicklasMattias
{
    /// <summary>
    /// Class responsible for reading the documents and adding the content to a data structure.
    /// Reading is done by the usage of a stream reader.
    /// </summary>
    public static class DB
    {
        //List with all docs. Each doc contains document name and List with all the rows (from stream reader)
        public static List<(string, List<string>)> Docs = new List<(string, List<string>)>();
        public static List<string> List1000 = new List<string>();
        public static List<string> List1500 = new List<string>();
        public static List<string> List3000 = new List<string>();

        /// <summary>
        /// On first run, reads all the documents and saves them.
        /// </summary>
        public static void GetStream()
        {
            if (Docs.Count <= 0) FillLists();
        }

        /// <summary>
        /// Creates each document with Title, content.
        /// Reading of the document occures here.
        /// </summary>
        private static void FillLists()
        {
            var folder = "ShortStories/";
            var File1000 = $@"{folder}1000Words.txt";
            var File1500 = $@"{folder}1500Words.txt";
            var File3000 = $@"{folder}3000Words.txt";

            var folderPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            folderPath = folderPath.Remove(folderPath.Length - 10);

            var path1000 = Path.Combine(folderPath, File1000);
            var path1500 = Path.Combine(folderPath, File1500);
            var path3000 = Path.Combine(folderPath, File3000);

            var pathList = new List<string>() { path1000, path1500, path3000};

            Docs.Add(("1000Words.txt", List1000));
            Docs.Add(("1500Words.txt", List1500));
            Docs.Add(("3000Words.txt", List3000));
        
            for (int i = 0; i < Docs.Count; i++)
            {
                using (StreamReader sr = new StreamReader(pathList[i]))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Docs[i].Item2.Add(line);
                    }
                }
            }
        }
    }
}
