using System;

namespace Practice.DataStructures
{
    /// <summary>
    /// Storing in the reverse order in the left stack is O(1) for add() operations
    /// but O(n) for remove() and peek()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueWithStacks<T>
    {
        /// <summary>
        /// Left stack holds the values in the reverse order
        /// </summary>
        private Stack<T> leftStack = new Stack<T>();

        /// <summary>
        /// Right stack is a temporary data structure used to reverse the left stack
        /// It allows us to simulate the First-in First-out of a queue
        /// </summary>
        private Stack<T> rightStack = new Stack<T>();

        public void Add(T value)
        {
            leftStack.Push(value);
        }

        public T Remove()
        {
            if (leftStack.IsEmpty())
                throw new InvalidOperationException();

            PourOneStackIntoAnother(leftStack, rightStack);

            var value = rightStack.Pop();

            PourOneStackIntoAnother(rightStack, leftStack);

            return value;
        }

        public T Peek()
        {
            if (leftStack.IsEmpty())
                throw new InvalidOperationException();

            PourOneStackIntoAnother(leftStack, rightStack);

            var value = rightStack.Peek(); // above and below are duplicated from Remove() code

            PourOneStackIntoAnother(rightStack, leftStack);

            return value;
        }

        private void PourOneStackIntoAnother(Stack<T> one, Stack<T> another)
        {
            while (one.IsEmpty() == false)
                another.Push(one.Pop());
        }

        public bool IsEmpty()
        {
            return leftStack.IsEmpty();
        }
    }
}