using System;
using MySolutions.Common;
using MySolutions.CrackingCodeInterview.SinglyLinkedList;
using List = MySolutions.CrackingCodeInterview.SinglyLinkedList.SinglyLinkedList;

namespace MySolutions.CrackingCodeInterview.LinkedList
{
    public class SumLists : IExecutable
    {
        public void Explain()
        {
            Console.WriteLine("Sum a linked list of digits.");
        }

        public void Run()
        {
            bool SumListsPassing = Test();
            Console.WriteLine(nameof(SumLists) + " tests returns: "
                                               + SumListsPassing);
        }

        bool Test()
        {
            var zero1 = List.Build(new [] { 0 });
            var zero2 = List.Build(new [] { 0 });
            var zeroResult = SumListsReverse(zero1, zero2);
            var zeroExpectedResult = List.Build(new [] { 0 });
            
            var carry1 = List.Build(new [] { 9, 9 });
            var carry2 = List.Build(new [] { 9, 9 });
            var carryResult = SumListsReverse(carry1, carry2);
            var carryExpectedResult = List.Build(new [] { 8, 8, 1 });

            var oneBigger1 = List.Build(new[] {1, 1, 1, 1});
            var oneBigger2 = List.Build(new[] {1});
            var oneBiggerResult = SumListsReverse(oneBigger1, oneBigger2);
            var oneBiggerExpectedResult = List.Build(new[] {2, 1, 1, 1});
            
            var twoBigger1 = List.Build(new[] {9});
            var twoBigger2 = List.Build(new[] {2, 1});
            var twoBiggerResult = SumListsReverse(twoBigger1, twoBigger2);
            var twoBiggerExpectedResult = List.Build(new[] {1, 2});

            return List.Equals(zeroResult, zeroExpectedResult)
                && List.Equals(carryResult, carryExpectedResult)
                && List.Equals(oneBiggerResult, oneBiggerExpectedResult)
                && List.Equals(twoBiggerResult, twoBiggerExpectedResult);
        }

        Node<int> SumListsReverse(Node<int> one, Node<int> two)
        {
            return null;
        }
    }
}