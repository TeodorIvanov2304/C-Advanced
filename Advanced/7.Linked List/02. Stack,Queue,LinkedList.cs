using System.Net;

namespace _02._Stack_Queue_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> linkedList = new LinkedList<string>();
            Queue<string> queue = new Queue<string>();

            //Enqueue е еквивалентно на AddLast
            queue.Enqueue("Garo");
            linkedList.AddLast("Garo");

            queue.Enqueue("Bace");
            linkedList.AddLast("Bace");

            queue.Enqueue("Amador");
            linkedList.AddLast("Amador");

            queue.Enqueue("Fermin");
            linkedList.AddLast("Fermin");

            queue.Enqueue("Antonio Recio");
            linkedList.AddLast("Antonio Recio");

            while (queue.Count != 0) 
            {
                string element = queue.Dequeue();
                Console.WriteLine($"Queue: {element}");
            }

            Console.WriteLine("*****************************");
            //Винаги така записваме node, като го създаваме
            LinkedListNode<string> node = linkedList.First;

            while (node != null)
            {
                Console.WriteLine($"Linked list: {node.Value}");
                linkedList.RemoveFirst();
                node = linkedList.First; 
            }
            Console.WriteLine("--------------");
            LinkedList<string> linkedList2 = new LinkedList<string>();
            Stack<string> stack = new Stack<string>();

            stack.Push("Mara");
            linkedList2.AddFirst("Mara");

            stack.Push("Yavor");
            linkedList2.AddFirst("Yavor");

            stack.Push("Joji");
            linkedList2.AddFirst("Joji");

            stack.Push("Modjo Djodjo");
            linkedList2.AddFirst("Modjo Djodjo");

            while (stack.Count != 0)
            {
                string element = stack.Pop();
                Console.WriteLine($"Stack: {element}");
            }
            Console.WriteLine("--------------");
            node = linkedList2.First;

            while (node != null) 
            {
                Console.WriteLine($"Linked list 2: {node.Value}");
                linkedList2.RemoveFirst();
                node = linkedList2.First;
            }
        }
    }
}