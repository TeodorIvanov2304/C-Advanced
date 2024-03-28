using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        private string name;
        private int oxygenLevel;
        private List<string> caughtFish;
        private double competitionPoints;
        private bool hasHealthIssues;

        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            caughtFish = new List<string>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                this.name = value;
            }
        }


        public int OxygenLevel
        {
            get 
            { 
                return oxygenLevel;
            }
            protected set //Правим го протектед сет, за да можем да го сетваме от децата(FreeDiver)
            {   
                if (value <= 0)
                {
                    HasHealthIssues = true;
                    oxygenLevel = 0;
                }
                oxygenLevel = value;
            }
        }

        //За външният свят се дава IReadOnlyCollection, но за вътрешна употреба ние ще си напрвим лист, защото трябва да го променяме и да извършваме операции с него
        public IReadOnlyCollection<string> Catch
        {
            get 
            {   
                //Връщаме го като ReadOnly();
                return caughtFish.AsReadOnly();
            }
        }

        public double CompetitionPoints
        {
            get 
            { 
                return competitionPoints; 
            }
            
        }

        public bool HasHealthIssues
        {
            get 
            { 
                return hasHealthIssues;
            }
            private set 
            { 
                hasHealthIssues = value;
            }
        }

        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            this.caughtFish.Add(fish.Name);
            //Закръгляме до първият знак на десетичната запетая
            competitionPoints = Math.Round(competitionPoints + fish.Points,1);
        }

        public abstract void Miss(int TimeToCatch);


        public abstract void RenewOxy();
        

        public void UpdateHealthStatus()
        {   
            //Обръщаме bool състонието! Ако е било true, става false, и обратно
            HasHealthIssues = !HasHealthIssues;
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {caughtFish.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}
