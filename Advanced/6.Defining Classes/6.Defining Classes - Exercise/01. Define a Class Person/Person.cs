namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private uint age;

        public string Name
        {   
            //get=>name е алтернативно изписване
            //set=>name = value
            get { return this.name; }
            set { this.name = value; }
        }

        public uint Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
    }
}
