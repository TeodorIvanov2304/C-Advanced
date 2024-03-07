using Raiding.Models;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<BaseHero> heroeList = new List<BaseHero>();
            int heroCount = int.Parse(Console.ReadLine());

            while (heroeList.Count < heroCount)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                switch (heroType)
                {
                    case "Druid":
                        heroeList.Add(new Druid(heroName));
                        break;
                    case "Paladin":
                        heroeList.Add(new Paladin(heroName));
                        break;
                    case "Rogue":
                        heroeList.Add(new Rogue(heroName));
                        break;
                    case "Warrior":
                        heroeList.Add(new Warrior(heroName));
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        //Another hero!
                        break;
                }
            }

            int result = 0;
            int bossPower = int.Parse(Console.ReadLine());

            foreach (var hero in heroeList)
            {
                result += hero.Power;
                Console.WriteLine(hero.CastAbility());
                
            }
            Console.WriteLine(result >= bossPower ? "Victory!" : "Defeat...");

        }
    }
}