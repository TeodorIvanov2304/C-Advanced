namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            
            //Пишем using, и създавем нов StreamReader, като в скобите пишем@$" тук е целият път, + окончанието на файла"
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                
                //Пишем using, и създаваме StreamWriter, като вместо пътя използваме името на стринга,в който е записан пътя
                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    int line = 1;

                    //Пускаме while-loop, който върти, докато не даде EndOfStream, т.е стигне до последния ред
                    while (!reader.EndOfStream)
                    {
                        //Запазваме, като вместо Console.ReadLine() пишем writer.ReadLine
                        writer.WriteLine($"{line++}. {reader.ReadLine()}");
                    }
                }

                
            }
        }
    }
}
