using System;
using MySolutions.Common;
using MySolutions.CrackingCodeInterview.SinglyLinkedList;
using List = MySolutions.CrackingCodeInterview.SinglyLinkedList.SinglyLinkedList;

namespace MySolutions.CrackingCodeInterview.LinkedList
{
    public class Partition : IExecutable
    {
        public void Explain()
        {
            Console.WriteLine("Partition a linked list around a given value.");
        }

        public void Run()
        {
            Test();
        }

        void Test()
        {
            var bookInput = List.Build<int>(new [] { 3, 5, 8, 5, 10, 2, 1 });
            Console.Write("book input: ");
            List.WriteLineInConsole(bookInput);

            var bookOutput = PartitionList(bookInput, 5);
            Console.Write("partition 5: ");
            List.WriteLineInConsole(bookInput);
            
            // todo GSA limit cas test such as 0 element in left part, 1 element in left part,
            // same for right part
        }

        Node<int> PartitionList(Node<int> head, int value)
        {
            throw new NotImplementedException();
        }
    }
}