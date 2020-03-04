﻿using System;
using MySolutions.Common;
using MySolutions.CrackingCodeInterview.Stack;

namespace MySolutions.CrackingCodeInterview.Queue
{
    /// <summary>
    /// Storing in the reverse order in the left stack is O(1) for add() operations
    /// but O(n) for remove() and peek()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueWithStacks<T> : IExecutable
    {
        /// <summary>
        /// Left stack holds the values in the reverse order
        /// </summary>
        private Stack<T> leftStack;

        /// <summary>
        /// Right stack is a temporary data structure used to reverse the left stack
        /// It allows us to simulate the First-in First-out of a queue
        /// </summary>
        private Stack<T> rightStack;

        public void Add(T value)
        {
            throw new NotImplementedException();
        }

        public T Remove()
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
            Console.WriteLine("A queue implemented with two stacks.");
        }

        public void Run()
        {
            // copied from the Queue class
            var q = new QueueWithStacks<int>();
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