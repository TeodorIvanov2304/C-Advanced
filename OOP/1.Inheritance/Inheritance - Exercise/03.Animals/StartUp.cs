using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = "";
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //We are catching the exeption from the class properties
                try
                {
                    if (animalType == "Dog")
                    {
                        var doggy = new Dog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        //GetType().Name returns the class name(type)
                        Console.WriteLine(doggy.GetType().Name);
                        Console.WriteLine(doggy);
                        Console.WriteLine(doggy.ProduceSound());
                    }
                    if (animalType == "Cat")
                    {
                        var catto = new Cat(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        //GetType().Name returns the class name(type)
                        Console.WriteLine(catto.GetType().Name);
                        Console.WriteLine(catto);
                        Console.WriteLine(catto.ProduceSound());
                    }
                    if (animalType == "Frog")
                    {
                        var frog = new Frog(animalData[0], int.Parse(animalData[1]), animalData[2]);
                        //GetType().Name returns the class name(type)
                        Console.WriteLine(frog.GetType().Name);
                        Console.WriteLine(frog);
                        Console.WriteLine(frog.ProduceSound());
                    }
                    if (animalType == "Kitten")
                    {
                        var kitten = new Kitten(animalData[0], int.Parse(animalData[1]));
                        //GetType().Name returns the class name(type)
                        Console.WriteLine(kitten.GetType().Name);
                        Console.WriteLine(kitten);
                        Console.WriteLine(kitten.ProduceSound());
                    }
                    if (animalType == "Tomcat")
                    {
                        var tomcat = new Tomcat(animalData[0], int.Parse(animalData[1]));
                        //GetType().Name returns the class name(type)
                        Console.WriteLine(tomcat.GetType().Name);
                        Console.WriteLine(tomcat);
                        Console.WriteLine(tomcat.ProduceSound());
                    }
                }
                //AE stants for argument exeption
                catch (ArgumentException ae)
                {
                    //Using ae.Message
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
