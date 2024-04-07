using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluencerManagerApp.Core.Contracts;
using InfluencerManagerApp.Models;
using InfluencerManagerApp.Models.Contracts;
using InfluencerManagerApp.Repositories;
using InfluencerManagerApp.Repositories.Contracts;
using InfluencerManagerApp.Utilities.Messages;

namespace InfluencerManagerApp.Core
{
    public class Controller : IController
    {
        private IRepository<IInfluencer> influencers;
        private IRepository<ICampaign> campaigns;

        public Controller()
        {
            influencers = new InfluencerRepository();
            campaigns = new CampaignRepository();
        }
        public string RegisterInfluencer(string typeName, string username, int followers)
        {
            if (typeName is not ("BusinessInfluencer" or "FashionInfluencer" or "BloggerInfluencer"))
            {
                return string.Format(OutputMessages.InfluencerInvalidType, typeName);
            }

            if (influencers.FindByName(username) != null)
            {
                //TravelVirtu is already registered in InfluencerRepository
                return string.Format(OutputMessages.UsernameIsRegistered, username, influencers.GetType().Name);
            }

            IInfluencer influencer = null;
            if (typeName == "BusinessInfluencer")
            {
                influencer = new BusinessInfluencer(username, followers);
            }
            else if (typeName == "FashionInfluencer")
            {
                influencer = new FashionInfluencer(username, followers);
            }
            else if (typeName == "BloggerInfluencer")
            {
                influencer = new BloggerInfluencer(username, followers);
            }

            influencers.AddModel(influencer);

            return string.Format(OutputMessages.InfluencerRegisteredSuccessfully, username);
        }

        public string BeginCampaign(string typeName, string brand)
        {
            if (typeName is not ("ProductCampaign" or "ServiceCampaign"))
            {
                return string.Format(OutputMessages.CampaignTypeIsNotValid, typeName);
            }
            if (campaigns.FindByName(brand) != null)
            {
                return string.Format(OutputMessages.CampaignDuplicated, brand);
            }

            ICampaign campaign = null;
            if (typeName == "ProductCampaign")
            {
                campaign = new ProductCampaign(brand);
            }
            else if (typeName == "ServiceCampaign")
            {
                campaign = new ServiceCampaign(brand);
            }

            campaigns.AddModel(campaign);

            return string.Format(OutputMessages.CampaignStartedSuccessfully, brand, typeName);
        }

        public string AttractInfluencer(string brand, string username)
        {
            IInfluencer influencer = influencers.Models.FirstOrDefault(x => x.Username == username);
            if (influencer == null)
            {
                //InfluencerRepository has no NotEX_infl registered in the application.
                return string.Format(OutputMessages.InfluencerNotFound, influencers.GetType().Name, username);
            }

            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign == null)
            {
                return string.Format(OutputMessages.CampaignNotFound, brand);
            }

            if (influencer.Participations.Contains(brand))
            {
                //MarketPPMaven is already engaged for the Uber campaign
                return string.Format(OutputMessages.InfluencerAlreadyEngaged, username, brand);
            }

            if (campaign.GetType().Name == "ProductCampaign" && influencer.GetType().Name == "BloggerInfluencer")
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }
            if (campaign.GetType().Name == "ServiceCampaign" && influencer.GetType().Name == "FashionInfluencer")
            {
                return string.Format(OutputMessages.InfluencerNotEligibleForCampaign, username, brand);
            }

            if (campaign.Budget < influencer.CalculateCampaignPrice())
            {
                return string.Format(OutputMessages.UnsufficientBudget, brand, username);
            }

            influencer.EnrollCampaign(brand);
            influencer.EarnFee(influencer.CalculateCampaignPrice());
            campaign.Engage(influencer);


            return string.Format(OutputMessages.InfluencerAttractedSuccessfully, username, brand);
        }

        public string FundCampaign(string brand, double amount)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToFund);
            }

            if (amount <= 0)
            {
                return string.Format(OutputMessages.NotPositiveFundingAmount);
            }

            ICampaign campaign = campaigns.FindByName(brand);
            campaign.Gain(amount);

            return string.Format(OutputMessages.CampaignFundedSuccessfully, brand, amount);
        }

        public string CloseCampaign(string brand)
        {
            if (campaigns.FindByName(brand) == null)
            {
                return string.Format(OutputMessages.InvalidCampaignToClose);
            }
            ICampaign campaign = campaigns.FindByName(brand);
            if (campaign.Budget <= 10000)
            {
                return string.Format(OutputMessages.CampaignCannotBeClosed, brand);
            }

            foreach (var influencer in influencers.Models)
            {
                if (influencer.Participations.Contains(brand))
                {
                    influencer.EarnFee(2000);
                    influencer.EndParticipation(brand);
                }

            }


            campaigns.RemoveModel(campaign);
            return string.Format(OutputMessages.CampaignClosedSuccessfully, brand);
        }

        public string ConcludeAppContract(string username)
        {
            IInfluencer influencer = influencers.FindByName(username);
            if (influencer == null)
            {
                return string.Format(OutputMessages.InfluencerNotSigned, username);
            }
            if (influencer.Participations.Count != 0)
            {
                return string.Format(OutputMessages.InfluencerHasActiveParticipations, username);
            }

            influencers.RemoveModel(influencer);
            return string.Format(OutputMessages.ContractConcludedSuccessfully, username);
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var influencer in influencers.Models.OrderByDescending(i => i.Followers).ThenByDescending(i => i.Income))
            {
                sb.AppendLine(influencer.ToString());
                if (influencer.Participations.Count > 0)
                {
                    sb.AppendLine("Active Campaigns:");
                    foreach (var campBrand in influencer.Participations.OrderBy(p => p))
                    {
                        ICampaign campaign = campaigns.FindByName(campBrand);
                        sb.Append("--");
                        sb.Append(campaign.ToString());
                        sb.AppendLine();
                    }

                }
            }
            return sb.ToString().TrimEnd();
        }
    }
    }
