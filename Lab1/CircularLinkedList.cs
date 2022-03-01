using Lab1.Node;
using System.Collections;

namespace Lab1.CircularLinkedList;

public class CircularLinkedList<T> : ICollection<T>, ICollection
{
	public CircularLinkedListNode<T>? Head;
	public CircularLinkedListNode<T>? Last;

	public int Count { get; private set; }

	public bool IsReadOnly => throw new NotImplementedException();

	public bool IsSynchronized => throw new NotImplementedException();

	public object SyncRoot => throw new NotImplementedException();

	public CircularLinkedList()
	{
		Head = null;
		Last = null;
	}

	public void Add(T item)
	{
		throw new NotImplementedException();
	}

	public void AddFirst(T item)
	{
		CircularLinkedListNode<T> node = new(item);

		node.Next = Head;
		Head = node;

		if (Last == null)
		{
			CircularLinkedListNode<T> tempNode = Head;

			while (tempNode.Next != null)
			{
				tempNode = tempNode.Next;
			}

			Last = tempNode;
		}

		Last.Next = Head;

		Count++;
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

	public void CopyTo(Array array, int index)
	{
		throw new NotImplementedException();
	}

	public IEnumerator<T> GetEnumerator()
	{
		throw new NotImplementedException();
	}

	public bool Remove(T item)
	{
		throw new NotImplementedException();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new NotImplementedException();
	}
}
