using Lab1.CircularLinkedList;

namespace Labs;

internal class Program
{
    private static void Main()
	{
		CircularLinkedList<int> list = new();

        list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);
        list.AddFirst(4);

        foreach (var item in list)
		{
			Console.WriteLine(item);
		}

        list.Clear();

        Console.WriteLine("////");
	}
}
