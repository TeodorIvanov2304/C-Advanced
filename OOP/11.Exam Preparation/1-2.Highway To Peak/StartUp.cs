namespace HighwayToPeak
{
    using HighwayToPeak.Core;
    using HighwayToPeak.Core.Contracts;
    using HighwayToPeak.Models;
    using HighwayToPeak.Models.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}