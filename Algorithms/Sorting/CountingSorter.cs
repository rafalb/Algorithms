using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class CountingSorter
    {
        public int[] CountingSort(int[] items, int maxValue)
        {
            int[] itemCount = CalculateItemCount(items, maxValue);
            int[] predecessorCount = CountPredecessors(itemCount, maxValue);

            int[] sortedItems = SortCounted(items, predecessorCount);
            return sortedItems;
        }

        private int[] CalculateItemCount(int[] items, int maxValue)
        {
            int[] itemCount = new int[maxValue + 1];

            for (int i = 0; i < items.Length; i++)
            {
                int item = items[i];

                if (item < 0 || maxValue < item)
                {
                    throw new ArgumentOutOfRangeException(
                        String.Format("Item '{0}' at index {1} is out of the allowed range of 0-{2}.", item, i, maxValue));
                }

                itemCount[item]++;
            }

            return itemCount;
        }

        private int[] CountPredecessors(int[] itemCount, int maxValue)
        {
            int[] predecessorCount = new int[maxValue + 1];

            for (int i = 1; i < itemCount.Length; i++)
            {
                predecessorCount[i] = itemCount[i - 1] + predecessorCount[i - 1];
            }

            return predecessorCount;
        }

        private static int[] SortCounted(int[] items, int[] predecessorCount)
        {
            var sortedItems = new int[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                int item = items[i];
                int sortedIndex = predecessorCount[item];
                sortedItems[sortedIndex] = item;
            }

            return sortedItems;
        }
    }
}
