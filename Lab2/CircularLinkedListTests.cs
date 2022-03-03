using Lab1.CircularLinkedList;
using Xunit;

namespace Lab2;

public class CircularLinkedListTests
{
	#region PremadeData

	#endregion PremadeData

	#region ConstructorWithoutParameters

	[Fact]
	public void Constructor_NoParameters_IntType_ReturnsCorrectValues()
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
	public void Constructor_NoParameters_StringType_ReturnsCorrectValues()
	{
		// Arrange
		var circularLinkedList = new CircularLinkedList<string>();
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

	#endregion ConstructorWithoutParameters

	#region ConstructorWithParameters

	[Theory]
	[InlineData(0)]
	[InlineData(-1)]
	[InlineData(1)]
	[InlineData(int.MinValue)]
	[InlineData(int.MaxValue)]
	public void Constructor_GenericParameter_IntType_ReturnsCorrectValues(int expectedData)
	{
		// Arrange
		var expectedCount = 1;
		var circularLinkedList = new CircularLinkedList<int>(expectedData);

		// Act
		var actualCount = circularLinkedList.Count;
		var actualHeadData = circularLinkedList.Head.Data;
		var actualTailData = circularLinkedList.Tail.Data;

		// Assert
		Assert.Equal(expectedCount, actualCount);
		Assert.Equal(expectedData, actualHeadData);
		Assert.Equal(expectedData, actualTailData);
	}

	[Theory]
	[InlineData("Паляниця")]
	[InlineData("Русский военный корабль")]
	[InlineData("European Union")]
	[InlineData("汉字 and 漢字")]
	[InlineData("الْعَرَبِيَّة")]
	[InlineData("👾🤓😎🥸🤩🥳")]
	public void Constructor_GenericParameter_StringType_ReturnsCorrectValues(string expectedData)
	{
		// Arrange
		var expectedCount = 1;
		var circularLinkedList = new CircularLinkedList<string>(expectedData);

		// Act
		var actualCount = circularLinkedList.Count;
		var actualHeadData = circularLinkedList.Head.Data;
		var actualTailData = circularLinkedList.Tail.Data;

		// Assert
		Assert.Equal(expectedCount, actualCount);
		Assert.Equal(expectedData, actualHeadData);
		Assert.Equal(expectedData, actualTailData);
	}

	#endregion ConstructorWithParameters

	#region AddFirst

	[Theory]
	[InlineData(0)]
	[InlineData(-1)]
	[InlineData(1)]
	[InlineData(int.MinValue)]
	[InlineData(int.MaxValue)]
	public void AddFirst_EmptyConstructor_IntType_ReturnsCorrectValues(int expectedData)
	{
		// Arrange
		var expectedCount = 1;
		var circularLinkedList = new CircularLinkedList<int>();
		circularLinkedList.AddFirst(expectedData);

		// Act
		var actualCount = circularLinkedList.Count;
		var actualHeadData = circularLinkedList.Head.Data;
		var actualTailData = circularLinkedList.Tail.Data;

		// Assert
		Assert.Equal(expectedCount, actualCount);
		Assert.Equal(expectedData, actualHeadData);
		Assert.Equal(expectedData, actualTailData);
	}

	[Theory]
	[InlineData("Паляниця")]
	[InlineData("Русский военный корабль")]
	[InlineData("European Union")]
	[InlineData("汉字 and 漢字")]
	[InlineData("الْعَرَبِيَّة")]
	[InlineData("👾🤓😎🥸🤩🥳")]
	public void AddFirst_EmptyConstructor_StringType_ReturnsCorrectValues(string expectedData)
	{
		// Arrange
		var expectedCount = 1;
		var circularLinkedList = new CircularLinkedList<string>();
		circularLinkedList.AddFirst(expectedData);

		// Act
		var actualCount = circularLinkedList.Count;
		var actualHeadData = circularLinkedList.Head.Data;
		var actualTailData = circularLinkedList.Tail.Data;

		// Assert
		Assert.Equal(expectedCount, actualCount);
		Assert.Equal(expectedData, actualHeadData);
		Assert.Equal(expectedData, actualTailData);
	}
	
	#endregion AddFirst
}
