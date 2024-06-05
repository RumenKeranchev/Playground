namespace LinkedLists
{
    using System.Collections;

    /// <summary>
    /// Double linked list
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DLinkedList<T> : IEnumerable<Node<T>>
    {
        private Node<T>? head = null;

        public void AddAfter(Node<T>? prevNode, T content)
        {
            ArgumentNullException.ThrowIfNull(prevNode);

            var newNode = new Node<T>(content)
            {
                Next = prevNode.Next
            };
            prevNode.Next = newNode;
            newNode.Prev = prevNode;

            if (newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }
        }

        public void AddBefore(Node<T>? nextNode, T content)
        {
            ArgumentNullException.ThrowIfNull(nextNode);

            var newNode = new Node<T>(content)
            {
                Prev = nextNode.Prev,
            };
            nextNode.Prev = newNode;
            newNode.Next = nextNode;

            if (newNode.Prev != null)
            {
                newNode.Prev.Next = newNode;
            }
        }

        public void AddFirst(T content)
        {
            var newNode = new Node<T>(content)
            {
                Next = head
            };

            if (head != null)
            {
                head.Prev = newNode;
            }

            head = newNode;
        }

        public void AddLast(T content)
        {
            var newNode = new Node<T>(content);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node<T>? lastNode = GetLastNode();
            if (lastNode != null)
            {
                lastNode.Next = newNode;
            }

            newNode.Prev = lastNode;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            Node<T>? currentNode = head;

            while (currentNode is not null)
            {
                yield return currentNode;
                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Node<T>? Find(T content)
        {
            var currentNode = head;
            while (currentNode is not null)
            {
                if (currentNode.Content!.Equals(content))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        private Node<T>? GetLastNode()
        {
            Node<T>? temp = head;

            while (temp?.Next != null)
            {
                temp = temp.Next;
            }

            return temp;
        }
    }
}
