using System;
using MySolutions.Common;
using MySolutions.CrackingCodeInterview.SinglyLinkedList;
using List = MySolutions.CrackingCodeInterview.SinglyLinkedList.SinglyLinkedList;

namespace MySolutions.CrackingCodeInterview.LinkedList
{
    public class ReturnKthLast : IExecutable
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
            throw new NotImplementedException();
        }
    }
}