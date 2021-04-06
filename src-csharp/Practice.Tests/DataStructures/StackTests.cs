using FluentAssertions;
using NUnit.Framework;
using Practice.DataStructures;

namespace Practice.Tests.DataStructures
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void should_be_empty_after_instanciation()
        {
            new Stack<int>().IsEmpty().Should().BeTrue();
        }
        
        [Test]
        public void should_not_be_empty_after_a_value_is_pushed()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(42);
            
            // Assert
            stack.IsEmpty().Should().BeFalse();
        }

        [Test]
        public void should_be_empty_after_last_value_is_popped()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(42);
            
            // Act
            stack.Pop();
            
            // Assert
            stack.IsEmpty().Should().BeTrue();
        }

        [Test]
        public void should_peek_lifo()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(42);
            stack.Push(43);
            
            // Assert
            stack.Peek().Should().Be(43);
        }

        [Test]
        public void should_remove_lifo()
        {
            // Arrange
            var queue = new Stack<int>();
            queue.Push(42);
            queue.Push(43);
            
            // Assert
            queue.Pop().Should().Be(43);
            queue.Peek().Should().Be(42);
        }
    }
}