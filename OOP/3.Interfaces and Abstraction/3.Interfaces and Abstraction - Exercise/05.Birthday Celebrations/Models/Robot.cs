using BorderControl.Models.Interfaces;

namespace BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string id, string model)
        {
            Id = id;
            Model = model;
        }

        public string Id { get; init; }
        public string Model { get; init; }

        
    }
}
