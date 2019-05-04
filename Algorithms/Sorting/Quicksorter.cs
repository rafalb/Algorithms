using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class Quicksorter<T> where T : IComparable
    {
        public void Quicksort(T[] items)
        {
            Quicksort(items, 0, items.Length - 1);
        }

        private void Quicksort(T[] items, int startIndex, int endIndex)
        {
            if (endIndex > startIndex)
            {
                int splitIndex = Split(items, startIndex, endIndex);

                Quicksort(items, startIndex, splitIndex - 1);
                Quicksort(items, splitIndex + 1, endIndex);
            }
        }

        private int Split(T[] items, int startIndex, int endIndex)
        {
            int splitIndex = startIndex;
            T splitItem = items[endIndex];

            for (int i = startIndex; i < endIndex; i++)
            {
                if (Comparer<T>.Default.Compare(items[i], splitItem) < 0)
                {
                    Swap(items, splitIndex, i);
                    splitIndex++;
                }
            }

            Swap(items, splitIndex, endIndex);

            return splitIndex;
        }

        private void Swap(T[] items, int index1, int index2)
        {
            T item = items[index1];
            items[index1] = items[index2];
            items[index2] = item;
        }
    }
}
