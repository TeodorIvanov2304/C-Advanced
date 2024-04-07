using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfluencerManagerApp.Models
{
    public abstract class Campaign : ICampaign
    {
        private string _brand;
        private double _budget;
        private List<string> _contributors;

        protected Campaign(string brand, double budget)
        {
            Brand = brand;
            Budget = budget;
            _contributors = new List<string>();
        }

        public string Brand
        {
            get => _brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandIsrequired);
                }
                _brand = value;
            }
        }


        public double Budget
        {
            get => _budget;
            private set
            {
                _budget = value;
            }
        }

        public IReadOnlyCollection<string> Contributors => _contributors.AsReadOnly();

        public void Engage(IInfluencer influencer)
        {
            _contributors.Add(influencer.Username);
            double amount = influencer.CalculateCampaignPrice();
            Budget -= amount;
        }

        public void Gain(double amount)
        {
            Budget += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} - Brand: {Brand}, Budget: {Budget}, Contributors: {_contributors.Count}";
        }
    }
}
