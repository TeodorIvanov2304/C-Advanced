using BorderControl.Models;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Models.BorderControl borderControl = new();

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputTokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                //If Length is 2, we create a robot
                if (inputTokens.Length == 2)
                {
                    Robot robot = new(inputTokens[1], inputTokens[0]);
                    borderControl.AddForBorderCheck(robot);
                }
                //If Length is 3, we create a citizen
                else
                {
                    Citizen citizen = new(inputTokens[2], inputTokens[0], int.Parse(inputTokens[1]));
                    borderControl.AddForBorderCheck(citizen);
                }
            }

            string fakeIdEndSequance = Console.ReadLine();
            //Using Where and Endswith to find if fakeId digits endings are present in borderControl list
            var detained = borderControl.EntitiesToBeChecked.Where(e => e.Id.EndsWith(fakeIdEndSequance));

            foreach (var baseEntity in detained)
            {
                Console.WriteLine(baseEntity.Id);
            }
        }
    }
}