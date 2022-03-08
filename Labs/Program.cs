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

        list.Remove(3);

        Console.WriteLine(list.ToString());
        Console.WriteLine();
        Console.WriteLine(list.Head.Data);
        Console.WriteLine(list.Tail.Data);
    }
}
