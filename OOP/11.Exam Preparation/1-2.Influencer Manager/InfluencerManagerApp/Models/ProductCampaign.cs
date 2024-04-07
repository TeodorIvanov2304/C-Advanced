﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public class ProductCampaign : Campaign
    {   
        private const double BudgetProductCampaign = 60000;
        public ProductCampaign(string brand) : base(brand, BudgetProductCampaign)
        {
        }
    }
}
