using System;
using Practice.DataStructures;
using List = Practice.DataStructures.SinglyLinkedList;

namespace Practice.CrackingCode.LinkedList
{
    public class RemoveDups
    {
        public void Explain()
        {
            Console.WriteLine("Remove duplicated values in a singly linked list.");
        }

        public void Run()
        {
            bool isRemoveDupsWithHashtablePassing = Test(RemoveDupsWithHashtable);
            Console.WriteLine($"{nameof(RemoveDupsWithHashtable)} tests returns: {isRemoveDupsWithHashtablePassing}");

            bool isRemoveDupsWithRunnersPassing = Test(RemoveDupsWithRunners);
            Console.WriteLine($"{nameof(RemoveDupsWithRunners)} tests returns: {isRemoveDupsWithRunnersPassing}");
        }

        bool Test(Action<Node<char>> tested)
        {
            var twoDuplicatesList = List.Build<char>(new [] { 'a', 'a' });
            tested(twoDuplicatesList);
            var twoDuplicatesListExpectedResult = List.Build<char>(new [] { 'a' });

            var threeDuplicatesList = List.Build<char>(new [] { 'a', 'a', 'a' });
            tested(threeDuplicatesList);
            var threeDuplicatesListExpectedResult = List.Build<char>(new [] { 'a' });

            var duplicatedAtEnd = List.Build<char>(new [] { 'a', 'b', 'b' });
            tested(duplicatedAtEnd);
            var duplicatedAtEndExpectedResult = List.Build<char>(new [] { 'a', 'b' });

            var noDuplicate = List.Build<char>(new [] { 'a', 'b', 'c' });
            tested(noDuplicate);
            var noDuplicateExpectedResult = List.Build<char>(new [] { 'a', 'b', 'c' });

            var noDuplicateInMiddle = List.Build<char>(new [] { 'a', 'b', 'a' });
            tested(noDuplicateInMiddle);
            var noDuplicateInMiddleExpectedResult = List.Build<char>(new [] { 'a', 'b' });

            return List.Equals(twoDuplicatesList, twoDuplicatesListExpectedResult)
                && List.Equals(threeDuplicatesList, threeDuplicatesListExpectedResult)
                && List.Equals(duplicatedAtEnd, duplicatedAtEndExpectedResult)
                && List.Equals(noDuplicate, noDuplicateExpectedResult)
                && List.Equals(noDuplicateInMiddle, noDuplicateInMiddleExpectedResult);
        }

        void RemoveDupsWithHashtable(Node<char> head)
        {
            if (head == null)
                return;
            
            var seen = new bool[128];
            seen[head.Value] = true;

            var cursor = head.Next;
            var previous = head;
            while (cursor != null)
            {
                if (seen[cursor.Value])
                    previous.Next = cursor.Next;
                else
                {
                    seen[cursor.Value] = true;
                    previous = cursor;
                }

                cursor = cursor.Next;
            }
        }

        void RemoveDupsWithRunners(Node<char> head)
        {
            if (head == null)
                return;
            
            var slow = head;

            while (slow != null)
            {
                var fast = slow;

                while (fast.Next != null)
                {
                    if (fast.Next.Value == slow.Value)
                        fast.Next = fast.Next.Next;
                    else
                        fast = fast.Next;
                }

                slow = slow.Next;
            }
        }
    }
}