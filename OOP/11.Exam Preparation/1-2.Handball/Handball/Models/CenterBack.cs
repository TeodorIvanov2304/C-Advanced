namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double InitialRatingValue = 4;
        private const double IncreaseRatingCenterBackValue = 1;
        private const double DecreaseRatingCenterBackValue = 1;
        public CenterBack(string name) : base(name, InitialRatingValue)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= DecreaseRatingCenterBackValue;
            if (Rating < 1)
            {
                Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            Rating += IncreaseRatingCenterBackValue;
            if (Rating > 10)
            {
                Rating = 10;
            }
        }
    }
}
