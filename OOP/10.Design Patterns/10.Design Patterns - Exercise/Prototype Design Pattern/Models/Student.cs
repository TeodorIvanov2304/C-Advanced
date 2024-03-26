using Prototype_Design_Pattern.Interfaces;

namespace Prototype_Design_Pattern.Models
{
    public class Student : IPrototype
    {
        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int[] Grades { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} born on {DateOfBirth}. Grades: {string.Join(", ",Grades)}";
        }

        public object Clone()
        {
            //Създаваме кухо копие на обекта и го връщаме. Shallow copy copies only value types.No reference types
            // 1 синтаксис
            // Student temp = (Student)MemberwiseClone();
            // 2 синтаксис
            Student temp = MemberwiseClone() as Student;
            //We need to handle the reference types (int[])
            temp.Grades = new int[Grades.Length];

            for (int i = 0; i < Grades.Length; i++)
            {
                temp.Grades[i] = this.Grades[i];
            }

            return temp ;
        }

    }
}
