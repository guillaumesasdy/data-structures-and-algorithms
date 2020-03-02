using System;
using MySolutions.Common;
using MySolutions.CrackingCodeInterview.SinglyLinkedList;

namespace MySolutions.CrackingCodeInterview.Stack
{
    public class Stack<T> : IExecutable
    {
        private Node<T> top;

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(T value)
        {
            throw new NotImplementedException();
        }

        public T Peek()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public void Explain()
        {
            Console.WriteLine("A stack data structure.");
        }

        public void Run()
        {
            var s = new Stack<int>();
            Console.WriteLine("a new stack should be empty: " + s.IsEmpty());

            s.Push(3);
            Console.WriteLine("pushing 3 onto the stack");
            Console.WriteLine("the stack should not be empty anymore: "
                + (s.IsEmpty() == false).ToString());
            Console.WriteLine("peek returns: " + s.Peek());
            Console.WriteLine("pop returns: " + s.Pop());
            Console.WriteLine("the stack should be empty again: " + s.IsEmpty());
        }
    }
}