using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class BubbleSorter<T> where T : IComparable
    {
        public void BubbleSort(T[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = items.Length - 1; j > i; j--)
                {
                    if (Comparer<T>.Default.Compare(items[j], items[j - 1]) < 0)
                    {
                        T item = items[j];
                        items[j] = items[j - 1];
                        items[j - 1] = item;
                    }
                }
            }
        }
    }
}
