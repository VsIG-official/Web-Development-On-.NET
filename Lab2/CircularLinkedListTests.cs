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

    #region Add

    //[Theory]
    //[MemberData(nameof(IntTestData))]
    //public void AddFirst_ConstructorNoParameters_IntType_ReturnsCorrectValues
    //    (int expectedData)
    //{
    //    // Arrange
    //    var expectedCount = 1;
    //    var circularLinkedList = new CircularLinkedList<int>();
    //    circularLinkedList.AddFirst(expectedData);

    //    // Act
    //    var actualCount = circularLinkedList.Count;
    //    var actualHeadData = circularLinkedList.Head.Data;
    //    var actualTailData = circularLinkedList.Tail.Data;

    //    // Assert
    //    Assert.Equal(expectedCount, actualCount);
    //    Assert.Equal(expectedData, actualHeadData);
    //    Assert.Equal(expectedData, actualTailData);
    //}

    //[Theory]
    //[MemberData(nameof(StringTestData))]
    //public void AddFirst_ConstructorNoParameters_StringType_ReturnsCorrectValues
    //    (string expectedData)
    //{
    //    // Arrange
    //    var expectedCount = 1;
    //    var circularLinkedList = new CircularLinkedList<string>();
    //    circularLinkedList.AddFirst(expectedData);

    //    // Act
    //    var actualCount = circularLinkedList.Count;
    //    var actualHeadData = circularLinkedList.Head.Data;
    //    var actualTailData = circularLinkedList.Tail.Data;

    //    // Assert
    //    Assert.Equal(expectedCount, actualCount);
    //    Assert.Equal(expectedData, actualHeadData);
    //    Assert.Equal(expectedData, actualTailData);
    //}

    //[Theory]
    //[MemberData(nameof(IntArrayTestData))]
    //public void AddFirst_ConstructorWithParameter_IntType_ReturnsCorrectValues
    //    (int expectedHead, int expectedTail)
    //{
    //    // Arrange
    //    var expectedCount = 2;
    //    var circularLinkedList = new CircularLinkedList<int>(expectedTail);
    //    circularLinkedList.AddFirst(expectedHead);

    //    // Act
    //    var actualCount = circularLinkedList.Count;
    //    var actualHeadData = circularLinkedList.Head.Data;
    //    var actualTailData = circularLinkedList.Tail.Data;

    //    // Assert
    //    Assert.Equal(expectedCount, actualCount);
    //    Assert.Equal(expectedHead, actualHeadData);
    //    Assert.Equal(expectedTail, actualTailData);
    //}

    //[Theory]
    //[MemberData(nameof(StringArrayTestData))]
    //public void AddFirst_ConstructorWithParameter_StringType_ReturnsCorrectValues
    //    (string expectedHead, string expectedTail)
    //{
    //    // Arrange
    //    var expectedCount = 2;
    //    var circularLinkedList = new CircularLinkedList<string>(expectedTail);
    //    circularLinkedList.AddFirst(expectedHead);

    //    // Act
    //    var actualCount = circularLinkedList.Count;
    //    var actualHeadData = circularLinkedList.Head.Data;
    //    var actualTailData = circularLinkedList.Tail.Data;

    //    // Assert
    //    Assert.Equal(expectedCount, actualCount);
    //    Assert.Equal(expectedHead, actualHeadData);
    //    Assert.Equal(expectedTail, actualTailData);
    //}

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
}
