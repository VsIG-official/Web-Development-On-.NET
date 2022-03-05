using Lab1.CircularLinkedList;

namespace Labs;

internal class Program
{
    private static void Main()
	{
		CircularLinkedList<string> list = new();

        list.AddFirst("1");
        list.AddFirst("2");
        list.AddFirst("3");
        list.AddFirst("4");

        Console.WriteLine(list[0] = null);
        Console.WriteLine(list[0]);

        Console.WriteLine(list.ToString());
    }
}
