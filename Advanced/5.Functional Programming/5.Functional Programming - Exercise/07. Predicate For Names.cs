namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            
            Predicate<string> predicate = x => x.Length <= length;
            //Ако се направи с предикат, няма да е чиста функция. Ако се използва повече от една променлива, се използва Func, като параметрите се слгат в скоби, както по-долу
            //Func<string,int,bool> predicate2 = (x,i) => x.Length <= length;
            string[] sorted = names.Where(n=>predicate(n)).ToArray();
            Console.WriteLine(string.Join("\n",sorted));
        }
    }
}