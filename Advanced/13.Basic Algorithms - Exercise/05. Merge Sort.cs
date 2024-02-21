namespace _05._Merge_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            //Read the input
            List<int> list = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            //Print final result
            Console.WriteLine(string.Join(" ",MergedSort(list,0,list.Count)));
        }

        public static List<int> MergedSort(List<int> list, int start, int end)
        {
            if (end - start == 1)
            {
                return new List<int>() { list[start] };
            }
            if (end - start <= 0)
            {
                return new List<int>();
            }

            int middle = (start + end) / 2;

            //Divide the list in two parts using recursion
            List<int> sortedLeftPart = MergedSort(list, start, middle);
            List<int> sortedRightPart = MergedSort(list, middle, end);

            //Visualiser
            //if (sortedLeftPart != null)
            //{
            //    Console.WriteLine(string.Join(",", sortedLeftPart));
            //}
            //if (sortedRightPart != null)
            //{
            //    Console.WriteLine(string.Join(",", sortedRightPart));
            //}

            return MergeTwoSortedLists(sortedLeftPart,sortedRightPart);

        }
        public static List<int> MergeTwoSortedLists(List<int> left, List<int> right)
        {
            List<int> mergetList = new List<int>();
            int leftIndex = 0;
            int rightIndex = 0;

            for (int i = 0; i < left.Count + right.Count; i++)
            {
                if (leftIndex >= left.Count)
                {
                    mergetList.Add((right[rightIndex++]));
                    continue;
                }
                else if (rightIndex >= right.Count)
                {
                    mergetList.Add(left[leftIndex++]);
                    continue;
                }
                if (left[leftIndex] < right[rightIndex])
                {
                    mergetList.Add(left[leftIndex++]);
                }
                else
                {
                    mergetList.Add((right[rightIndex++]));
                }
            }

            return mergetList;
        }
    }
}