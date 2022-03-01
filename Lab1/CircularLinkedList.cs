using Lab1.Node;
using System.Collections;

namespace Lab1.CircularLinkedList;

public class CircularLinkedList<T> : ICollection<T>, ICollection
{
	public CircularLinkedListNode<T> Head;

	#region ICollection<T>

	public int Count => throw new NotImplementedException();

	public bool IsReadOnly => throw new NotImplementedException();

	#endregion ICollection<T>

	#region ICollection

	public bool IsSynchronized => throw new NotImplementedException();

	public object SyncRoot => throw new NotImplementedException();

	#endregion ICollection

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

	#region ICollection

	public void CopyTo(Array array, int index)
	{
		throw new NotImplementedException();
	}

	#endregion ICollection

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
