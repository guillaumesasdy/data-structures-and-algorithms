using System;

namespace CrackingCodeInterview.ArraysAndStrings
{
    public class OneAway
    {
        public static void Explain()
        {
            string s = "Find if a two strings are one edit away.";
            s += Environment.NewLine + "An edit may be adding, removing, replacing a character.";

            Console.WriteLine(s);
        }

        public static void Run()
        {
            bool isOneEditAwayPassing = Test();
            Console.WriteLine($"{nameof(IsOneEditAwayPassing)} tests returns: {isOneEditAwayPassing}");
        }

        private static bool Test()
        {
            bool oneAddInMiddlePassing = IsOneEditAwayPassing(
                "pale", "ple") == true;

            bool oneRemoveAtEndPassing = IsOneEditAwayPassing(
                "pales", "pale") == true;

            bool oneReplaceAtBegPassing = IsOneEditAwayPassing(
                "bale", "pale") == true;

            bool twoReplaceReturnsFalse = IsOneEditAwayPassing(
                "pale", "bake") == false;

            return oneAddInMiddlePassing
                && oneRemoveAtEndPassing
                && oneReplaceAtBegPassing
                && twoReplaceReturnsFalse;
        }

        static bool IsOneEditAwayPassing(string s1, string s2)
        {
            throw new NotImplementedException();
        }
    }
}