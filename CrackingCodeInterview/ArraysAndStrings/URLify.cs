using System;
using System.Diagnostics;

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

            char[] spaceBegAndEnd = " a     ".ToCharArray();
            URLifyInPlace(ref spaceBegAndEnd);
            string spaceBegAndEndExpectedResult = "%20a%20";

            return empty.ToString() == emptyExpectedResult
                && noSpace.ToString() == noSpaceExpectedResult
                && spaceInTheMiddle.ToString() == spaceInTheMiddleExpectedResult
                && multipleSpacesAtBeginning.ToString() == multipleSpacesAtBeginningExpectedResult
                && spaceAtEnd.ToString() == spaceAtEndExpectedResult
                && spaceBegAndEnd.ToString() == spaceBegAndEndExpectedResult;
        }


        static void URLifyInPlace(ref char[] chars)
        {
            // at least 3 chars are needed to store %20
            if (chars.Length < 3)
                return;

            // first find the index of the "real" last character
            int lastIdx = chars.Length - 1;
            int i = -1;
            do
            {
                i++;
                if (chars[i] == ' ')
                    lastIdx -= 2;
            } while (i != lastIdx);

            // then write in reverse direction the urlify string
            int end = chars.Length - 1;
            while (i >= 0)
            {
                if (chars[i] == ' ')
                {
                    chars[end] = '0';
                    chars[end - 1] = '2';
                    chars[end - 2] = '%';
                    end -= 2;
                }
                else 
                    chars[end] = chars[i];

                i--;
                end--;
            }
        }
    }
}