using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public int Capacity { get; set; }
        public List<Shark> Species  { get; set; }
        public int GetCount => Species.Count;

        public void AddShark(Shark shark)
        {
            if (Species.Count < Capacity)
            {
                Shark newShark = Species.FirstOrDefault(s=>s.Kind == shark.Kind);
                if (newShark == null)
                {
                    Species.Add(shark);
                }
            }
        }

        public bool RemoveShark(string kind)
        {
            Shark sharkToCheck = Species.FirstOrDefault(k=>k.Kind == kind);
            if (sharkToCheck != null)
            {
                Species.Remove(sharkToCheck);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //Може би трябва да е string?
        public string GetLargestShark()
        {
            var biggestShark = Species.OrderByDescending(s=>s.Length).First();
            return biggestShark.ToString();
        }

        public double GetAverageLength()
        {
            double average = Species.Average(s=>s.Length);
            return average;
        }

        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{GetCount} sharks classified:");
            foreach (var shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
