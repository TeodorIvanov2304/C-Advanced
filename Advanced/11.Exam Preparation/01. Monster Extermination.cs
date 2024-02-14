namespace _01._Monster_Extermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> armor = new Queue<int>(Console
                .ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Stack<int> strength = new Stack<int>(Console
                .ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());
            int monstersKilled = 0;
            while (armor.Count > 0 && strength.Count > 0)
            {
                if (armor.Peek() <= strength.Peek())
                {
                    monstersKilled++;
                    int remainingStrength = strength.Pop()- armor.Dequeue();
                    if (remainingStrength>0)
                    {   

                        //Даваше грешки, защото се опитваше да е Pop-не празен стак
                        if (strength.Count>0)
                        {
                            remainingStrength += strength.Pop();
                        }
                        
                        strength.Push(remainingStrength);
                    }

                }
                else if (armor.Peek() > strength.Peek())
                {
                    int remainingArmor = armor.Dequeue() - strength.Pop();
                    armor.Enqueue(remainingArmor);
                }
            }

            if (armor.Count == 0)
            {
                Console.WriteLine("All monsters have been killed!");
            }
            if(strength.Count == 0) 
            {
                Console.WriteLine("The soldier has been defeated.");
            }
            Console.WriteLine($"Total monsters killed: {monstersKilled}");
        }
    }
}