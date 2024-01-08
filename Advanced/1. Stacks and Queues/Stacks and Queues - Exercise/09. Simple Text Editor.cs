using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int operations = int.Parse(Console.ReadLine());
            string text = "";
            Stack<string> states = new Stack<string>();
            for (int i = 0; i < operations; i++)
            {
                string[] inputCommands = Console.ReadLine().Split().ToArray();
                string command = inputCommands[0];

                switch (command)
                {
                    case "1": //Add
                        string textToadd = inputCommands[1];
                        //След добавяне на текст, добавяме състоянитео на текущия текст в стака
                        states.Push(text);
                        text += textToadd;
                        break;
                    case "2": //Erase
                        int count = int.Parse(inputCommands[1]);
                        //Добавяме текущото състояние на текста след редакцията в стака
                        states.Push(text);
                        text = text.Substring(0, text.Length-count);
                        
                        break;  
                    case "3": // Print at index

                        int index = int.Parse(inputCommands[1]);
                        //Изпечатваме дикректно индекса, като пишем -1, защото индексите започват от 0!
                        Console.WriteLine(text[index-1]);
                        break;
                    case "4"://Undo
                        //Връщаме предишното състояние на текста от стака
                        text = states.Pop();
                        break;
                }
            }
        }
    }
}