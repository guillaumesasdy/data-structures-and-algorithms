using System;

namespace Practice.CrackingCode.ArraysAndStrings
{
    public class RotateMatrix
    {
        public void Explain()
        {
            string s = "Rotate a square matrix by 90 degrees.";

            Console.WriteLine(s);
        }

        public void Run()
        {
            PrintTests();
        }

        private void PrintTests()
        {
            int[,] two = new int[,]
            {
                { 1,    2 },
                { 3,    4 }
            };
            PrintMatrix(two);

            Console.WriteLine("Rotated: ");
            RotateInPlace(ref two);
            PrintMatrix(two);
            Console.WriteLine();

            int[,] three = new int[,]
            {
                { 1,    2,  3 },
                { 4,    5,  6 },
                { 7,    8,  9 }
            };
            PrintMatrix(three);

            Console.WriteLine("Rotated: ");
            RotateInPlace(ref three);
            PrintMatrix(three);
            Console.WriteLine();

            int[,] four = new int[,]
            {
                { 1,    2,  3,  4 },
                { 5,    6,  7,  8 },
                { 9,    10, 11, 12 },
                { 13,   14, 15, 16 }
            };
            PrintMatrix(four);

            Console.WriteLine("Rotated: ");
            RotateInPlace(ref four);
            PrintMatrix(four);
            Console.WriteLine();
        }

        private void PrintMatrix(in int[,] m)
        {
            for(int i=0; i<m.GetLength(0); i++)
            {
                for(int j=0; j<m.GetLength(1); j++)
                {
                    Console.Write("\t" + m[i,j]);
                }
                Console.WriteLine();
            }
        }

        void RotateInPlace(ref int[,] m)
        {
            int n = m.GetLength(0);
            int lastIdx = n - 1;
            int maxDist = (int) (n / 2);
            
            for(int d=0; d<maxDist; d++)
            for(int i=d; i<lastIdx-d; i++)
            {
                int tmp = m[d, i];
                m[d, i] = m[lastIdx - i, d];
                m[lastIdx - i, d] = m[lastIdx - d, lastIdx - i];
                m[lastIdx - d, lastIdx - i] = m[i, lastIdx - d];
                m[i, lastIdx - d] = tmp;
            }
        }
    }
}