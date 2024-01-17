namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            //Създаваме хешсет
            HashSet<string> parking = new HashSet<string>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputArgs = input.Split(", ");
                string direciton = inputArgs[0];
                string carNumber = inputArgs[1];

                //Ако посоката е IN, добавяме кола с функцията Add
                if (direciton == "IN")
                {
                    parking.Add(carNumber);
                }
                //Ако е OUT, премахваме кола с Remove
                else
                {
                    parking.Remove(carNumber);
                }


            }

            if (parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string car in parking)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}