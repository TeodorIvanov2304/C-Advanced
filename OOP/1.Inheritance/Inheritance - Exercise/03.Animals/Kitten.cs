namespace Animals
{
    public class Kitten : Cat
    {   

        //Понеже по условие котенцето има определен винаги женски пол, го добавяме като поле константа.
        //Премахваме го от конструктора, и го подаваме до базовия като KittenGender
        private const string KittenGender = "Female";
        public Kitten(string name, int age) : base(name, age, KittenGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
