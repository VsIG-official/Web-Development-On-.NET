using Lab1.CircularLinkedListNode;
using System.Collections;

namespace Lab1.CircularLinkedList;

public class CircularLinkedList<T> : ICollection<T>, IEnumerable
{
	public CircularLinkedListNode<T>? Head { get; private set; }
	public CircularLinkedListNode<T>? Tail { get; private set; }

	public int Count { get; private set; }

	public bool IsReadOnly => false;

	public CircularLinkedList()
	{
		Head = null;
		Tail = null;
	}

	public CircularLinkedList(T item)
	{
		SetHead(item);
	}

	private void SetHead(T item)
	{
		var node = new CircularLinkedListNode<T>(item);

		Head = node;
		Head.Next = node;
		Tail = node;
		Tail.Next = node;

		Count++;
	}

	public void AddFirst(T item)
	{
		if (IsEmpty())
		{
			SetHead(item);
			return;
		}

		Head = new CircularLinkedListNode<T>(item)
		{
			Next = Head
		};

		Count++;

        SetTail();
	}

    private bool IsEmpty()
    {
        if (Count == 0)
        {
            return true;
        }

        return false;
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

	public void Add(T item)
	{
		throw new NotImplementedException();
	}

	public void Clear()
	{
		throw new NotImplementedException();
	}

	public bool Contains(T item)
	{
		throw new NotImplementedException();
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public bool Remove(T item)
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
}
