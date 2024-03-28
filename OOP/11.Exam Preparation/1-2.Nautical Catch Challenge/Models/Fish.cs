using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System.Net.Mime;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        private string name;
        private double points;
        private int timeToCatch;

        protected Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
        }

        public string Name 
        {
            get => name; 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {   
                    //Добавяме първо ExeptionMessages, за да ни даде достъп до съобщенията.
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                name = value;
            }
        }

        public double Points 
        {
            get => points;
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }
                this.points = value;
            }
        }

        public int TimeToCatch
        {
            get => timeToCatch; 
            private set  // Тук беше само set, без private set, и ми сваляше 7 т.
            { 
                timeToCatch = value;
            }
        }

        public override string ToString()
        {

            //Алтернатива на this.GetType().Name. Трябва да покрием с if-else всичките видове риби:
            //if (this is ReefFish)
            //{
            //    typeName = "ReefFish";
            //}

            //Взимаме типа на рибата с this.GetType().Name
            return $"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]";
        }
    }
}
