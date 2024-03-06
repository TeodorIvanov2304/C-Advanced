namespace Operations
{   

    //Example for static polymorphism
    public class MathOperations
    {   
        //Method for adding two intergers
        public int Add(int a, int b)
        {
            return a + b;
        }

        //Method for adding three double variables
        public double Add(double a, double b,double c)
        {
            return a + b + c;
        }

        //Method for adding three decimal variables
        public decimal Add(decimal a, decimal b, decimal c)
        {
            return a + b + c;
        }
    }
}
