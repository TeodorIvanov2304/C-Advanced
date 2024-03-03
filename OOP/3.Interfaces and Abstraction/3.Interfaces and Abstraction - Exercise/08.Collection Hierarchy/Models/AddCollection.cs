using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddElements
    {
        protected List<string> collection;
        public AddCollection()
        {
            collection = new List<string>();
        }

        public virtual int Add(string input)
        {
            collection.Add(input);
            return collection.Count-1;
        }
    }
}
