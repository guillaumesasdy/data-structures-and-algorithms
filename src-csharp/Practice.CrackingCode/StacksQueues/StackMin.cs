using System;
using Practice.DataStructures;

namespace Practice.CrackingCode.StacksQueues
{
    public class StackMin<T> : Stack<T> where T : IComparable
    {
        public void Run()
        {
            bool returnMinPassing = Test();
            Console.WriteLine("Tests returns: " + returnMinPassing);
        }

        bool Test()
        {
            var minStack = new StackMin<int>();
            
            minStack.Push(100);
            if(minStack.Min() != 100) return false;
            
            minStack.Push(200);
            if (minStack.Min() != 100) return false;
            
            minStack.Push(50);
            minStack.Push(50);
            if (minStack.Min() != 50) return false;

            minStack.Pop();
            if (minStack.Min() != 50) return false;
            
            minStack.Pop();
            if (minStack.Min() != 100) return false;

            return true;
        }

        private readonly Stack<T> _min = new Stack<T>();

        public T Min() => _min.Peek();

        public override void Push(T value)
        {
            if (_min.IsEmpty() || value.CompareTo(_min.Peek()) <= 0)
                _min.Push(value);
            
            base.Push(value);
        }

        public override T Pop()
        {
            T popped = base.Pop();

            if (popped.CompareTo(_min.Peek()) == 0)
                _min.Pop();
            
            return popped;
        }
    }
}
