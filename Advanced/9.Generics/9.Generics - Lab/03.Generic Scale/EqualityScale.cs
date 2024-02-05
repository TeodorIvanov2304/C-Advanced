namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T left;
        private T right;
        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual() 
        {   
            //Използваме .Equals, което директно сравнява обекти
            return left.Equals(right);
        }
    }
}
