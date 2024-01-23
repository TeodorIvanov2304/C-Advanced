namespace DirectoryTraversal
{
    using System;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            var reportContent = TraverseDirectory(path);
            

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static Dictionary<string,List<FileInfo>> TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, List<FileInfo>> fileDirectory = new Dictionary<string, List<FileInfo>>();
            //Чете всички файлове от въпросната папка и ги записва в стринг масив
            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (string file in files) 
            {   
                //Създаваме променлива от типа Fileinfo, за да вземем информация за файловете
                FileInfo info = new FileInfo(file);
                //Създаване стринг extensiong, който ще пази информацията за extensionite(.doc, .txt,.bin)
                //за файловете които търсим. Достъпваме го с .Extension, методи на класа FileInfo
                string extension = info.Extension;
                if (!fileDirectory.ContainsKey(extension))
                {
                    fileDirectory.Add(extension, new List<FileInfo>());

                }

                fileDirectory[extension].Add(info);
            }
            
            return fileDirectory;
        }

        public static void WriteReportToDesktop(Dictionary<string,List<FileInfo>> fileDictionary, string reportFileName)
        {
            //Съвздаваме writer, като път му задаваме (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), което ни кара директно на Desktop!!!
            //С Path.Combine конкатенираме директорията и името на пътя
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            using StreamWriter writer = new StreamWriter(path);

            //Подреждаме в условието на foreach по брой на файловете с дадения extension, a после по ключ(име)
            foreach (var item in fileDictionary.OrderByDescending(x=>x.Value.Count).ThenBy(x=>x.Key))
            {   
                //Записваме с writer ключа (.cs. , .txt)
                writer.WriteLine(item.Key);

                //Пускаме още един foreach, който върти по файловете в дадения extension, като ги подреждаме по големина (length)
                foreach (var file in item.Value.OrderBy(f=>f.Length))
                {   
                    //Записваме името на файла, после размера му, като го кастваме към double и делим на 1024 за да намерим размера в kb
                    writer.WriteLine($"-- {file.Name} - {Math.Ceiling((double)file.Length/1024)}kb");
                }
            }
        }
    }
}
