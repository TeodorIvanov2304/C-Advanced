namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            //Незнайно по каква причина, когато беше double, не работи!
            Dictionary<string,List<decimal>> grades = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < students; i++)
            {   
                string[] nameAndGrade = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = nameAndGrade[0];
                //Незнайно по каква причина, когато беше double, не работи!
                decimal grade = decimal.Parse(nameAndGrade[1]);

                if (!grades.ContainsKey(name))
                {   
                    //Добавяме нов List<double> в който да държим оценките
                    grades.Add(name, new List<decimal>());
                    grades[name].Add(grade);
                }
                else
                {
                    grades[name].Add(grade);
                }
            }

            foreach (KeyValuePair<string, List<decimal>> student in grades)
            {
                // Използваме student.Value.Select(grade => grade.ToString("F2"))) за да форматираме до 2 цифра след десетичната запетая!
                Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value.Select(grade => grade.ToString("F2")))} (avg: {student.Value.Average():F2})");
            }
        }
    }
}