using System;
using Practice.DataStructures;
using List = Practice.DataStructures.SinglyLinkedList;

namespace Practice.CrackingCode.LinkedList
{
    public class Partition
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
            List.WriteLineInConsole(bookInput, ", ");

            var bookOutput = PartitionList(bookInput, 5);
            Console.Write("partition 5: ");
            List.WriteLineInConsole(bookOutput, ", ");
            
            // todo GSA limit cas test such as 0 element in left part, 1 element in left part,
            // same for right part
        }

        Node<int> PartitionList(Node<int> head, int value)
        {
            Node<int> leftHead = null, rightHead = null;
            Node<int> leftTail = null;
            
            Node<int> current = head;
            while (current != null)
            {
                var next = current.Next;

                if (current.Value < value)
                {
                    var oldLeftHead = leftHead;
                    leftHead = current;
                    leftHead.Next = oldLeftHead;

                    if (oldLeftHead == null)
                        leftTail = leftHead;
                }
                else {
                    var oldRightHead = rightHead;
                    rightHead = current;
                    rightHead.Next = oldRightHead;
                }

                current = next;
            }

            if (leftTail != null)
                leftTail.Next = rightHead;

            return leftHead ?? rightHead;
        }
    }
}