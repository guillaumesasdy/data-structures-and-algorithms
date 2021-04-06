using System;
using Practice.DataStructures;
using List = Practice.DataStructures.SinglyLinkedList;

namespace Practice.CrackingCode.LinkedList
{
    public class ReturnKthLast
    {
        public void Explain()
        {
            Console.WriteLine("Return the (k)th last element before the end of the list.");
        }

        public void Run()
        {
            bool returnKthLastWithRunnersPassing = Test();
            Console.WriteLine(nameof(ReturnKthLastWithRunners) + " tests returns: "
                + returnKthLastWithRunnersPassing);
        }

        bool Test()
        {
            var singleElement = List.Build<char>(new [] { 'a' });

            var lastInTwo = List.Build<char>(new [] { 'a', 'b' });

            var twoBeforeLastInFour = List.Build<char>(new [] { 'a', 'b', 'c', 'd' });

            return ReturnKthLastWithRunners(singleElement, 1).Value == 'a'
                && ReturnKthLastWithRunners(lastInTwo, 1).Value == 'b'
                && ReturnKthLastWithRunners(twoBeforeLastInFour, 2).Value == 'c';
        }

        Node<char> ReturnKthLastWithRunners(Node<char> head, int k)
        {
            var slow = head;
            var fast = head;

            while (k != 0)
            {
                fast = fast.Next;
                k--;
            }

            while(fast != null)
            {
                fast = fast.Next;
                slow = slow.Next;
            }

            return slow;
        }
    }
}