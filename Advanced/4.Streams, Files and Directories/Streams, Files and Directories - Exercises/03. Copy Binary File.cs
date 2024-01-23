namespace CopyBinaryFile
{
    using System;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            //Създаваме нов FileStream,който ще чете, и му подаваме параметри входа на инпута, да се отвори, и да се чете
            using (FileStream imageToCopy = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                //Създавме нов FileStream, който ще записва и му подаваме пътя за записване, FileMode създаване, и достъп до файла, записване (FileAccess.Write
                using (FileStream copiedImage = new FileStream(outputFilePath,FileMode.Create,FileAccess.Write))
                {
                                    //подаваме му размер 4096
                    byte[] buffer = new byte[4096];
                    int bytesRead;

                    //Стартираме while, който ще работи докато стигнем крайната дължина на буфера(buffer.Length). На Read се подават самия буфер, прескачане 0, и дължината на буфера, и той ще работи, докато е по-голямо от 0
                    while ((bytesRead = imageToCopy.Read(buffer,0,buffer.Length))>0)
                    {   
                        //Започваме да записваме копираното изображение, като му подаваме буфера, отместване 0 и четящите се в момента байтове
                        copiedImage.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}
