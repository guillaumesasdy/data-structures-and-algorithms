using System;

namespace Practice.DataStructures
{
    public class Queue<T>
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
    }
}