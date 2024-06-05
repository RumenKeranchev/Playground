using LinkedLists;

var dll = new DLinkedList<double>();

dll.AddLast(1);
dll.AddLast(2);
dll.AddLast(3);
dll.AddLast(4);
dll.AddLast(5);
dll.AddFirst(0);

var secondToLast = dll.Find(4);

dll.AddBefore(secondToLast, 3.5);
dll.AddAfter(secondToLast, 4.5);

foreach (var item in dll)
{
    Console.WriteLine(item.Content);
}