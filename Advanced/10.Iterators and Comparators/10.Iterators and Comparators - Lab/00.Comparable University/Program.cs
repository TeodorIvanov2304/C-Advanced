namespace _00.ComparableUnivercity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            University softUni = new University()
            {
                AverageScore = 6,
                Students = new List<string>() {"1","2","3" },
                Name = "Softuni"
            };

            University MIT = new University()
            {
                AverageScore = 4.5,
                Students = new List<string>() { "1", "3" },
                Name = "MIT"
            };

            //Инициализираме сравнението
            Console.WriteLine(softUni.CompareTo(MIT)); //1
        }
    }

    //Като даваме constraint IComparable, в скобите <> даваме по какво искаме да се сравнява, в случая University
    class University : IComparable<University>
    {
        public string Name { get; set; }
        public List<string> Students { get; set; }

        public double AverageScore { get; set; }

        // other e другият университет, нашият е this
        public int CompareTo(University? other)
        {   
            //Ако е по-голямо, връща 1. Цифрите са по default!
            if (AverageScore > other.AverageScore)
            {
                return 1;
            }
            //Ако е == , връща 0
            else if (AverageScore == other.AverageScore)
            {
                return 0;
            }
            //Ако е < връща - 1
            else 
            {
                return -1;
            }

            //Така трябва да се използва по принцип метода, горното е за пояснение
            //return AverageScore.CompareTo(other.AverageScore);
        }
    }
}