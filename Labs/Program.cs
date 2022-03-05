using Lab1.CircularLinkedList;

namespace Labs;

internal class Program
{
    private static void Main()
	{
		CircularLinkedList<int> list = new();

        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        foreach (var item in list.Reverse())
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();

        Console.WriteLine(list.ToString());
    }
}
