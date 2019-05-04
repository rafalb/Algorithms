using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class InsertionSorter<T> where T : IComparable
    {
        public void InsertionSort(T[] items)
        {
            for (int i = 1; i < items.Length; i++)
            {
                T itemToInsert = items[i];
                int j = i - 1;

                while (j >= 0 && Comparer<T>.Default.Compare(itemToInsert, items[j]) < 0)
                {
                    items[j + 1] = items[j];
                    j--;
                }

                items[j + 1] = itemToInsert;
            }
        }
    }
}
