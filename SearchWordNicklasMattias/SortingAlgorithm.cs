using System.Collections.Generic;

namespace SearchWordNicklasMattias
{
    public static class SortingAlgorithm
    {
        public static List<string> Quick(List<string> unsorted, int low, int high)
        {
            if (unsorted == null || unsorted.Count == 0) return new List<string>() {"Whops, something went wrong!"};
            else if (high == 0) high = unsorted.Count - 1;
            int i = low;
            int j = high;
            var pivot = unsorted[low].ToLower();

            while (i <= j)
            {
                while (unsorted[i].CompareTo(pivot) <= 0 && i < high && j >= i)
                {
                    i++;
                }

                while (unsorted[j].CompareTo(pivot) >= 0 && j > low && j >= i)
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
