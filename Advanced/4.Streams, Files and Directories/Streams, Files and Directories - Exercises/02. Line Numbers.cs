namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            //Четем всичко наведнъж с File.ReadAllLines(inputFilePath);
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                
                //С метода where, се казва където, char.IsLetter всичко което е букв, Count() изброй
                int lettersNumber = lines[i].Where(char.IsLetter).Count();
                //По същия начин, но където е пунктуация
                int symbolsNumber = lines[i].Where(char.IsPunctuation).Count();
                lines[i] = @$"Line {i + 1}: {lines[i]} ({lettersNumber}) ({symbolsNumber})";
            }

            //Записваме във файл, като първо подаваме къде да се запише, после какво (lines)
            File.WriteAllLines(outputFilePath,lines);
        }
    }
}
