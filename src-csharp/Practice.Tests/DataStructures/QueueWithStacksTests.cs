using FluentAssertions;
using NUnit.Framework;
using Practice.DataStructures;

namespace Practice.Tests.DataStructures
{
    [TestFixture]
    public class QueueWithStacksTests
    {
        [Test]
        public void should_be_empty_after_instanciation()
        {
            new QueueWithStacks<int>().IsEmpty().Should().BeTrue();
        }

        [Test]
        public void should_not_be_empty_after_a_value_is_added()
        {
            // Arrange
            var queue = new QueueWithStacks<int>();
            queue.Add(42);
            
            // Assert
            queue.IsEmpty().Should().BeFalse();
        }

        [Test]
        public void should_be_empty_after_last_value_is_removed()
        {
            // Arrange
            var queue = new QueueWithStacks<int>();
            queue.Add(42);
            
            // Act
            queue.Remove();
            
            // Assert
            queue.IsEmpty().Should().BeTrue();
        }

        [Test]
        public void should_peek_fifo()
        {
            // Arrange
            var queue = new QueueWithStacks<int>();
            queue.Add(42);
            queue.Add(43);
            
            // Assert
            queue.Peek().Should().Be(42);
        }

        [Test]
        public void should_remove_fifo()
        {
            // Arrange
            var queue = new QueueWithStacks<int>();
            queue.Add(42);
            queue.Add(43);
            
            // Assert
            queue.Remove().Should().Be(42);
            queue.Peek().Should().Be(43);
        }
    }
}