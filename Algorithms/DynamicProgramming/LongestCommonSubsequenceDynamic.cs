using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    public class LongestCommonSubsequenceDynamic
    {
        private enum Source
        {
            Unknown = 0,
            First,
            Second,
            Both
        }

        public string FindLongestCommonSubsequence(string s1, string s2)
        {
            if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
            {
                return String.Empty;
            }

            var lengths = new int[s1.Length, s2.Length];
            var sources = new Source[s1.Length, s2.Length];

            for (int i = 0; i < s1.Length; i++)
            {
                for (int j = 0; j < s2.Length; j++)
                {
                    if (s1[i] == s2[j])
                    {
                        lengths[i, j] = (i == 0 || j == 0) ? 1 : lengths[i - 1, j - 1] + 1;
                        sources[i, j] = Source.Both;
                    }
                    else
                    {
                        int length1 = i == 0 ? 0 : lengths[i - 1, j];
                        int length2 = j == 0 ? 0 : lengths[i, j - 1];

                        if (length1 > length2)
                        {
                            lengths[i, j] = length1;
                            sources[i, j] = Source.First;
                        }
                        else
                        {
                            lengths[i, j] = length2;
                            sources[i, j] = Source.Second;
                        }
                    }
                }
            }

            int index1 = s1.Length - 1;
            int index2 = s2.Length - 1;
            var substring = new char[lengths[index1, index2]];
            int indexSubstring = substring.Length - 1;

            while (index1 >= 0 && index2 >= 0)
            {
                switch (sources[index1, index2])
                {
                    case Source.Unknown:
                        break;
                    case Source.Both:
                        substring[indexSubstring] = s1[index1];
                        indexSubstring--;
                        index1--;
                        index2--;
                        break;
                    case Source.First:
                        index1--;
                        break;
                    case Source.Second:
                        index2--;
                        break;
                }
            }

            return new string(substring);
        }
    }
}
