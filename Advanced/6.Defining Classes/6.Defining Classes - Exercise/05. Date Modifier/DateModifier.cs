namespace DefiningClasses
{
    public class DateModifier
    {
        private int difference;

        private DateTime firstDate;
        private DateTime secondDate;

        //Конструктора получава два стринга и ги връща парснати
        public DateModifier(string firstDate, string secondDate)
        {
            //Получаваме string firstDate и после го парсваме към DateTime
            this.firstDate = DateTime.Parse(firstDate);
            this.secondDate = DateTime.Parse(secondDate);

        }

        public int Difference
        {
            get
            {   
                //В гетъра направо кастваме firstDate - secondDate към int, и след това му даваме .TotalDays
                return difference = Math.Abs((int)(firstDate - secondDate).TotalDays);
            }
            set { this.difference = value; }
        }


    }
}
