namespace _07._Binary_Search
{
    

    public class Program
    {
        static void Main(string[] args)
        {
            //Read input
            int[] arr = Console.ReadLine()
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                               .Select(int.Parse)
                               .ToArray();
            int key = int.Parse(Console.ReadLine());

            //Print
            int result = IndexOf(arr, key);
            Console.WriteLine(result);
        }

        //Returns the index of the searched element
        public static int IndexOf(int[] arr, int key)
        {
            int lo = 0;
            int hi = arr.Length - 1;

            while (lo <= hi)
            {
                //Find the middle element
                int middle = (lo + hi) / 2;

                //If key < middle element
                if (key < arr[middle])
                {
                    hi = middle - 1;
                }
                //If key > middle element
                else if (key > arr[middle])
                {
                    lo = middle + 1;
                }
                //If middle element = key
                else
                {
                    return middle;
                }

            }
            //Return - 1, if key not found
            return -1;
        }

    }
    
}