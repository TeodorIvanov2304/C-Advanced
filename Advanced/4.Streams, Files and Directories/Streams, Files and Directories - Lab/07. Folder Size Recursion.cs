namespace FolderSize
{
    public class FolderSize
    {
        static void Main()
        {   
            //Записваме пътя на тестовата папка и файла, в който ще записваме
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            //Викаме функцията, която ще смята размера и й подаваме folderPath, outputPath
            GetFolderSize(folderPath, outputPath);
        }

        //Функция, която намира размера на папката
        public static void GetFolderSize(string folderPath, string outputFilePath)
        {   
            //long променлива siez, коят вика функцията, четяща папките
            long size = ReadFolder(folderPath);

            //Създаваме StreamWriter и изпечатваме с него, /1024 за да намерим размера в кб
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine($"{size / 1024.0}kb");
            }
        }

        //Функция, която чете папките и смята размера им
        public static long ReadFolder(string folderPath, int levels = 0)
        {
            //Създаваме масив от файлове, който с методите Directory.GetFiles(folderPath) взима колкото файла има във folderPath
            string[] files = Directory.GetFiles(folderPath);
            //Променлива от тип лонг, която ще събира размерите
            long size = 0;
            //За всеки файл, в масива файлс
            foreach (string file in files) 
            {   
                //Извикваме класа Fileinfo, и създаваме инстанция към него, като й подаваме file
                FileInfo fileInfo = new FileInfo(file);
                //Добавяме размера на инстанцията, която се намира с fileInfo.Length;
                size += fileInfo.Length;

            }

            //Масив директории, извикваме класа Directory, и метода му GetDirectories, който връща масив от поддиректории от folderPath
            string[] directories = Directory.GetDirectories(folderPath);

            //За всяка директория директории
            foreach (var dir in directories)
            {   
                //Добавяме към общите kb размера на текущата директория и ?ниво + 1?
                size += ReadFolder(dir, levels + 1);
            }

            return size;
        }
    }
}
