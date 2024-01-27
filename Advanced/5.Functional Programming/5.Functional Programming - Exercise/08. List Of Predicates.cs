namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bound = int.Parse(Console.ReadLine());
            List<int> ints = new List<int>(bound);
            for (int i = 1; i <= bound; i++)
            {
                ints.Add(i);
            }

            List<int> divisors = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToList();

            //Създваме функция, от List,int, bool, като за bool създаваме променлива вътре в ламбдата и й 
            // даваме return
            Func<List<int>,int, bool> func = (arr,i) => 
            {
                bool isDivisible = true;

                //Правим foreach на всичките делители
                foreach (var number in divisors)
                {   
                    //Ако не се дели без остатък, връщаме false
                    if (i % number != 0)
                    {
                        return false;
                    }
                }
                return isDivisible;
            };

            //Подаваме на func делителите, и текущото число number(n,x,i и т.н)
            var sorted = ints.Where(n => func(divisors, n));

            Console.WriteLine(string.Join(' ',sorted));
        }
    }
}