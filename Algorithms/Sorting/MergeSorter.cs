using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public class MergeSorter<T> where T : IComparable
    {
        public void MergeSort(T[] items)
        {
            MergeSort(items, 0, items.Length - 1);
        }

        private void MergeSort(T[] items, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int splitIndex = (startIndex + endIndex) / 2;

                MergeSort(items, startIndex, splitIndex);
                MergeSort(items, splitIndex + 1, endIndex);

                Merge(items, startIndex, splitIndex, endIndex);
            }
        }

        private void Merge(T[] items, int startIndex, int splitIndex, int endIndex)
        {
            T[] items1 = CreateSubarray(items, startIndex, splitIndex);
            T[] items2 = CreateSubarray(items, splitIndex + 1, endIndex);

            int index1 = 0;
            int index2 = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                bool isItem1Next;

                if (index1 == items1.Length)
                {
                    isItem1Next = false;
                }
                else if (index2 == items2.Length)
                {
                    isItem1Next = true;
                }
                else
                {
                    isItem1Next = Comparer<T>.Default.Compare(items1[index1], items2[index2]) < 0;
                }
                
                if (isItem1Next)
                {
                    items[i] = items1[index1];
                    index1++;
                }
                else
                {
                    items[i] = items2[index2];
                    index2++;
                }
            }
        }

        private T[] CreateSubarray(T[] items, int startIndex, int endIndex)
        {
            var subarray = new T[endIndex - startIndex + 1];

            for (int i = 0; i < subarray.Length; i++)
            {
                subarray[i] = items[startIndex + i];
            }

            return subarray;
        }
    }
}
