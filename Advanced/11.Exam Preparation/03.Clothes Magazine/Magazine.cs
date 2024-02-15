using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Clothes = new List<Cloth>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (this.Clothes.Count < Capacity)
            {
                this.Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            return this.Clothes.Remove(this.Clothes.FirstOrDefault(c => c.Color == color));
        }

        public Cloth GetSmallestCloth()
        {
            return this.Clothes.OrderBy(s=>s.Size).First();
        }

        public Cloth GetCloth(string color)
        {   
            Cloth clothToCheck = this.Clothes.FirstOrDefault(c => c.Color == color);
            return clothToCheck;
        }

        public int GetClothCount()
        {
            return this.Clothes.Count;
        }

        public string Report()
        {
            var orderedClothes  = this.Clothes.OrderBy(s => s.Size);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Type} magazine contains:");
            foreach (var cloth in orderedClothes)
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().TrimEnd().TrimStart();
        }
    }
}
