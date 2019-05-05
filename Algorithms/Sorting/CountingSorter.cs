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
            int[] smallerOrEqualCount = CountSmallerOrEqualItems(itemCount, maxValue);

            int[] sortedItems = SortCounted(items, smallerOrEqualCount);
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

        private int[] CountSmallerOrEqualItems(int[] itemCount, int maxValue)
        {
            int[] smallerOrEqualCount = new int[maxValue + 1];

            for (int i = 1; i < itemCount.Length; i++)
            {
                smallerOrEqualCount[i] = itemCount[i] + smallerOrEqualCount[i - 1];
            }

            return smallerOrEqualCount;
        }

        private static int[] SortCounted(int[] items, int[] smallerOrEqualCount)
        {
            var sortedItems = new int[items.Length];

            for (int i = items.Length - 1; i >= 0; i--)
            {
                int item = items[i];
                int sortedIndex = smallerOrEqualCount[item] - 1;
                sortedItems[sortedIndex] = item;
                smallerOrEqualCount[item]--;
            }

            return sortedItems;
        }
    }
}
