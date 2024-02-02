namespace _03._Custom_LinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            Node node1 = new Node(1);
            //С node.Next можем да пълним LinkedList
            node1.Next = new Node(2);
            node1.Next.Next = new Node(3);

            //Можем да го пълним, и като създаваме следващият Node, и ми даваме стойност
            Node node4 = new Node(4);

            //Въртим по свързания списък
            while (node1 != null) 
            {
                Console.WriteLine(node1.Value);
                node1 = node1.Next;
            }

            Console.WriteLine("****************************");
            SoftUniLinkedList linkedList = new SoftUniLinkedList();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);
            linkedList.AddFirst(0);
            linkedList.AddFirst(-1);

            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            
            Node node = linkedList.Head;
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
            Console.WriteLine("--------------");
            linkedList.ForEach(n => Console.WriteLine(n));
            Console.WriteLine("--------------");
            int[] array = linkedList.ToArray();
            Console.WriteLine(string.Join(' ', array));
        }
    }
}