using System;
using System.Collections.Generic;
using MySolutions.Common;

namespace MySolutions.LeetCode
{
    public class CountVowelsPermutation : IExecutable
    {
        public void Explain()
        {
            Console.WriteLine("https://leetcode.com/problems/count-vowels-permutation/");
        }

        public void Run()
        {
            int n = 26;

            Console.Write("Solution for n = 26: ");
            Console.WriteLine(Node.CountAllPerms(n) % (1000000000 + 7));
        }

        private class Node
        {
            static Dictionary<int, int[]> Next { get; } = new Dictionary<int, int[]>()
            {
                { 1, new int[] { 2 } },
                { 2, new int[] { 1, 3 } },
                { 3, new int[] { 1, 2, 4, 5 } },
                { 4, new int[] { 3, 5 } },
                { 5, new int[] { 1 } }
            };

            int LeafDepth;

            int Depth;

            int Value;

            public Node(int depth, int leafDepth, int value)
            {
                Depth = depth;
                LeafDepth = leafDepth;
                Value = value;
            }

            public static int CountAllPerms(int leafDepth)
            {
                int sum = 0;

                foreach(int value in Next.Keys)
                {
                    Node first = new Node(1, leafDepth, value);

                    sum += first.RecursiveCountChildrenPerms();
                }

                return sum;
            }

            int RecursiveCountChildrenPerms()
            {
                if (Depth == LeafDepth)
                    return 1;

                int sumPermutationsOfChildren = 0;

                foreach(int childValue in Next[Value])
                {
                    Node child = new Node(Depth + 1, LeafDepth, childValue);

                    sumPermutationsOfChildren += child.RecursiveCountChildrenPerms();
                }

                return sumPermutationsOfChildren;
            }
        }
    }
}