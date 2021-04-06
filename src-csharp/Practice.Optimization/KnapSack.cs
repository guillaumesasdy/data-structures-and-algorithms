using System;
using System.Collections.Generic;

namespace Practice.Optimization
{
    public class KnapSack
    {
        public void Run()
        {
            int value = Solve(50, new[] { new Item(0, 100), new Item(50, 100) });
            Console.WriteLine("found (expected 200): " + value);
            
            value = Solve(50, new[] { new Item(25, 25), new Item(75, 100) });
            Console.WriteLine("found (expected 25): " + value);
            
            value = Solve(50, new[] { new Item(51, 100) });
            Console.WriteLine("found (expected 0): " + value);
            
            value = Solve(50, new[]
            {
                new Item(20, 50),
                new Item(25, 60),
                new Item(20, 50),
                new Item(50, 100),
                new Item(10, 30),
                new Item(25, 60),
            });
            Console.WriteLine("found (expected 130): " + value);
        }

        private int Solve(int capacity, Item[] items)
        {
            Items = items;
            Memoization = new Dictionary<KnapSackKey, int>();
            
            return Solve(items.Length, capacity);
        }

        private int Solve(int itemNumbers, int capacity)
        {
            if (itemNumbers == 0 /*|| capacity <= 0*/) // stop if capacity is 0 supposes that there is no item with weight 0
                return 0;
            
            var key = new KnapSackKey(itemNumbers, capacity);
            if (Memoization.ContainsKey(key))
                return Memoization[key];

            var item = Items[itemNumbers - 1];
            int takeItem = item.Weight <= capacity
                ? Solve(itemNumbers - 1, capacity - item.Weight) + item.Value
                : 0;
            int dropItem = Solve(itemNumbers - 1, capacity);
            int greaterValue = Math.Max(takeItem, dropItem);

            Memoization[key] = greaterValue;
            
            return greaterValue;
        }
        
        private Item[] Items { get; set; }
        private Dictionary<KnapSackKey, int> Memoization { get; set; }

        private struct KnapSackKey : IEquatable<KnapSackKey>
        {
            private int ItemNumbers { get; }
            private int CapacityLeft { get; }

            public KnapSackKey(int itemNumbers, int capacityLeft)
            {
                ItemNumbers = itemNumbers;
                CapacityLeft = capacityLeft;
            }
            
            public bool Equals(KnapSackKey other)
            {
                return other.ItemNumbers == ItemNumbers
                       && other.CapacityLeft == CapacityLeft;
            }

            public override bool Equals(object obj) => obj is KnapSackKey key && Equals(key);

            public override int GetHashCode() => HashCode.Combine(ItemNumbers, CapacityLeft);
        }

        private class Item
        {
            public int Weight { get; }
            public int Value { get; }

            public Item(int weight, int value)
            {
                Value = value;
                Weight = weight;
            }
        }
    }
}
