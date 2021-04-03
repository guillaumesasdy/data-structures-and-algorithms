using System;

namespace MySolutions.Common.CSharp
{
    public class Delegates : IExecutable
    {
        public void Explain()
        {
            Console.WriteLine("Playing with C# delegates");
        }

        private delegate int DelegateType(int x);

        private int AddTwo(int x) => x + 2;
        private int SubTwo(int x) => x - 2;

        public void Run()
        {
            DelegateType delegateInstance2 = SubTwo; 
            // above is short for: new DelegateType(SubTwo);

            DelegateType multicast = null;
            multicast += AddTwo;
            multicast += SubTwo;
            
            Console.WriteLine($"Previous returned values are discarded, letting only {nameof(SubTwo)} returned value: " + multicast(0));
            // above is short for: multicast.Invoke(2)
        }
    }
}
