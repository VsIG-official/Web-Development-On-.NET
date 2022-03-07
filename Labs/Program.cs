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
        list.AddAt(4, 1);

        Console.WriteLine(list.ToString());
    }
}
