using Lab1.Node;
using System.Collections;

namespace Lab1.CircularLinkedList;

public class CircularLinkedList<T> : ICollection<T>, ICollection, IEnumerable<T>
{
	public CircularLinkedListNode<T>? Head;
	//public CircularLinkedListNode<T>? Tail;

	public int Count { get; private set; }

	public bool IsReadOnly => throw new NotImplementedException();

	public bool IsSynchronized => throw new NotImplementedException();

	public object SyncRoot => throw new NotImplementedException();

	public CircularLinkedList()
	{
		Head = null;
		//Tail = null;
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
		//Tail = node;
		//Tail.Next = node;

		Count++;
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

		if (Count == 0)
		{
			Head = node;
			//Tail = node;
			Count++;
		}

		//Tail.Next = node;
		//Tail = node;
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


	public IEnumerator GetEnumerator()
	{
		var current = Head;
		while(current != null)
		{
			yield return current;
			current = current.Next;
		}
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		return (IEnumerator<T>)GetEnumerator();
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
