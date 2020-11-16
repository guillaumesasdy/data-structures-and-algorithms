using System;
using MySolutions.Common;
using MySolutions.CrackingCodeInterview.SinglyLinkedList;
using List = MySolutions.CrackingCodeInterview.SinglyLinkedList.SinglyLinkedList;

namespace MySolutions.CrackingCodeInterview.LinkedList
{
    public class Intersection : IExecutable
    {
        public void Explain()
        {
            Console.WriteLine("Returns (k)th where the first list is intersected by the second list, or 0 if lists do not intersect.");
        }

        public void Run()
        {
            Console.WriteLine(nameof(NoIntersect) + " tests returns: " + NoIntersect());
            Console.WriteLine(nameof(IntersectFirstNodeOfSecondList) + " tests returns: " + IntersectFirstNodeOfSecondList());
            Console.WriteLine(nameof(IntersectSecondNodeOfFirstList) + " tests returns: " + IntersectSecondNodeOfFirstList());
        }

        bool NoIntersect()
        {
            var one = List.Build(new[] {'a', 'b', 'c', 'd', 'e'});
            var two = List.Build(new[] {'a', 'b', 'c', 'd', 'e'});

            return IntersectAt(one, two) == 0;
        }

        bool IntersectFirstNodeOfSecondList()
        {
            var one = List.Build(new[] {'a', 'b', 'c', 'd', 'e'});
            var two = one.Next.Next.Next; // points 'd'

            return IntersectAt(one, two) == 4;
        }
        
        bool IntersectSecondNodeOfFirstList()
        {
            var one = List.Build(new[] {'c', 'd'});
            var two = List.Build(new[] {'a', 'b'});
            two.Next.Next = one;

            return IntersectAt(one, two) == 1;
        }
        
        int IntersectAt(Node<char> one, Node<char> two)
        {
            int oneLength = GetTailAndLength(one, out Node<char> oneTail);
            int twoLength = GetTailAndLength(two, out Node<char> twoTail);

            if (oneTail != twoTail)
                return 0;

            int signedDifference = oneLength - twoLength;
            one = signedDifference > 0 ? SkipNodes(signedDifference, one) : one;
            two = signedDifference < 0 ? SkipNodes(-signedDifference, two) : two;

            int counter = 1;
            while (one != two)
            {
                one = one.Next;
                two = two.Next;
                counter++;
            }
            
            return (signedDifference > 0 ? signedDifference : 0) + counter;
        }

        int GetTailAndLength(Node<char> list, out Node<char> tail)
        {
            int counter = 1;

            while (list.Next != null)
            {
                list = list.Next;
                counter++;
            }

            tail = list;
            return counter;
        }

        Node<char> SkipNodes(int skip, Node<char> list)
        {
            while (skip-- > 0)
                list = list.Next;

            return list;
        }
    }
}
