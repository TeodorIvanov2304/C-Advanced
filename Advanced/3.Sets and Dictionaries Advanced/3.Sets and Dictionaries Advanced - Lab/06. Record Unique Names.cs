namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Четем броя на имената от конзолата
            int numberOfNames = int.Parse(Console.ReadLine());
            //Създаваме колекция от тип HashSet<string>
            HashSet<string> names = new HashSet<string>();

            
            for (int i = 0; i < numberOfNames; i++)
            {   
                //Добавяме от конзолата направо в хешсета
                names.Add(Console.ReadLine());
            }

            //Изпечатваме с нов ред и string.Join
            //Console.WriteLine(string.Join("\n", names));

        }
    }
}