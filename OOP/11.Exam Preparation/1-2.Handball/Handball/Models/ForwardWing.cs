namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double InitialRatingValue = 5.5;
        private const double IncreaseRatingForwardWingValue = 1.25;
        private const double DecreaseRatingForwardWingValue = 0.75;
        public ForwardWing(string name) : base(name, InitialRatingValue)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= DecreaseRatingForwardWingValue;
            if (Rating < 1)
            {
                Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            Rating += IncreaseRatingForwardWingValue;
            if (Rating > 10)
            {
                Rating = 10;
            }
        }
    }
}
