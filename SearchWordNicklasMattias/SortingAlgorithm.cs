using System.Collections.Generic;

namespace SearchWordNicklasMattias
{
    public static class SortingAlgorithm
    {
        /// <summary>
        /// Quick sort algorithm compares string values and puts them in alphabetical order.
        /// Recursion occures here.
        /// Recursion lets us garantee that nothing unwanted happens with the data.
        /// It lets us cut down on code and makes the code more easy to read.
        /// 
        /// The quicksort is a divide and conquer algorithm, it makes us of a pivot element of which
        /// it uses to compare all the other elements against it too see if it is higher or lower than the pivot.
        /// 
        /// In our qick sort, after comparing the first element to the pivot the method calls itself using a recursive
        /// call. Based on if the element was higher or lower than the pivot it gives the method, different values to
        /// adjust the i and j indexes used for scanning the data.
        /// </summary>
        /// <param name="unsorted"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static List<string> Quick(List<string> unsorted, int low, int high)
        {
            if (unsorted == null || unsorted.Count == 0) return new List<string>() 
            {
                "Whops, something went wrong!" 
            }; 

            else if (high == 0)
            {
                high = unsorted.Count - 1;
            };

            int i = low;
            int j = high;
            var pivot = unsorted[(i + j) / 2];

            while (i <= j)
            {
                while (unsorted[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (unsorted[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = unsorted[i];
                    unsorted[i] = unsorted[j];
                    unsorted[j] = temp;
                    i++;
                    j--;
                }
            }

            if (low < j)
            {
                Quick(unsorted, low, j);
            }

            if (i < high)
            {
                Quick(unsorted, i, high);
            }

            return unsorted;
        }
    }
}
