namespace NauticalCatchChallenge.Models
{
    public class ReefFish : Fish
    {
        private const int TimeToCatchReefFish = 30;
        //Премахваме timeToCatch от конструктора и му задаваме нова стойност 30 в base
        public ReefFish(string name, double points) : base(name, points, TimeToCatchReefFish)
        {

        }
    }
}
