using System;

namespace Practice.CrackingCode.ArraysAndStrings
{
    public class OneAway
    {
        public void Explain()
        {
            string s = "Find if a two strings are one edit away.";
            s += Environment.NewLine + "An edit may be adding, removing, replacing a character.";

            Console.WriteLine(s);
        }

        public void Run()
        {
            bool isOneEditAwayPassing = Test();
            Console.WriteLine($"{nameof(IsOneEditAway)} tests returns: {isOneEditAwayPassing}");
        }

        bool Test()
        {
            bool oneAddInMiddlePassing = IsOneEditAway(
                "pale", "ple") == true;

            bool oneRemoveAtEndPassing = IsOneEditAway(
                "pales", "pale") == true;

            bool oneReplaceAtBegPassing = IsOneEditAway(
                "bale", "pale") == true;

            bool twoReplaceReturnsFalse = IsOneEditAway(
                "pale", "bake") == false;

            return oneAddInMiddlePassing
                && oneRemoveAtEndPassing
                && oneReplaceAtBegPassing
                && twoReplaceReturnsFalse;
        }

        bool IsOneEditAway(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) > 1)
                return false;

            bool editMustBeAdding = false;
            
            // swap s1 and s2 if s2 is shorter than s1 because
            // we want to loop over the shortest string
            if (s1.Length != s2.Length)
            {
                if (s2.Length < s1.Length)
                {
                    string tmp = s2;
                    s2 = s1;
                    s1 = tmp;
                }

                editMustBeAdding = true;
            }

            bool edited = false;
            int i = 0, j = 0;
            while (i < s1.Length)
            {
                if (s1[i] != s2[j])
                {
                    if (edited)
                        return false;
                    
                    edited = true;
                    
                    if (editMustBeAdding)
                    {
                        j++;
                        continue;
                    }
                }

                i++;
                j++;
            }

            return true;
        }
    }
}