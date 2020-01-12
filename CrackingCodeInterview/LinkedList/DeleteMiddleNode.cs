using System;
using MySolutions.Common;
using MySolutions.CrackingCodeInterview.SinglyLinkedList;
using List = MySolutions.CrackingCodeInterview.SinglyLinkedList.SinglyLinkedList;

namespace MySolutions.CrackingCodeInterview.LinkedList
{
    public class DeleteMiddleNode : IExecutable
    {
        public void Explain()
        {
            Console.WriteLine("Delete a node in the middle (not head, not tail), given only that node.");
        }

        public void Run()
        {
            bool DeleteMiddleNodeConstantPassing = Test();
            Console.WriteLine(nameof(DeleteMiddleNodeConstant) + " tests returns: "
                + DeleteMiddleNodeConstantPassing);
        }

        bool Test()
        {
            var oneAfterMiddle = List.Build<char>(new [] { 'a', 'b', 'c' });
            DeleteMiddleNodeConstant(oneAfterMiddle.Next);
            var oneAfterMiddleExpectedResult = List.Build<char>(new [] { 'a', 'c' });

            var twoAfterMiddle = List.Build<char>(new [] { 'a', 'b', 'c', 'd' });
            DeleteMiddleNodeConstant(twoAfterMiddle.Next);
            var twoAfterMiddleExpectedResult = List.Build<char>(new [] { 'a', 'c', 'd' });

            return List.Equals(oneAfterMiddle, oneAfterMiddleExpectedResult)
                && List.Equals(twoAfterMiddle, twoAfterMiddleExpectedResult);
        }

        void DeleteMiddleNodeConstant(Node<char> middle)
        {
            throw new NotImplementedException();
        }
    }
}