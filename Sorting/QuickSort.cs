using MySolutions.Common;
using System;

namespace MySolutions.Sorting
{
    public class QuickSort : IExecutable
    {
        public void Explain()
        {
            Console.WriteLine("Quick sort O(N.log(N)");
        }

        public void Run()
        {
            Test(new[] { 5 });
            Test(new[] { 1, 2 });
            Test(new[] { 2, 1 });
            Test(new[] { 2, 2 });
            Test(new[] { 3, 1, 2, 4, 1, 2 });
        }

        private void Test(int[] array)
        {
            Console.WriteLine("array: " + string.Join(" ", array));
            Sort(array);
            Console.WriteLine("sorted: " + string.Join(" ", array));
        }

        private void Sort(int[] array) => Sort(array, 0, array.Length - 1);

        private void Sort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int middle = Partition(array, low, high);

                Sort(array, low, middle - 1);
                Sort(array, middle + 1, high);
            }
        }

        private int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];

            int i = low;

            for(int j=low; j<=high-1; j++)
            {
                if (array[j] <= pivot)
                {
                    Swap(array, i, j);
                    i++;
                }
            }

            Swap(array, i, high);

            return i;
        }

        private void Swap(int[] array, int @this, int that)
        {
            int temp = array[@this];
            array[@this] = array[that];
            array[that] = temp;
        }
    }
}