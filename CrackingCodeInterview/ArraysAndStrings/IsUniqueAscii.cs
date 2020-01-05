using System;
using MySolutions.Common;

namespace MySolutions.CrackingCodeInterview.ArraysAndStrings
{
    public class IsUniqueAscii : IExecutable
    {
        static readonly int NbAsciiChars = 128;

        public void Explain()
        {
            string s = "Find if a string contains only unique ASCII characters.";

            Console.WriteLine(s);
        }

        public void Run()
        {
            bool isUniqueAsciiWithArrayOfBoolsPassing = Test(IsUniqueAsciiWithArrayOfBools);
            Console.WriteLine($"{nameof(IsUniqueAsciiWithArrayOfBools)} tests returns: {isUniqueAsciiWithArrayOfBoolsPassing}");

            bool isUniqueAsciiWithArrayOfBytesPassing = Test(IsUniqueAsciiWithArrayOfBytes);
            Console.WriteLine($"{nameof(IsUniqueAsciiWithArrayOfBytes)} tests returns: {isUniqueAsciiWithArrayOfBytesPassing}");
        }

        bool Test(Func<string, bool> tested)
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

        bool IsUniqueAsciiWithArrayOfBytes(string s)
        {
            byte[] seen = new byte[NbAsciiChars / 8];

            for(int i=0; i<s.Length; i++)
            {
                byte charIndex = (byte) s[i];

                byte byteIndex = (byte) (charIndex / 8);
                byte byteFlag = (byte) (1 << (charIndex % 8));

                if ((seen[byteIndex] & byteFlag) > 0)
                    return false;
                
                seen[byteIndex] |= byteFlag;
            }

            return true;
        }

        bool IsUniqueAsciiWithArrayOfBools(string s)
        {
            bool[] seen = new bool[NbAsciiChars];

            for(int i=0; i<s.Length; i++)
            {
                byte charIndex = (byte) s[i];

                if (seen[charIndex])
                    return false;

                seen[charIndex] = true;
            }

            return true;
        }
    }
}