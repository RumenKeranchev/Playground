namespace LinkedLists
{
    public class Node<T>(T data)
    {
        public Node<T>? Prev { get; set; } = null;

        public T Content { get; set; } = data;

        public Node<T>? Next { get; set; } = null;
    }
}
