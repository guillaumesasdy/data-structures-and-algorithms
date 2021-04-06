using System;
using Practice.DataStructures;
using List = Practice.DataStructures.SinglyLinkedList;

namespace Practice.CrackingCode.LinkedList
{
    public class LoopDetection
    {
        public void Explain()
        {
            Console.WriteLine("Return the (k)th node where two lists intersect.");
        }

        public void Run()
        {
            bool LoopDetectionPassing = Test();
            Console.WriteLine(nameof(LoopDetection) + " tests returns: " + LoopDetectionPassing);
        }

        bool Test()
        {
            var list = List.Build(new [] { 1, 2, 3, 4, 5, 6 });
            var fourthNode = list.Next.Next.Next;
            var sixthNode = fourthNode.Next.Next;
            sixthNode.Next = fourthNode;

            var singleNode = List.Build(new[] {1});
            singleNode.Next = singleNode;

            var threeNodes = List.Build(new[] {1, 2, 3});
            threeNodes.Next = threeNodes;

            var lastNode = List.Build(new[] {1, 2});
            lastNode.Next.Next = lastNode.Next;

            return LoopAt(list) == 4 
                && LoopAt(singleNode) == 1
                && LoopAt(threeNodes) == 1
                && LoopAt(lastNode) == 2;
        }

        public int LoopAt(Node<int> list)
        {
            var collisionNode = Collide(list);
            int loopSize = LoopSize(collisionNode);

            var current = list;
            var cheaper = Skip(list, loopSize);

            int loopAt = 1;
            while (current != cheaper)
            {
                current = current.Next;
                cheaper = cheaper.Next;
                loopAt++;
            }

            return loopAt;
        }

        Node<int> Collide(Node<int> list)
        {
            var slow = list;
            var fast = list.Next;

            while (slow != fast)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow;
        }

        /// <param name="loopNode">any node inside of a loop</param>
        /// <returns>size of the loop</returns>
        int LoopSize(Node<int> loopNode)
        {
            int size = 1;
            var start = loopNode;
            var loop = loopNode.Next;

            while (loop != start)
            {
                loop = loop.Next;
                size++;
            }

            return size;
        }

        Node<int> Skip(Node<int> node, int skip)
        {
            while (skip > 0)
            {
                node = node.Next;
                skip--;
            }

            return node;
        }
    }
}
