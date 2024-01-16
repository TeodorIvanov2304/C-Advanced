namespace _00._Bubble_sort__without_LINQ
{
    internal class Program
    {
        static void Main()
        {
            List<double> numbers = new List<double> { 3.14, 1.23, 2.71, 0.99, 4.56 };

            // Sorting the list using bubble sort
            BubbleSort(numbers);

            Console.WriteLine("Original List:");
            Console.WriteLine(string.Join(", ", numbers));
        }

        static void BubbleSort(List<double> list)
        {
            int n = list.Count;
            bool swapped;

            do
            {
                swapped = false;

                for (int i = 1; i < n; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        // Swap the elements
                        double temp = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = temp;

                        swapped = true;
                    }
                }

                // After each pass, the largest element is guaranteed to be at the end
                // Reduce the range of elements to consider in the next pass
                n--;
            } while (swapped);
        }
    }
}