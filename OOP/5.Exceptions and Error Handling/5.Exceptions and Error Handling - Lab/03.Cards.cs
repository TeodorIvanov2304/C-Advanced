namespace _03.Cards
{
    public class Card
    {
        private const string invalidCardException = "Invalid card!";
        private string face;
        private string suit;

        private readonly HashSet<string> Faces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private readonly HashSet<string> Suits = new HashSet<string> { "S", "H", "D", "C" };

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            set
            {
                if (!Faces.Contains(value))
                {
                    throw new ArgumentException(invalidCardException);
                }
                face = value;
            }
        }

        public string Suit
        {
            get => suit;
            set
            {
                if (!Suits.Contains(value))
                {
                    throw new ArgumentException(invalidCardException);
                }
                else
                {
                    DetermineColor(value);
                }

            }
        }

        private void DetermineColor(string value)
        {
            switch (value)
            {
                case "S":
                    suit = "\u2660";
                    break;
                case "H":
                    suit = "\u2665";
                    break;
                case "D":
                    suit = "\u2666";
                    break;
                case "C":
                    suit = "\u2663";
                    break;
            }
        }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            foreach (string card in input)
            {
                string[] cardInfo = card.Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();

                try
                {
                    Card newCard = new Card(cardInfo[0], cardInfo[1]);
                    cards.Add(newCard);
                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine(string.Join(" ",cards));
        }
    }
}