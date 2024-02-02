namespace _03._Custom_LinkedList
{
    public class Node
    {
        public Node(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        //Референции към класа Node
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public override string ToString()
        {
            return $"{Previous?.Value}<-{Value}->{Next?.Value}";
        }
    }
}
