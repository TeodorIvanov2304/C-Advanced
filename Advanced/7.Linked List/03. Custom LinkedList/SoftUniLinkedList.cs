namespace _03._Custom_LinkedList
{
    public class SoftUniLinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public int Count { get; set; }
        public void AddLast(int value)
        {
            Count++;
            Node newNode = new Node(value);

            //Ако Head = null, то и Tail = null
            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            newNode.Previous = Tail;
            Tail.Next = newNode;
            Tail = newNode;
        }

        public void AddFirst(int value)
        {
            Count++;
            Node newNode = new Node(value);

            if (Head == null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }
            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }

        public void RemoveFirst()
        {
            Count--;
            Node newHead = Head.Next;
            newHead.Previous = null;
            Head.Next = null;
            Head = newHead;
        }

        public void RemoveLast()
        {
            Count--;
            Node newTail = Tail.Previous;
            newTail.Next = null;
            Tail.Previous = null;
            Tail = newTail;
        }

        public void ForEach(Action<int> callback)
        {
            Node node = Head;

            while (node != null) 
            {
                callback(node.Value);
                node = node.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;
            Node node = Head;

            while (node != null)
            {
                array[index++] = node.Value;
                node = node.Next;
            }

            return array;
        }
    }
}
