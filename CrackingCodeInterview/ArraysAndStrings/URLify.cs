using System;

namespace CrackingCodeInterview.ArraysAndStrings
{
    public class URLify
    {
        public static void Explain()
        {
            string s = "Replace space characters by the sequence '%20' in an array of chars." + Environment.NewLine;
            s += "The given array of chars must be changed in place, given the final length of the array.";

            Console.WriteLine(s);
        }

        public static void Run()
        {
            bool URLifyInPlacePassing = Test();
            Console.WriteLine(nameof(URLifyInPlace) + " tests returns: " + URLifyInPlacePassing);
        }

        private static bool Test()
        {
            char[] empty = "".ToCharArray();
            URLifyInPlace(ref empty);
            string emptyExpectedResult = "";

            char[] noSpace = "abc".ToCharArray();
            URLifyInPlace(ref noSpace);
            string noSpaceExpectedResult = "abc";

            char[] spaceInTheMiddle = "a b  ".ToCharArray();
            URLifyInPlace(ref spaceInTheMiddle);
            string spaceInTheMiddleExpectedResult = "a%20b";

            char[] multipleSpacesAtBeginning = "   ab      ".ToCharArray();
            URLifyInPlace(ref multipleSpacesAtBeginning);
            string multipleSpacesAtBeginningExpectedResult = "%20%20%20ab";

            char[] spaceAtEnd = "ab   ".ToCharArray();
            URLifyInPlace(ref spaceAtEnd);
            string spaceAtEndExpectedResult = "ab%20";

            return empty.ToString() == emptyExpectedResult
                && noSpace.ToString() == noSpaceExpectedResult
                && spaceInTheMiddle.ToString() == spaceInTheMiddleExpectedResult
                && multipleSpacesAtBeginning.ToString() == multipleSpacesAtBeginningExpectedResult
                && spaceAtEnd.ToString() == spaceAtEndExpectedResult;
        }

        static void URLifyInPlace(ref char[] chars)
        {
            for(int i=0; i<chars.Length; i++)
            if (chars[i] == ' ')
            {
                chars[i + 4] = chars[i + 2];
                chars[i + 3] = chars[i + 1];
                chars[i + 2] = '0';
                chars[i + 1] = '2';
                chars[i + 0] = '%';
            }
        }
    }
}