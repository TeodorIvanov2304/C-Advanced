namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);
            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {   
            //Използваме класа ZipFile и му даваме Open, като му подаваме пътя към файла, и му даваме ZipArchiveMode.Create
            using (var archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create))
            {   
                //Записваме името на файла
                var fileName = Path.GetFileName(zipArchiveFilePath);
                //Казваме на променливата archive да нарпави Zip, като й подаваме пътя към файла и името което ще има
                archive.CreateEntryFromFile(inputFilePath,fileName);
            }

        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {   
            //Отваряме вече архивирания файл за четене
            using var archive = ZipFile.OpenRead(zipArchiveFilePath);
            //Взимаме отворения архивиран файл, и го слагаме в отделна променлива
            var extraction = archive.GetEntry(fileName);
            //Екстрактваме го
            extraction.ExtractToFile(outputFilePath);
        }
    }
}
