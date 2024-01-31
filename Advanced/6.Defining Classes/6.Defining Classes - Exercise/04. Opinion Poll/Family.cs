using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> family = new List<Person>();
        public Family()
        {
            this.family = new();
        }

        public List<Person> FamilyMembers
        {
            get { return family; }
            set { family = value; }
        }


        public void AddMember(Person person)
        {
            family.Add(person);
        }

        public Person GetOldestMember()
        {
            Person oldest = family.MaxBy(x => x.Age);
            return oldest;
        }
    }
}