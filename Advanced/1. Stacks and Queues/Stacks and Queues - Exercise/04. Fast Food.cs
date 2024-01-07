namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());

            int[] ordersArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(ordersArr);
            int maxOrder = orders.Max();
            Console.WriteLine(maxOrder);

            //С foreach даваше Runtime Error
            while (orders.Count>0 && foodQuantity>0)
            {
                int currentOrder = orders.Peek();

                if (foodQuantity>= currentOrder)
                {
                    orders.Dequeue();
                    foodQuantity-=currentOrder;
                }
                //Ако храната свърши, излизаме от цикъла
                else
                {
                    break;
                }    
            }

            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else if(orders.Count > 0) 
            {
                Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
            }
        }
    }
}