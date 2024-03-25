namespace Command_Pattern.Commands
{
    public class DivideCommand
    {
        public DivideCommand(decimal value)
        {
            Value = value;
            Operator = '/';
        }

        public decimal Value { get; set; }
        public char Operator { get; set; }

        public decimal Execute(decimal current)
        {
            return current / Value;
        }

        public decimal UnExecute(decimal current)
        {
            return current * Value;
        }
    }
}
