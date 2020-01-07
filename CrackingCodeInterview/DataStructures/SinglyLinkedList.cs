using System;
using MySolutions.Common;

namespace MySolutions.CrackingCodeInterview.SinglyLinkedList
{
    public class SinglyLinkedList : IExecutable
    {
        // Build a singly linked list from the array of values
        // and returns the head of the linked list.
        public static Node<T> Build<T>(in T[] values)
        {
            if (values == null || values.Length == 0)
                return null;

            Node<T> head = new Node<T>();
            head.Value = values[0];

            Node<T> current = head;

            for(int i=1; i<values.Length; i++)
            {
                Node<T> previous = current;

                current = new Node<T>();
                current.Value = values[i];

                previous.Next = current;
            }

            return head;
        }

        public static bool Equals<T>(in Node<T> first, in Node<T> second)
        {
            if (first == null || second == null)
                return false;

            var firstCursor = first;
            var secondCursor = second;
            do
            {
                if (firstCursor.Value.Equals(secondCursor.Value) == false)
                    return false;
                
                firstCursor = firstCursor.Next;
                secondCursor = secondCursor.Next;
            } while (firstCursor != null && secondCursor != null);

            return firstCursor == null && secondCursor == null;
        }

        public void Explain()
        {
            Console.WriteLine("A singly linked list builder.");
        }

        public void Run()
        {
            Node<int> list = Build(new [] { 1, 2, 1, 4 });
            var cursor = list;

            Console.Write("build linked list from array { 1, 2, 3, 4 } have values: ");
            while(cursor != null)
            {
                Console.Write(cursor.Value);

                cursor = cursor.Next;
            }
            Console.WriteLine();

            Node<int> same = Build(new [] { 1, 2, 1, 4 });

            Console.WriteLine("test equality between two list passing: "
                + (Equals<int>(list, same) == true).ToString());

            Node<int> different = Build(new [] { 1, 2, 1, 4, 5 });

            Console.WriteLine("test difference passing: "
                + (Equals<int>(list, different) == false).ToString());
        }
    }
}