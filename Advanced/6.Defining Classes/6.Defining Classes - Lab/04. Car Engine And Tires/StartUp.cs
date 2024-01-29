namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {   
            //Когато създаваме масив от Tire, трябва да кажем new на всяка една от гумите, и да им подадем year и pressure
            Tire[] tires = new Tire[4]
            {
                new Tire (1,2.5),
                new Tire (1,2.1),
                new Tire (2,0.5),
                new Tire (2,2.3)
            };

            Engine engine = new(560, 6300);

            //engine, tires вече са сетнатти, за това не им подаваме стойност, като напр. "Urus"
            Car car = new("Lamborghini", "Urus", 2010, 250, 9, engine, tires);
        }
    }
}