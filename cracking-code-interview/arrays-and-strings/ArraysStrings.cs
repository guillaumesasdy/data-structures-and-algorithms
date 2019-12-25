using System;

namespace CrackingCodeInterview.ArraysAndStrings
{
    public class ArraysStrings
    {
        static void Main()
        {
            bool isUniquePassing = IsUniqueTests(IsUnique);
            Console.WriteLine($"{nameof(IsUnique)} tests returns: {isUniquePassing}");

            bool isUniqueAsciiPassing = IsUniqueAsciiTests(IsUniqueAscii);
            Console.WriteLine($"{nameof(IsUniqueAscii)} tests returns: {isUniqueAsciiPassing}");
        }

        private static bool IsUniqueAsciiTests(Func<string, bool> tested)
        {
            string allTheSame = "aaaaaaa";
            bool allTheSameExpectedReturn = false;

            string allDifferent = "abcxyz";
            bool allDifferentExpectedReturn = true;

            string beginEndWithSame = ".azerty.";
            bool beginEndWithSameExpectedReturn = false;

            string allDifferentWithNonAlphaNumericalCharacters = string.Join("", new char[] { '\x0F', '\x0C'}) + "az";
            bool allDifferentWithNonAlphaNumericalCharactersExpectedReturn = true;

            string duplicatedNonAlphaNumericalCharacters = string.Join("", new char[] { '\x0F', '\x0C', '\x0F'}) + "az";
            bool duplicatedNonAlphaNumericalCharactersExpectedReturn = false;

            return tested(allTheSame) == allTheSameExpectedReturn
                && tested(allDifferent) == allDifferentExpectedReturn
                && tested(beginEndWithSame) == beginEndWithSameExpectedReturn
                && tested(allDifferentWithNonAlphaNumericalCharacters) 
                    == allDifferentWithNonAlphaNumericalCharactersExpectedReturn
                && tested(duplicatedNonAlphaNumericalCharacters)
                    == duplicatedNonAlphaNumericalCharactersExpectedReturn;
        }

        private static bool IsUniqueAscii(string s)
        {
            byte[] bitsAlreadySeen = new byte[16];

            for(int i=0; i<s.Length; i++)
            {
                var searched = (byte) s[i];

                byte indexLookup = (byte) (searched / 8);
                byte bitLookup = (byte) (1 << (searched % 8));

                if (bitsAlreadySeen[indexLookup] == bitLookup)
                    return false;
                
                bitsAlreadySeen[indexLookup] |= bitLookup;
            }

            return true;
        }

        private static bool IsUniqueTests(Func<string, bool> tested)
        {
            // todo add tests with characters outside ASCII

            return IsUniqueAsciiTests(tested);
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