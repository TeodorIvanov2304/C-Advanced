using System.Transactions;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                        .ToArray();

            //Ако сумата от char-овете е равна на търсената сума. Кратък запис
            //Func<string, int, bool> function = (name, sum) => name.Sum(ch => ch) == sum;
            Func<string, int, bool> checkSum = (name, sum) =>
            {
                int charSum = name.Sum(ch => ch);
                return charSum >= sum;              //Връща bool
            };

            Func<string[], int, Func<string, int, bool>, string> getFirstName =
                // Кратък запис. Дай ми името(FirstOrDefault), което отговаря на функцията, а на функцията подай името и сумата?               
                // (names, sum, match) => names.FirstOrDefault(name => match(name, sum));
                (names, sum, match) =>
                {
                    foreach (string name in names) 
                    {
                        if (match(name,sum))
                        {
                            return name;
                        }
                    }

                    return default;
                };

            string foundName = getFirstName(names,number,checkSum);
            Console.WriteLine(foundName);
        }
    }
}