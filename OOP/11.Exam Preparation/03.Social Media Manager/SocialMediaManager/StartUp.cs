namespace SocialMediaManager
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Influencer influencer = new Influencer("Garo", 10);
            Influencer influencer2 = new Influencer("Maro", 20);
            InfluencerRepository repo = new();
            repo.RegisterInfluencer(influencer);
            repo.RegisterInfluencer(influencer2);
            Console.WriteLine(repo.GetInfluencerWithMostFollowers());
        }
    }
}
