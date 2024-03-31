using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private SortedSet<string> residentsInCamp;

        public BaseCamp()
        {
            residentsInCamp = new SortedSet<string>();
        }


        //Правим го, да не е AsReadOnly();
        public IReadOnlyCollection<string> Residents => residentsInCamp;
        
            //get
            //{
            //    //Връщаме го като ReadOnly();
            //    residentsInCamp.Sort();
            //    return  residentsInCamp.AsReadOnly();
            //}
        

        public void ArriveAtCamp(string climberName)
        {
            residentsInCamp.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            residentsInCamp.Remove(climberName);
        }
    }
}
