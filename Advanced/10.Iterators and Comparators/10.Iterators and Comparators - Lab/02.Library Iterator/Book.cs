namespace IteratorsAndComparators
{
    public class Book
    {   
        //Използваме params, когато не знаем колко точно променливи ще получим
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }
    }
}
