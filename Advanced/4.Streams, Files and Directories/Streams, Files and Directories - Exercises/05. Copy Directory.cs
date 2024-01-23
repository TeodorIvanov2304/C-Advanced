namespace CopyDirectory
{
    using System;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {   
            //Ако директорията вече съществува, я изтриваме
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath);
            }
            //Създаваме нова директория, в края на пътя, който ще дойде от конзолата
            Directory.CreateDirectory(outputPath);

            //Създаваме масив, който ще пази файловете от директорията, които взимаме с Directory.GetFiles
            string[] files = Directory.GetFiles(inputPath);

            foreach (string file in files) 
            {   
                //Взимаме имената на файловете
                string fileName = Path.GetFileName(file);
                //Комбинираме пътя, за да запазим директорията, в която ще местим копираните файлове
                string destination = Path.Combine(outputPath,fileName);
                //С File.Copy местим файловете като подаваме текущия файл и дестинацията
                //Клас File е опростена(абстрактна версия) на StreamReader и StreamWriter
                //За непрекъснато записване и копиране, по-добре да се ползват StreamReader и StreamWriter!
                File.Copy(file, destination);
                
            }
        }
    }
}
