using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BusinessInfluencer : Influencer
    {
        private const double EngagementRateBusinessInfluencer = 3.0;
        public BusinessInfluencer(string username, int followers) : base(username, followers, EngagementRateBusinessInfluencer)
        {
        }

        public override int CalculateCampaignPrice()
        {   

            double factor = 0.15;
            return (int)Math.Floor(Followers * EngagementRate * factor);
        }
    }
}
