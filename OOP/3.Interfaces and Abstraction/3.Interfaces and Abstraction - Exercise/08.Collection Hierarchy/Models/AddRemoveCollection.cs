using CollectionHierarchy.Interfaces;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IRemovable
    {
        public override int Add(string input)
        {
            collection.Insert(0, input);
            return 0;
        }

        public virtual string Remove()
        {
            int indexOfItemToRemove = collection.Count - 1;
            string removedItem = collection[indexOfItemToRemove];
            collection.RemoveAt(indexOfItemToRemove);
            return removedItem;
        }
    }
}
