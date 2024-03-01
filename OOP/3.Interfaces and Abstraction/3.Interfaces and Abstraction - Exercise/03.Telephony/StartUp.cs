using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {   
            //Read phone numbers
            string[] phoneNumbers = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //Read URL's
            string[] urls = Console.ReadLine()
                                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            //Create ICallable variable
            ICallable phone;

            foreach (string phoneNumber in phoneNumbers)
            {   
                //If the phone is  10 numbers, create a smartphone
                if (phoneNumber.Length == 10)
                {
                    phone = new Smartphone();
                }
                //If is 7 numbers create ordinary phone
                else
                {
                    phone = new StationaryPhone();
                }

                try
                {
                    Console.WriteLine(phone.Call(phoneNumber));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            //Create IBrowsable variable
            IBrowsable smartphone = new Smartphone();

            //Browse all urls, if they are valid
            foreach (string url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}