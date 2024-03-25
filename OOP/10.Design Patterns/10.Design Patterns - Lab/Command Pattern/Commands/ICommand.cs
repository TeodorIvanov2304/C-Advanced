namespace Command_Pattern.Commands
{
    public interface ICommand
    {   
        //Текуща стойност на калуклатора
        public decimal Execute(decimal current);
        public decimal UnExecute(decimal current);
        public decimal Value { get; set; }
        public char Operator { get; set; }
    }
}
