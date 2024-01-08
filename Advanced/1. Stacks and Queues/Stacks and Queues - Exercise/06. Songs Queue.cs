namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ");
                
            Queue<string> songsQueue = new Queue<string>(songs);

            while (songsQueue.Count>0) 
            {
                string[] commandsArgs = Console.ReadLine().Split().ToArray();

                switch (commandsArgs[0]) 
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;
                    case "Add":

                        //Създаваме променлива, която пази текущата песен за добавяне. Използваме string.Join и Skip(1), за да пропуснем командата(1) от масива 
                        string songToAdd = string.Join(" ", commandsArgs.Skip(1));
                        if (songsQueue.Contains(songToAdd))
                        {
                            Console.WriteLine($"{songToAdd} is already contained!");
                        }
                        else
                        {
                            songsQueue.Enqueue(songToAdd);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songsQueue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}