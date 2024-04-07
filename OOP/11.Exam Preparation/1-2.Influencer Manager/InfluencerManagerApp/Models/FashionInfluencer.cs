using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class FashionInfluencer : Influencer
    {
        private const double EngagementRateFashionInfluencer = 4.0;
        public FashionInfluencer(string username, int followers) : base(username, followers, EngagementRateFashionInfluencer)
        {
        }

        public override int CalculateCampaignPrice()
        {
            double factor = 0.1;
            return (int)Math.Round(Followers * EngagementRate * factor); ; ;
        }
    }
}
