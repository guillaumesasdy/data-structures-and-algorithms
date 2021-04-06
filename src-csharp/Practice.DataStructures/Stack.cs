using System;

namespace Practice.DataStructures
{
    public class Stack<T>
    {
        protected Node<T> Top;

        public virtual T Pop()
        {
            if (Top == null)
                throw new InvalidOperationException("The stack is empty");
            
            var value = Top.Value;
            Top = Top.Next;
            return value;
        }

        public virtual void Push(T value)
        {
            var pushed = new Node<T>();
            pushed.Value = value;
            pushed.Next = Top;
            Top = pushed;
        }

        public T Peek()
        {
            if (Top == null)
                throw new InvalidOperationException("The stack is empty.");
            
            return Top.Value;
        }

        public bool IsEmpty()
        {
            return Top == null;
        }
    }
}