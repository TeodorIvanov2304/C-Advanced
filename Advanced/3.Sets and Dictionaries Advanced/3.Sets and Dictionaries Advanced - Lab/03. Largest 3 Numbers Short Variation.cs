namespace _03._Largest_3_Numbers_Short_Variation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Чейнваме .Take(3), като 3 е бр. на желаните цифри, т.е трите най-големи
            List<int> largestThreeNumbers = Console.ReadLine()
                                            .Split()
                                            .Select(int.Parse)
                                            .OrderByDescending(x => x)
                                            .Take(3) 
                                            .ToList();

            Console.WriteLine(string.Join(" ",largestThreeNumbers));

        }
    }
}