namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, List<Tires> tires)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = new List<Tires>();
        }

        public string Model { get; set; }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public List<Tires> Tires { get; set; }
    }
}
