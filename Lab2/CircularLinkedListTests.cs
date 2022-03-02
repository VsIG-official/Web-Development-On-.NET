using Lab1.CircularLinkedList;
using Xunit;

namespace Lab2;

public class CircularLinkedListTests
{
	[Fact]
	public void Constructor_NoParameters_ReturnsCorrectValues()
	{
		// Arrange
		var circularLinkedList = new CircularLinkedList<int>();
		var expectedCount = 0;

		// Act
		var actualTail = circularLinkedList.Tail;
		var actualHead = circularLinkedList.Head;
		var actualCount = circularLinkedList.Count;
		var actualIsReadOnly = circularLinkedList.IsReadOnly;

		// Assert
		Assert.Null(actualTail);
		Assert.Null(actualHead);
		Assert.Equal(expectedCount, actualCount);
		Assert.False(actualIsReadOnly);
	}

	[Fact]
	public void Constructor_GenericParameter_ReturnsCorrectValues()
	{
		// Arrange
		var circularLinkedList = new CircularLinkedList<int>();
		var expectedCount = 0;

		// Act
		var actualTail = circularLinkedList.Tail;
		var actualHead = circularLinkedList.Head;
		var actualCount = circularLinkedList.Count;
		var actualIsReadOnly = circularLinkedList.IsReadOnly;

		// Assert
		Assert.Null(actualTail);
		Assert.Null(actualHead);
		Assert.Equal(expectedCount, actualCount);
		Assert.False(actualIsReadOnly);
	}
}
