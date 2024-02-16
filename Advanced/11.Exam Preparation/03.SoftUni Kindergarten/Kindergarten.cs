using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        private string _name;

        private int _capacity;

        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Child> Registry { get; set; }

        public bool AddChild(Child child)
        {
            if (Registry.Count < Capacity) 
            {
                Registry.Add(child);
                return true;
            }
            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] names = childFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string firstName = names[0];
            string lastName = names[1];

            Child child = Registry.FirstOrDefault(f=>f.FirstName == firstName && f.LastName == lastName);
            if (child != null)
            {
                Registry.Remove(child);
                return true;
            }
            return false;
        }

        public int ChildrenCount => Registry.Count;

        public Child GetChild(string childFullName)
        {
            string[] names = childFullName.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string firstName = names[0];
            string lastName = names[1];

            Child child = Registry.FirstOrDefault(f => f.FirstName == firstName && f.LastName == lastName);
            if (child != null)
            {
                
                return child;
            }
            return null;
        }

        public string RegistryReport()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Registered children in {Name}:");
            var sorted = Registry.OrderByDescending(a => a.Age).ThenBy(l=>l.LastName).ThenBy(l=>l.FirstName);
            foreach (var child in sorted)
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
