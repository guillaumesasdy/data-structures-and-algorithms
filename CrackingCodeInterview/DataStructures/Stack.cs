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
            if (top == null)
                throw new InvalidOperationException("The stack is empty");
            
            var value = top.Value;
            top = top.Next;
            return value;
        }

        public void Push(T value)
        {
            var pushed = new Node<T>();
            pushed.Value = value;
            pushed.Next = top;
            top = pushed;
        }

        public T Peek()
        {
            if (top == null)
                throw new InvalidOperationException("The stack is empty.");
            
            return top.Value;
        }

        public bool IsEmpty()
        {
            return top == null;
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
            s.Push(5);
            Console.WriteLine("pushing 5 onto the stack");
            Console.WriteLine("the stack should not be empty anymore: "
                + (s.IsEmpty() == false).ToString());
            Console.WriteLine("peek returns: " + s.Peek());
            Console.WriteLine("pop returns: " + s.Pop());
            Console.WriteLine("pop returns: " + s.Pop());
            Console.WriteLine("the stack should be empty again: " + s.IsEmpty());
        }
    }
}