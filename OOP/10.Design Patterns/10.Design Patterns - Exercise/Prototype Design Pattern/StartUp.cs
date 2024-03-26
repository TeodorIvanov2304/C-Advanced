using Prototype_Design_Pattern.Models;

namespace Prototype_Design_Pattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Student dmitrii = new Student("Dmitrii", "Kolarov", new DateTime(year: 2000, month: 1, day: 10));
            dmitrii.Grades = new int[] { 6, 6, 6 };
            //Създавме копие на dmitrii, като го кастваме преди това
            Student kalitko = (Student)dmitrii.Clone();
            kalitko.FirstName = "Kalitko";
            kalitko.Grades[0] = 2;
            kalitko.Grades[2] = 2;

            Console.WriteLine(dmitrii);
            Console.WriteLine(kalitko);
        }
    }
}