using System;

namespace CrackingCodeInterview.ArraysAndStrings
{
    public class StringCompression : IExecutable
    {
        public void Explain()
        {
            string s = "Basic string compression using the counts of repeated characters.";
            s += Environment.NewLine + "ie aabcccccaaa would become a2b1c5a3.";
            s += Environment.NewLine + "Return the original string if the compressed string is not smaller.";

            Console.WriteLine(s);
        }

        public void Run()
        {
            bool compressPassing = Test();
            Console.WriteLine($"{nameof(Compress)} tests returns: {compressPassing}");
        }

        bool Test()
        {
            bool examplePassing = Compress("aabcccccaaa") == "a2b1c5a3";

            bool sameTwoCharsPassing = Compress("aa") == "aa";

            bool twoDifferentCharsPassing = Compress("ab") == "ab";

            bool compressNoSmallerPassing = Compress("aab") == "aab";

            bool compressSmallestPassing = Compress("aaa") == "a3";

            bool compressLastCharsPassing = Compress("abbbb") == "a1b3";

            bool compressHundredCharsPassing = Compress(new String('a', 100) + "b") == "a100b1";

            return examplePassing
                && sameTwoCharsPassing
                && twoDifferentCharsPassing
                && compressNoSmallerPassing
                && compressSmallestPassing
                && compressLastCharsPassing
                && compressHundredCharsPassing;
        }

        string Compress(string s)
        {
            throw new NotImplementedException();
        }
    }
}