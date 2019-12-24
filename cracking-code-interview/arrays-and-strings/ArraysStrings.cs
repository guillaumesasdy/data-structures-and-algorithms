using System;

namespace CrackingCodeInterview.ArraysAndStrings
{
    public class ArraysStrings
    {
        static void Main()
        {
            bool isUniquePassing = IsUniqueTests();
            Console.WriteLine($"{nameof(IsUnique)} tests returns: {isUniquePassing}");
        }

        private static bool IsUniqueTests()
        {
            string allTheSame = "aaaaaaa";
            bool allTheSameExpectedReturn = false;

            string allDifferent = "abcxyz";
            bool allDifferentExpectedReturn = true;

            string beginEndWithSame = ".azerty.";
            bool beginEndWithSameExpectedReturn = false;

            return IsUnique(allTheSame) == allTheSameExpectedReturn
                && IsUnique(allDifferent) == allDifferentExpectedReturn
                && IsUnique(beginEndWithSame) == beginEndWithSameExpectedReturn;
        }

        private static bool IsUnique(string s)
        {
            char[] chars = s.ToCharArray();
            // todo check implementation details of ToCharArray() and its complexity

            bool[] seen = new bool[char.MaxValue - char.MinValue];

            for(int i=0; i<chars.Length; i++)
            {
                int charIndex = (int) chars[i];

                if (seen[charIndex])
                    return false;

                seen[charIndex] = true;
            }

            return true;
        }
    }
}