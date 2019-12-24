namespace CrackingCodeInterview.ArraysAndStrings
{
    public class ArraysStrings
    {
        static void Main()
        {

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