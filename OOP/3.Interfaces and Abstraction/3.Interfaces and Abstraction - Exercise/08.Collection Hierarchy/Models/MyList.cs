namespace CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection
    {
        public ICollection<string> Used { get; set; }

        public MyList()
        {
            Used = new List<string>();
        }

        public override string Remove()
        {
            string removedItem = collection[0];
            collection.RemoveAt(0);
            Used.Add(removedItem);
            return removedItem;
        }
    }
}
