using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    public class LongestCommonSubsequenceRecursive
    {
        public string FindLongestCommonSubsequence(string s1, string s2)
        {
            if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
            {
                return String.Empty;
            }
            else
            {
                if (s1.Last() == s2.Last())
                {
                    return FindLongestCommonSubsequence(s1.Substring(0, s1.Length - 1), s2.Substring(0, s2.Length - 1)) + s1.Last();
                }
                else
                {
                    string result1 = FindLongestCommonSubsequence(s1.Substring(0, s1.Length - 1), s2.Substring(0, s2.Length));
                    string result2 = FindLongestCommonSubsequence(s1.Substring(0, s1.Length), s2.Substring(0, s2.Length - 1));

                    return result1.Length > result2.Length ? result1 : result2;
                }
            }
        }
    }
}
