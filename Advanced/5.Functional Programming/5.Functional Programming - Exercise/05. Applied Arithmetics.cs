using System;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                                           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(int.Parse)
                                           .ToList();
            Func<int, int> operations = x => x;
            Action<List<int>> print = numbers => Console.WriteLine(string.Join(' ', numbers));
            string command = "";
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":

                        operations = x => x + 1;

                        break;
                    case "multiply":

                        operations = x => x * 2;
                        break;
                    case "subtract":
                        operations = x => x - 1;
                        break;
                    case "print":
                        // Директно извикаме Action<List<int>> , като подваме името на масива. Правеше проблем, защото в Action<> трябва да е същият тип, както в колекцията с числата
                        print(numbers);
                        //Слагаме continue , защото иначе ще повтори операцията, написана по-долу
                        continue;
                        
                }
                //Ако не му дадем ToList(),не прави нищо
                //numbers = numbers.Select(x=>operations(x)).ToList();
                //numbers = numbers.Select(operations).ToList()
                numbers = numbers.Select(operations).ToList();
            }
        }
    }
}