namespace EvenLines
{
    using System;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            char[] cArray = { '-', ',', '.', '!', '?' };
            int lineCount = 0;
            string line;
            StringBuilder stringBuild = new StringBuilder();
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                
                
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (lineCount % 2 == 0)
                    {
                        foreach (char c in line)
                        {
                            if (cArray.Contains(c))
                            {
                                line = line.Replace(c, '@');
                                
                            }
                        }
                        var temp = line
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .Reverse()
                                    .ToArray();
                        stringBuild.AppendLine(string.Join(' ', temp));


                    }
                    lineCount++;
                   
                }
            }


            return stringBuild.ToString();
        }
    }
}
