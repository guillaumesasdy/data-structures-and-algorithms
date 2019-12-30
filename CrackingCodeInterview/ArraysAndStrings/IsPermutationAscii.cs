using System;

namespace CrackingCodeInterview.ArraysAndStrings
{
    public class IsPermutationAscii
    {
        static readonly int NbAsciiChars = 128;

        public static void Explain()
        {
            string s = "Find if a two ASCII strings can be permuted.";

            Console.WriteLine(s);
        }

        public static void Run()
        {
            bool isPermutationAsciiWithArrayOfIntegersPassing = Test();
            Console.WriteLine(nameof(IsPermutationAsciiWithArrayOfIntegers) + " tests returns: "
                + isPermutationAsciiWithArrayOfIntegersPassing);
        }

        private static bool Test()
        {
            bool twoNull = IsPermutationAsciiWithArrayOfIntegers(null, null);
            bool twoNullExpectedReturn = false;

            bool nullAndEmpty = IsPermutationAsciiWithArrayOfIntegers("", null);
            bool nullAndEmptyExpectedReturn = false;

            bool differentLength = IsPermutationAsciiWithArrayOfIntegers("a", "aa");
            bool differentLengthExpectedReturn = false;

            bool differentCountForOneChar = IsPermutationAsciiWithArrayOfIntegers("abcc", "aabc");
            bool differentCountForOneCharExpectedReturn = false;

            bool sameCharacterCount = IsPermutationAsciiWithArrayOfIntegers("bbaabbcc", "ccbbbbaa");
            bool sameCharacterCountExpectedReturn = true;

            return twoNull == twoNullExpectedReturn
                && nullAndEmpty == nullAndEmptyExpectedReturn
                && differentLength == differentLengthExpectedReturn
                && differentCountForOneChar == differentCountForOneCharExpectedReturn
                && sameCharacterCount == sameCharacterCountExpectedReturn;
        }

        static bool IsPermutationAsciiWithArrayOfIntegers(string s1, string s2)
        {
            if (s1 == null || s2 == null)
                return false;

            if (s1.Length != s2.Length)
                return false;

            int[] diffs = new int[NbAsciiChars];
            for (int i=0; i<s1.Length; i++)
            {
                diffs[s1[i]]++;
                diffs[s2[i]]--;
            }

            for(int i=0; i<diffs.Length; i++)
            if (diffs[i] != 0)
                return false;

            return true;
        }
    }
}