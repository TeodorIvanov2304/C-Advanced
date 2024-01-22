namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {   
            //За да четем от 2 файла едновременно, влагаме 2 рийдъра 1 в друг, в вътре в тях Writer
            using (StreamReader reader = new StreamReader(firstInputFilePath))
            {
                using (StreamReader reader2 = new StreamReader(secondInputFilePath))
                {
                    using (StreamWriter writer = new StreamWriter(outputFilePath))
                    {
                        while (!reader.EndOfStream || !reader2.EndOfStream)
                        {   
                            string reader1Lines = reader.ReadLine();
                            string reader2Lines = reader2.ReadLine();

                            //Ако реда е празен, не записваме нищо
                            if (reader1Lines != null)
                            {
                                writer.WriteLine(reader1Lines);
                            }
                                
                            if (reader2Lines != null)
                            {
                                writer.WriteLine(reader2Lines);
                            }
                                
                        }
                    }
                }
            }
        }
    }
}
