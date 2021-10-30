using System.Collections.Generic;

namespace SearchWordNicklasMattias
{
    public static class SortingAlgorithm
    {
        /// <summary>
        /// Quick sort algorithm compares string values and puts them in alphabetical order.
        /// </summary>
        /// <param name="unsorted"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static List<string> Quick(List<string> unsorted, int low, int high)
        {
            if (unsorted == null || unsorted.Count == 0) return new List<string>() { "Whops, something went wrong!" };
            else if (high == 0) high = unsorted.Count - 1;
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
