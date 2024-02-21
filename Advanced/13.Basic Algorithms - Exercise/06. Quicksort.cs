namespace QuickSort
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            QuickSortImproved(array, 0, array.Count - 1);

            Console.WriteLine(String.Join(" ", array));



        }
        static Random rand = new Random();

        public static void QuickSortImproved(List<int> array, int left, int right)
        {
            if (left < right)
            {


                var partitionIndex = Partition(array, left, right);
                QuickSortImproved(array, left, partitionIndex);
                QuickSortImproved(array, partitionIndex + 1, right);
            }
        }

        static int Partition(List<int> array, int left, int right)
        {
            int pivot = array[(left + right) / 2];
            int i = left - 1;
            int j = right + 1;
            while (true)
            {
                do
                {
                    i++;

                }
                while (array[i] < pivot);
                do
                {
                    j--;

                }
                while (array[j] > pivot);

                if (i >= j)
                {
                    return j;
                }

                var temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public static List<int> Quicksort(List<int> array)
        {
            if (array.Count <= 1)
            {
                return array;
            }

            int pivot = array[rand.Next(0, array.Count)];
            List<int> leftArray = new List<int>();
            List<int> rightArray = new List<int>();
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] < pivot)
                {
                    leftArray.Add(array[i]);
                }
                if (array[i] > pivot)
                {
                    rightArray.Add(array[i]);
                }
            }

            var leftSorted = Quicksort(leftArray);
            var rightSorted = Quicksort(rightArray);
            return leftSorted.Concat(new List<int>() { pivot }).Concat(rightSorted).ToList();
        }

    }
}