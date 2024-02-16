using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }
        public int StorageCapacity  { get; set; }
        public List<Shoe> Shoes { get; private set; }

        public int Count => Shoes.Count;

        public string AddShoe(Shoe shoe)
        {
            if (Shoes.Count < StorageCapacity)
            {
                Shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }

            return "No more space in the storage room.";
        }

        public int RemoveShoes(string material)
        {
            int count = 0;
            var sorted = Shoes.FindAll(m => m.Material == material);

            for (int i = 0; i < sorted.Count; i++)
            {
                Shoes.Remove(sorted[i]);
                count++;
            }
            

            return count;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> list = new List<Shoe>();
            foreach (var shoe in Shoes.Where(m => m.Type == type))
            {
                list.Add(shoe);
            }

            return list;
        }

        public Shoe GetShoeBySize(double size)
        {
            Shoe shoe = Shoes.FirstOrDefault(s=>s.Size == size);
            return shoe;
        }

        public string StockList(double size, string type)
        {
            var shoes = Shoes.FindAll(s => s.Size == size && s.Type == type);
            if (shoes.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");
                foreach (var shoe in shoes) 
                {
                    sb.AppendLine(shoe.ToString());
                }

                return sb.ToString().TrimEnd();
            }
            return "No matches found!";
        }
    }
}
