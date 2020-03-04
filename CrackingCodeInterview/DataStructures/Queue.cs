using System;
using MySolutions.Common;
using MySolutions.CrackingCodeInterview.SinglyLinkedList;

namespace MySolutions.CrackingCodeInterview.Queue
{
    public class Queue<T> : IExecutable
    {
        private Node<T> first;
        
        private Node<T> last;

        public void Add(T value)
        {
            var added = new Node<T>();
            added.Value = value;

            if (IsEmpty())
                first = last = added;
            else {
                last.Next = added;
                last = added;
            }
        }

        public T Remove()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The queue is empty.");
            
            var value = first.Value;
            if (first == last)
                first = last = null;
            else {
                first = first.Next;
            }
            return value;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("The queue is empty.");
            
            return first.Value;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public void Explain()
        {
            Console.WriteLine("A stack data structure.");
        }

        public void Run()
        {
            var q = new Queue<int>();
            Console.WriteLine("a new queue should be empty: " + q.IsEmpty());

            q.Add(3);
            Console.WriteLine("adding 3 to the queue");
            q.Add(5);
            Console.WriteLine("adding 5 to the queue");
            Console.WriteLine("the queue should not be empty anymore: "
                + (q.IsEmpty() == false).ToString());
            Console.WriteLine("peek returns: " + q.Peek());
            Console.WriteLine("remove returns: " + q.Remove());
            Console.WriteLine("remove returns: " + q.Remove());
            Console.WriteLine("the queue should be empty again: " + q.IsEmpty());
        }
    }
}