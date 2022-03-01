namespace Lab1.Node;

public class CircularLinkedListNode<T>
{
    private T data;
    private CircularLinkedListNode<T>? next;

    public CircularLinkedListNode(T d)
    {
        data = d;
        next = null;
    }
}
