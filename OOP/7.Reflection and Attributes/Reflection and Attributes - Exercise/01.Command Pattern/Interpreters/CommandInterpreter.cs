using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Interpreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] parts = args.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            string command = $"{parts[0]}Command";

            //Взиамаме всичко останало, без първият елемент parts[0]
            string[] commandArgs = parts.Skip(1).ToArray();

            //Целият проект се компилира, и образува едно Assembly
            Assembly assembly = Assembly.GetEntryAssembly();
            //Изпечатваме пълното име на Assembly-то
            //Console.WriteLine(assembly.FullName);
            //Взимаме всички типове от assembly
            //Type[] types = assembly.GetTypes();
            //Взимаме само типа , който е равен на командата
            Type type = assembly?.GetTypes().FirstOrDefault(t=>t.Name == command);
            
            if (type != null)
            {
                Console.WriteLine("Invalid type!");
            }
            //Цъздаваме инстанция на type чрез Activator и го кастваме към ICommand, за да вземе метода Execute
            ICommand instance = (ICommand)Activator.CreateInstance(type);

            //Подаваме на метода Execute масива 
            return instance?.Execute(commandArgs); ;
        }
    }
}
