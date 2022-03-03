using Lab1.CircularLinkedList;
using System.Collections.Generic;
using Xunit;

namespace Lab2;

public class CircularLinkedListTests
{
	#region PremadeData

	public static IEnumerable<object[]> IntTestData => new List<object[]>
	{
		new object[] { 0 },
		new object[] { 1 },
		new object[] { -1 },
		new object[] { int.MaxValue },
		new object[] { int.MinValue },
	};

	public static IEnumerable<object[]> StringTestData => new List<object[]>
	{
		new object[] { "Паляниця" },
		new object[] { "Русский военный корабль" },
		new object[] { "European Union" },
		new object[] { "汉字 and 漢字" },
		new object[] { "الْعَرَبِيَّة" },
		new object[] { "👾🤓😎🥸🤩🥳" },
	};

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
	[MemberData(nameof(IntTestData))]
	public void Constructor_WithParameter_IntType_ReturnsCorrectValues(int expectedData)
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
	[MemberData(nameof(StringTestData))]
	public void Constructor_WithParameter_StringType_ReturnsCorrectValues(string expectedData)
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
	[MemberData(nameof(IntTestData))]
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
	[MemberData(nameof(StringTestData))]
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
