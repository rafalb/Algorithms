using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming
{
    public class LongestCommonSubsequenceBruteForce
    {
        public string FindLongestCommonSubsequence(string s1, string s2)
        {
            string longerString = s1.Length > s2.Length ? s1 : s2;
            string shorterString = s1.Length > s2.Length ? s2 : s1;

            int subsequenceLength = shorterString.Length;
            string longestSubsequence = String.Empty;
            bool found = false;
            bool[] charactersChosen = new bool[shorterString.Length];

            for (int i = 0; i < shorterString.Length; i++)
            {
                charactersChosen[i] = true;
            }

            bool allChecked = charactersChosen.Length == 0;

            while (!found && !allChecked)
            {
                string candidate = CreateSubstring(shorterString, charactersChosen);
                found = IsSubsequence(candidate, longerString);

                if (found)
                {
                    longestSubsequence = candidate;
                }
                else
                {
                    allChecked = !PrepareNextPermutation(charactersChosen);
                }
            }

            return longestSubsequence;
        }

        private bool PrepareNextPermutation(bool[] values)
        {
            int index = values.Length - 1;

            while (index >= 0 && !values[index])
            {
                index--;
            }

            if (index < 0)
            {
                return false;
            }
            else
            {
                values[index] = false;
                index++;

                while (index < values.Length)
                {
                    values[index] = true;
                    index++;
                }

                return true;
            }
        }

        private string CreateSubstring(string original, bool[] charactersChosen)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < original.Length; i++)
            {
                if (charactersChosen[i])
                {
                    result.Append(original[i]);
                }
            }

            return result.ToString();
        }

        private bool IsSubsequence(string candidate, string text)
        {
            int charsFound = 0;
            int index = 0;

            while (charsFound < candidate.Length && index < text.Length)
            {
                if (candidate[charsFound] == text[index])
                {
                    charsFound++;
                }

                index++;
            }

            return charsFound == candidate.Length;
        }
    }
}
