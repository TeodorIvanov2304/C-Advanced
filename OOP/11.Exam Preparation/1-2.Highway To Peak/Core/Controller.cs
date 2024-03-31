using System.Text;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Core
{
    public class Controller : IController
    {
        //Не изписваме така филдовете, трябва да използваме interface 
        //private PeakRepository peaks;
        //private ClimberRepository climbers;
        //private BaseCamp baseCamp;

        private IRepository<IPeak> _peaks;
        private IRepository<IClimber> _climbers;
        private IBaseCamp _baseCamp;

        public Controller()
        {
            _peaks = new PeakRepository();
            _climbers = new ClimberRepository();
            _baseCamp = new BaseCamp();
        }
        public string AddPeak(string name, int elevation, string difficultyLevel)
        {

            if (_peaks.Get(name) is not null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            //НОВ СИНТАКСИС!
            //if (difficultyLevel is not("Extreme" or "Hard" or "Moderate"))

            if (difficultyLevel != "Extreme" && difficultyLevel != "Hard" && difficultyLevel != "Moderate")
            {
                return string.Format(OutputMessages.PeakDifficultyLevelInvalid, difficultyLevel);
            }

            IPeak peak = new Peak(name, elevation, difficultyLevel);
            _peaks.Add(peak);
            return string.Format(OutputMessages.PeakIsAllowed, name, _peaks.GetType().Name);
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber currentClimber;
            IPeak currentPeak;

            if ((currentClimber = _climbers.Get(climberName)) == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if ((currentPeak = _peaks.Get(peakName)) == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }

            if (!_baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }

            //currentClimber.GetType().Name == "Natural Climber"
            if (currentClimber.GetType().Name == "NaturalClimber" && currentPeak.DifficultyLevel == "Extreme")
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }

            _baseCamp.LeaveCamp(climberName);
            currentClimber.Climb(currentPeak);

            if (currentClimber.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfulAttack, climberName);
            }

            //currentClimber.Name?
            _baseCamp.ArriveAtCamp(climberName);

            return string.Format(OutputMessages.SuccessfulAttack, climberName, peakName);
        }

        public string BaseCampReport()
        {
            if (_baseCamp.Residents.Count == 0)
            {
                return "BaseCamp is currently empty.";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");

            foreach (var resident in _baseCamp.Residents)
            {
                var currentResident = _climbers.All.FirstOrDefault(x => x.Name == resident);

                if (currentResident != null)
                {
                    sb.AppendLine($"Name: {currentResident.Name}, Stamina: {currentResident.Stamina}, Count of Conquered Peaks: {currentResident.ConqueredPeaks.Count}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string CampRecovery(string climberName, int daysToRecover)
        {
            if (!_baseCamp.Residents.Contains(climberName))
            {
                return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
            }

            IClimber climber = _climbers.Get(climberName);

            if (climber.Stamina == 10)
            {
                //climber.Name?
                return string.Format(OutputMessages.NoNeedOfRecovery, climberName);
            }

            climber.Rest(daysToRecover);
            return string.Format(OutputMessages.ClimberRecovered, climberName, daysToRecover);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {

            if (_climbers.Get(name) is not null)
            {
                //ClimberCannotBeDuplicated
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name, _climbers.GetType().Name);

            }

            IClimber climber = null;

            if (isOxygenUsed)
            {
                climber = new OxygenClimber(name);
            }
            else
            {
                climber = new NaturalClimber(name);
            }

            _climbers.Add(climber);
            _baseCamp.ArriveAtCamp(climber.Name);

            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);

        }
        public string OverallStatistics()
        {
            StringBuilder sb = new();
            sb.AppendLine("***Highway-To-Peak***");

            List<IClimber> orderedClimbers = _climbers.All.OrderByDescending(c => c.ConqueredPeaks.Count)
                .ThenBy(n => n.Name)
                .ToList();

            foreach (var climber in orderedClimbers)
            {
                sb.AppendLine(climber.ToString());


                //1 Вариант
                //List<IPeak> listOfPeaks = new();
                //foreach (var peakName in climber.ConqueredPeaks)
                //{
                //    var peak = _peaks.Get(peakName);
                //    listOfPeaks.Add(peak);
                //}

                //Вариант 2 - LinQ
                List<IPeak> orderedPeaks = climber.ConqueredPeaks
                    .Select(peakName => _peaks.Get(peakName))
                    .OrderByDescending(p => p.Elevation)
                    .ToList();

                foreach (var peak in orderedPeaks)
                {
                    sb.AppendLine(peak.ToString());
                }
            }

            return sb.ToString().TrimEnd();

        }
    }
}
