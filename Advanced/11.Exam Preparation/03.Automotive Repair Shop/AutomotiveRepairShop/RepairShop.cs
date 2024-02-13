using System.Text;
using System.Xml.Linq;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            this.Vehicles = new List<Vehicle>();
        }

        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (this.Vehicles.Count < this.Capacity)
            {
                this.Vehicles.Add(vehicle);
            }
        }

        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicle = Vehicles.FirstOrDefault(v=>v.VIN == vin);
            if (vehicle != null) 
            {
                this.Vehicles.Remove(vehicle);
                return true;
            }
            return false;
        }
            
            
            //=> Vehicles.Remove(Vehicles.FirstOrDefault(x => x.VIN == vin));

        public int GetCount()
        {
            return Vehicles.Count;
        }

        //Трябваше метода да е от тип Vehicle, и да връща Vehicle, a не стринг!
        public Vehicle GetLowestMileage() => this.Vehicles.OrderBy(v => v.Mileage).FirstOrDefault();
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Vehicles in the preparatory:");
            foreach (var vehicle in this.Vehicles)
            {
                sb.AppendLine(vehicle.ToString().TrimEnd().TrimStart());
            }

            return sb.ToString().TrimEnd().TrimStart();
        }
    }
    
}
