using System;
using MySolutions.Common;
using MySolutions.CrackingCodeInterview.SinglyLinkedList;
using List = MySolutions.CrackingCodeInterview.SinglyLinkedList.SinglyLinkedList;

namespace MySolutions.CrackingCodeInterview.LinkedList
{
    public class RemoveDups : IExecutable
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
            throw new NotImplementedException();
        }

        void RemoveDupsWithRunners(Node<char> head)
        {
            throw new NotImplementedException();
        }
    }
}