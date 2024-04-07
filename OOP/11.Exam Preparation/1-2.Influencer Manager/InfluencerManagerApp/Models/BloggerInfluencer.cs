using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class BloggerInfluencer : Influencer
    {
        private const double EngagementRateBloggerInfluencer = 2.0;
        public BloggerInfluencer(string username, int followers) : base(username, followers, EngagementRateBloggerInfluencer)
        {

        }

        public override int CalculateCampaignPrice()
        {
            double factor = 0.2;
            return (int)Math.Floor(Followers * EngagementRate * factor);
        }
    }
}
