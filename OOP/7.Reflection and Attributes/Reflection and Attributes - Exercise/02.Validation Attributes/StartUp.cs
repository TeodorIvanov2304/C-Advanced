using System;
using ValidationAttributes.Models;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 null,
                 -1
             );

            var person2 = new Person ("Gogo", 14);

            bool isValidEntity = Validator.IsValid(person);
            bool isValidEntity2 = Validator.IsValid(person2);
            Console.WriteLine(isValidEntity);
            Console.WriteLine(isValidEntity2);
        }
    }
}
