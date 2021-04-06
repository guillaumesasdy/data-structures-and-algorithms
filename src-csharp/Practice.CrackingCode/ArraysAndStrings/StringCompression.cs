using System;
using System.Text;

namespace Practice.CrackingCode.ArraysAndStrings
{
    public class StringCompression
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

            bool compressLastCharsPassing = Compress("abbbb") == "a1b4";

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
            if (s.Length < 3)
                return s;

            StringBuilder compressed = new StringBuilder();
            int limit = s.Length;

            char read = s[0];
            int count = 0;
            int idx = 0;
            while (idx < s.Length)
            {
                if (s[idx] != read)
                {
                    if (AppendTo(compressed, read, count, limit) == false)
                        return s;

                    count = 1;
                    read = s[idx];
                }
                else count++;

                idx++;
            }

            // last flush
            if (AppendTo(compressed, read, count, limit) == false)
                return s;

            return compressed.ToString();
        }

        bool AppendTo(StringBuilder sb, char c, int count, int limit)
        {
            sb.Append(c);
            sb.Append(count.ToString());

            if (sb.Length >= limit)
                return false;
            
            return true;
        }
    }
}