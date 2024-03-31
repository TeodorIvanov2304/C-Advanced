using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Models;

public class Peak : IPeak
{
    private string name;
    private int elevation;

    public Peak(string name, int elevation, string difficultyLevel)
    {
        Name = name;
        Elevation = elevation;
        DifficultyLevel = difficultyLevel;
    }

    public string Name 
    {
        get => name;
        private set
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(ExceptionMessages.PeakNameNullOrWhiteSpace);
            }
            name = value;
        }
    }
    // <= 0??
    public int Elevation 
    {
        get
        {
            return elevation;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
            }
            elevation = value;
        }
    }
    //Само с get?
    public string DifficultyLevel { get;}

    public override string ToString()
    {
        return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
    }
}