using Lab1.CircularLinkedListNode;
using System.Collections;
using System.Text;

namespace Lab1.CircularLinkedList;

public class CircularLinkedList<T> : ICollection<T>, IEnumerable
{
    #region Fields

    public CircularLinkedListNode<T>? Head { get; private set; }
	public CircularLinkedListNode<T>? Tail { get; private set; }

	public int Count { get; private set; }

	public bool IsReadOnly => false;

    #endregion Fields

    #region Constructors

    public CircularLinkedList()
	{
		Head = null;
		Tail = null;
	}

	public CircularLinkedList(T item)
	{
		SetFirstElement(item);
	}

    #endregion Constructors

    #region Methods

    public T this[int index]
    {
        get
        {
            CheckCorrectIndex(index);

            var current = Head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }
        set
        {
            CheckNull(value);

            CheckCorrectIndex(index);

            var current = Head;

            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Data = value;
        }
    }

    private void CheckCorrectIndex(int index)
    {
        if (index > Count - 1)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
    }

	private void SetFirstElement(T item)
	{
        CheckNull(item);

        var node = new CircularLinkedListNode<T>(item);

		Head = node;
		Head.Next = node;
		Tail = node;
		Tail.Next = node;

		Count++;
	}

    public void Add(T item)
    {
        CheckNull(item);

        if (IsEmpty())
        {
            SetFirstElement(item);
            return;
        }

        Tail = new CircularLinkedListNode<T>(item)
        {
            Next = Head
        };

        var current = Head;

        for (int i = 0; i < Count - 1; i++)
        {
            current = current.Next;
        }

        current.Next = Tail;

        Count++;
    }

    public void AddFirst(T item)
	{
        CheckNull(item);

        if (IsEmpty())
		{
			SetFirstElement(item);
			return;
		}

		Head = new CircularLinkedListNode<T>(item)
		{
			Next = Head
		};

		Count++;

        SetTail();
	}

    //public void AddAt(T item, int index)
    //{
    //    CheckNull(item);
    //    CheckCorrectIndex(index);

    //    if (IsEmpty())
    //    {
    //        SetFirstElement(item);
    //        return;
    //    }

    //    var current = Head;
    //    var nextToCurrent = Head;

    //    for (var i = 0; i < index; i++)
    //    {
    //        current = current.Next;
    //    }

    //    for (var i = 0; i < index + 1; i++)
    //    {
    //        nextToCurrent = nextToCurrent.Next;
    //    }


    //}

    private bool IsEmpty()
    {
        if (Count == 0)
        {
            return true;
        }

        return false;
    }

    private static void CheckNull(T item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
    }

    private void SetTail()
    {
        var currentNode = Head;

        for (var i = 0; i < Count; i++)
        {
            if (i == Count - 1)
            {
                Tail = currentNode;
            }

            currentNode = currentNode.Next;
        }

        Tail.Next = Head;
    }

	public void Clear()
	{
        Head = Tail = null;
        Count = 0;
	}

	public bool Contains(T item)
	{
        CheckNull(item);

        var current = Head;

        for (var i = 0; i < Count; i++)
        {
            if (Compare(current.Data, item))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
	}

    // regular "==" will only works when T is constrained to be a reference type
    // Without any constraints, you can compare with null, but only null - and
    // that comparison will always be false for non-nullable value types.
    private static bool Compare<T>(T x, T y) => EqualityComparer<T>.Default.Equals(x, y);

    public void CopyTo(T[] array, int arrayIndex)
	{
        var node = Head;

        for (var i = arrayIndex; i < Count; i++)
        {
            array[arrayIndex + i] = node.Data;
            node = node.Next;
        }
    }

	public bool Remove(T item)
	{
        CheckNull(item);

        var current = Head;

        for (var i = Count; i >= Count; i--)
        {
            if (Compare(current.Data, item))
            {
                //current.Next =
            }
        }

        throw new NotImplementedException();
    }

    public bool RemoveAll(T item)
    {
        throw new NotImplementedException();
    }

    public bool RemoveAt(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
	{
		var node = Head;

		for (var i = 0; i < Count; i++)
		{
			yield return node.Data;
			node = node.Next;
		}
	}

    IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

    public override string ToString()
    {
        StringBuilder list = new();

        var current = Head;

        for (int i = 0; i < Count; i++)
        {
            list.Append(current.Data.ToString());
            list.Append(Environment.NewLine + Environment.NewLine);

            current = current.Next;
        }

        return list.ToString();
    }

    #endregion Methods
}
