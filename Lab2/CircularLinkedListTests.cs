using Lab1.CircularLinkedList;
using System;
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
		new object[] { "汉字" },
		new object[] { "الْعَرَبِيَّة" },
		new object[] { "👾🤓😎🥸🤩🥳" },
		new object[] { "█Ã░╬ðØ" },
    };

    public static IEnumerable<object[]> IntArrayTestData => new List<object[]>
    {
        new object[] { 0, 10 },
        new object[] { 1, 11 },
        new object[] { -1, -11 },
        new object[] { int.MaxValue, int.MaxValue - 10 },
        new object[] { int.MinValue, int.MinValue + 10 },
    };

    public static IEnumerable<object[]> StringArrayTestData => new List<object[]>
    {
        new object[] { "Паляниця", "Полуниця" },
        new object[] { "Русский военный корабль", "Иди далеко" },
        new object[] { "European Union", "NATO" },
        new object[] { "汉字", "漢字" },
        new object[] { "الْعَرَبِيَّة", "الْحُرُوف" },
        new object[] { "👾🤓😎🥸🤩🥳", "🧳🌂☂️🧵🧶👓" },
        new object[] { "█Ã░╬ðØ", "®ßƒ≡¾Æ" },
    };

    #endregion PremadeData

    #region Constructors

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

    #endregion Constructors

    #region Indexer



    #endregion Indexer

    #region Add

    [Theory]
    [MemberData(nameof(IntTestData))]
    public void Add_ConstructorNoParameters_IntType_ReturnsCorrectValues
        (int expectedData)
    {
        // Arrange
        var expectedCount = 1;
        var circularLinkedList = new CircularLinkedList<int>();
        circularLinkedList.Add(expectedData);

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
    public void Add_ConstructorNoParameters_StringType_ReturnsCorrectValues
        (string expectedData)
    {
        // Arrange
        var expectedCount = 1;
        var circularLinkedList = new CircularLinkedList<string>();
        circularLinkedList.Add(expectedData);

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
    [MemberData(nameof(IntArrayTestData))]
    public void Add_ConstructorWithParameter_IntType_ReturnsCorrectValues
        (int expectedHead, int expectedTail)
    {
        // Arrange
        var expectedCount = 2;
        var circularLinkedList = new CircularLinkedList<int>(expectedHead);
        circularLinkedList.Add(expectedTail);

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHeadData = circularLinkedList.Head.Data;
        var actualTailData = circularLinkedList.Tail.Data;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Equal(expectedHead, actualHeadData);
        Assert.Equal(expectedTail, actualTailData);
    }

    [Theory]
    [MemberData(nameof(StringArrayTestData))]
    public void Add_ConstructorWithParameter_StringType_ReturnsCorrectValues
        (string expectedHead, string expectedTail)
    {
        // Arrange
        var expectedCount = 2;
        var circularLinkedList = new CircularLinkedList<string>(expectedHead);
        circularLinkedList.Add(expectedTail);

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHeadData = circularLinkedList.Head.Data;
        var actualTailData = circularLinkedList.Tail.Data;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Equal(expectedHead, actualHeadData);
        Assert.Equal(expectedTail, actualTailData);
    }

    #endregion Add

    #region AddFirst

    [Theory]
	[MemberData(nameof(IntTestData))]
	public void AddFirst_ConstructorNoParameters_IntType_ReturnsCorrectValues
        (int expectedData)
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
	public void AddFirst_ConstructorNoParameters_StringType_ReturnsCorrectValues
        (string expectedData)
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

    [Theory]
    [MemberData(nameof(IntArrayTestData))]
    public void AddFirst_ConstructorWithParameter_IntType_ReturnsCorrectValues
        (int expectedHead, int expectedTail)
    {
        // Arrange
        var expectedCount = 2;
        var circularLinkedList = new CircularLinkedList<int>(expectedTail);
        circularLinkedList.AddFirst(expectedHead);

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHeadData = circularLinkedList.Head.Data;
        var actualTailData = circularLinkedList.Tail.Data;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Equal(expectedHead, actualHeadData);
        Assert.Equal(expectedTail, actualTailData);
    }

    [Theory]
    [MemberData(nameof(StringArrayTestData))]
    public void AddFirst_ConstructorWithParameter_StringType_ReturnsCorrectValues
        (string expectedHead, string expectedTail)
    {
        // Arrange
        var expectedCount = 2;
        var circularLinkedList = new CircularLinkedList<string>(expectedTail);
        circularLinkedList.AddFirst(expectedHead);

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHeadData = circularLinkedList.Head.Data;
        var actualTailData = circularLinkedList.Tail.Data;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Equal(expectedHead, actualHeadData);
        Assert.Equal(expectedTail, actualTailData);
    }

    #endregion AddFirst

    #region Clear

    [Fact]
    public void Clear_ConstructorNoParameters_IntType_ReturnsCorrectValues()
    {
        // Arrange
        var expectedCount = 0;
        var circularLinkedList = new CircularLinkedList<int>();
        circularLinkedList.Clear();

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHead = circularLinkedList.Head;
        var actualTail = circularLinkedList.Tail;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Null(actualHead);
        Assert.Null(actualTail);
    }

    [Fact]
    public void Clear_ConstructorNoParameters_StringType_ReturnsCorrectValues()
    {
        // Arrange
        var expectedCount = 0;
        var circularLinkedList = new CircularLinkedList<string>();
        circularLinkedList.Clear();

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHead = circularLinkedList.Head;
        var actualTail = circularLinkedList.Tail;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Null(actualHead);
        Assert.Null(actualTail);
    }

    [Theory]
    [MemberData(nameof(IntTestData))]
    public void Clear_ConstructorWithParameters_AddFirst_IntType_ReturnsCorrectValues
        (int expectedData)
    {
        // Arrange
        var expectedCount = 0;
        var circularLinkedList = new CircularLinkedList<int>();
        circularLinkedList.AddFirst(expectedData);
        circularLinkedList.Clear();

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHead = circularLinkedList.Head;
        var actualTail = circularLinkedList.Tail;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Null(actualHead);
        Assert.Null(actualTail);
    }

    [Theory]
    [MemberData(nameof(StringTestData))]
    public void Clear_ConstructorWithParameters_AddFirst_StringType_ReturnsCorrectValues
        (string expectedData)
    {
        // Arrange
        var expectedCount = 0;
        var circularLinkedList = new CircularLinkedList<string>();
        circularLinkedList.AddFirst(expectedData);
        circularLinkedList.Clear();

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHead = circularLinkedList.Head;
        var actualTail = circularLinkedList.Tail;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Null(actualHead);
        Assert.Null(actualTail);
    }

    [Theory]
    [MemberData(nameof(IntTestData))]
    public void Clear_ConstructorWithParameters_Add_IntType_ReturnsCorrectValues
        (int expectedData)
    {
        // Arrange
        var expectedCount = 0;
        var circularLinkedList = new CircularLinkedList<int>();
        circularLinkedList.Add(expectedData);
        circularLinkedList.Clear();

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHead = circularLinkedList.Head;
        var actualTail = circularLinkedList.Tail;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Null(actualHead);
        Assert.Null(actualTail);
    }

    [Theory]
    [MemberData(nameof(StringTestData))]
    public void Clear_ConstructorWithParameters_Add_StringType_ReturnsCorrectValues
        (string expectedData)
    {
        // Arrange
        var expectedCount = 0;
        var circularLinkedList = new CircularLinkedList<string>();
        circularLinkedList.Add(expectedData);
        circularLinkedList.Clear();

        // Act
        var actualCount = circularLinkedList.Count;
        var actualHead = circularLinkedList.Head;
        var actualTail = circularLinkedList.Tail;

        // Assert
        Assert.Equal(expectedCount, actualCount);
        Assert.Null(actualHead);
        Assert.Null(actualTail);
    }

    #endregion Clear

    #region Contains

    [Theory]
    [MemberData(nameof(IntTestData))]
    public void Contains_NoElements_IntType_ReturnsFalse
        (int data)
    {
        // Arrange
        var circularLinkedList = new CircularLinkedList<int>();

        // Act
        var actual = circularLinkedList.Contains(data);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(StringTestData))]
    public void Contains_NoElements_StringType_ReturnsFalse
        (string data)
    {
        // Arrange
        var circularLinkedList = new CircularLinkedList<string>();

        // Act
        var actual = circularLinkedList.Contains(data);

        // Assert
        Assert.False(actual);
    }

    [Theory]
    [MemberData(nameof(IntTestData))]
    public void Contains_DifferentElements_AddFirst_IntType_ReturnsTrue
        (int data)
    {
        // Arrange
        var circularLinkedList = new CircularLinkedList<int>();
        circularLinkedList.AddFirst(data);

        // Act
        var actual = circularLinkedList.Contains(data);

        // Assert
        Assert.True(actual);
    }

    [Theory]
    [MemberData(nameof(StringTestData))]
    public void Contains_DifferentElements_AddFirst_StringType_ReturnsTrue
        (string data)
    {
        // Arrange
        var circularLinkedList = new CircularLinkedList<string>();
        circularLinkedList.AddFirst(data);

        // Act
        var actual = circularLinkedList.Contains(data);

        // Assert
        Assert.True(actual);
    }

    //[Theory]
    //[MemberData(nameof(IntTestData))]
    //public void Contains_DifferentElements_Add_IntType_ReturnsTrue
    //    (int data)
    //{
    //    // Arrange
    //    var circularLinkedList = new CircularLinkedList<int>();
    //    circularLinkedList.Add(data);

    //    // Act
    //    var actual = circularLinkedList.Contains(data);

    //    // Assert
    //    Assert.True(actual);
    //}

    //[Theory]
    //[MemberData(nameof(StringTestData))]
    //public void Contains_DifferentElements_Add_StringType_ReturnsTrue
    //    (string data)
    //{
    //    // Arrange
    //    var circularLinkedList = new CircularLinkedList<string>();
    //    circularLinkedList.Add(data);

    //    // Act
    //    var actual = circularLinkedList.Contains(data);

    //    // Assert
    //    Assert.True(actual);
    //}

    #endregion Contains

    #region CopyTo



    #endregion CopyTo

    #region Remove



    #endregion Remove

    #region ToString

    [Fact]
    public void ToString_NoElements_IntType_ReturnsCorrectValues()
    {
        // Arrange
        var circularLinkedList = new CircularLinkedList<int>();
        var expected = "";

        // Act
        var actual = circularLinkedList.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToString_NoElements_StringType_ReturnsCorrectValues()
    {
        // Arrange
        var circularLinkedList = new CircularLinkedList<string>();
        var expected = "";

        // Act
        var actual = circularLinkedList.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(IntArrayTestData))]
    public void ToString_DifferentElements_IntType_ReturnsCorrectValues
        (int firstElement, int secondElement)
    {
        // Arrange
        var circularLinkedList = new CircularLinkedList<int>();

        circularLinkedList.AddFirst(secondElement);
        circularLinkedList.AddFirst(firstElement);

        var firstPart = $"{ firstElement + Environment.NewLine + Environment.NewLine }";
        var secondPart = $"{ secondElement + Environment.NewLine + Environment.NewLine }";

        var expected = firstPart + secondPart;

        // Act
        var actual = circularLinkedList.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [MemberData(nameof(StringArrayTestData))]
    public void ToString_DifferentElements_StringType_ReturnsCorrectValues
        (string firstElement, string secondElement)
    {
        // Arrange
        var circularLinkedList = new CircularLinkedList<string>();

        circularLinkedList.AddFirst(secondElement);
        circularLinkedList.AddFirst(firstElement);

        var firstPart = $"{ firstElement + Environment.NewLine + Environment.NewLine }";
        var secondPart = $"{ secondElement + Environment.NewLine + Environment.NewLine }";

        var expected = firstPart + secondPart;

        // Act
        var actual = circularLinkedList.ToString();

        // Assert
        Assert.Equal(expected, actual);
    }

    #endregion ToString
}
