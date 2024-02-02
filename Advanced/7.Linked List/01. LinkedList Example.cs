namespace _01._LinkedList_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Създаваме LinekdList
            LinkedList<int> linkedList = new LinkedList<int>();
            //Добавяме на последното място
            linkedList.AddLast(5);
            linkedList.AddLast(2);
            linkedList.AddLast(1);
            linkedList.AddLast(8);
            linkedList.AddLast(3);

            LinkedListNode<int> node = linkedList.First;

            //Обхождане на свързан списък
            //Докато следващият елемент на node е различен от 0, т.е не е последен
            while (node != null) 
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }

            //Може да се обходи и с foreach

            foreach (var currentNode in linkedList)
            {
                Console.WriteLine(currentNode);
            }
        }
    }
}