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

        Console.WriteLine(list.Contains(1));
        Console.WriteLine(list.Contains(2));
        Console.WriteLine(list.Contains(3));
        Console.WriteLine(list.Contains(4));

        Console.WriteLine("////");
	}
}
