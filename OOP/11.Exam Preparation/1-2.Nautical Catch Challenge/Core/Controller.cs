using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;
using System.Text;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fish;

        //Синтаксисите typeof(ScubaDiver).Name взима типа плувец, еквивалента му е ръчно да изпишем ScubaDvier и FreeDiver като елементи от масива, в който ще проверяваме дали дадения плувец е съществува в DiverRepository, например FilipinoDiver
        // private string[] diverTypes = new string[] {"ScubaDiver", FreeDiver"}

        private string[] diverTypes = new string[] {typeof(ScubaDiver).Name,typeof(FreeDiver).Name};
        private string[] fishTypes = new string[] { typeof(DeepSeaFish).Name,typeof(PredatoryFish).Name,typeof(ReefFish).Name};
        public Controller()
        {
            divers = new DiverRepository();
            fish = new FishRepository();
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) is null)
            {
                return String.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);
            }
            if (fish.GetModel(fishName) is null)
            {
                return String.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = divers.GetModel(diverName);
            IFish currentFish = fish.GetModel(fishName);

            if (diver.HasHealthIssues)
            {
                return String.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < currentFish.TimeToCatch)
            {
                diver.Miss(currentFish.TimeToCatch);
                return String.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == currentFish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(currentFish);
                    return String.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
                }
                else
                {
                    diver.Miss(currentFish.TimeToCatch);
                    return String.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }
            else
            {
                diver.Hit(currentFish);
                return String.Format(OutputMessages.DiverHitsFish, diverName, currentFish.Points, fishName);
            }
        }

        public string CompetitionStatistics()
        {
            List<IDiver> diversToReport = divers.Models.Where(h=>h.HasHealthIssues == false)
                .OrderByDescending(p=>p.CompetitionPoints)
                .ThenByDescending(p=>p.Catch.Count)
                .ThenBy(d=>d.Name)
                .ToList();

            StringBuilder sb = new();
            sb.AppendLine("**Nautical-Catch-Challenge**");

            foreach (var diver in diversToReport)
            {
                sb.AppendLine(diver.ToString());
            }

            return sb.ToString().Trim();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!diverTypes.Contains(diverType))
            {
                //Използваме string.Format за да заместим 0 в "{0} is not allowed in our competition."
                //diverType ще замести 0
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }
            if (divers.GetModel(diverName) != null)
            {
                //С typeof връщаме името на самото хранилище DiverRepository
                return String.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);
            }

            //Създаваме празен обект от тип IDiver
            IDiver diver = null;

            //If divertype == "ScubaDiver"
            if (diverType == typeof(ScubaDiver).Name)
            {
                diver = new ScubaDiver(diverName);
            }

            if (diverType == typeof(FreeDiver).Name)
            {
                diver = new FreeDiver(diverName);
            }

            divers.AddModel(diver);

            //Връщаме съобщението за успешна регистрация с името на гмуркача и името на хранилището
            return string.Format(OutputMessages.DiverRegistered,diverName, typeof(DiverRepository).Name);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);
            StringBuilder sb = new();
            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");

            foreach (var caughtFish in diver.Catch)
            {
                sb.AppendLine(fish.GetModel(caughtFish).ToString());
            }

            return sb.ToString().Trim();
        }

        public string HealthRecovery()
        {
            List<IDiver> healthIssueDivers = divers.Models.Where(h=>h.HasHealthIssues == true).ToList();

            foreach (var diver in healthIssueDivers)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }

            return string.Format(OutputMessages.DiversRecovered, healthIssueDivers.Count);
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!fishTypes.Contains(fishType))
            {
                return String.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fish.GetModel(fishName) != null)
            {
                return String.Format(OutputMessages.FishNameDuplication, fishName,typeof(FishRepository).Name);
            }

            IFish newFish = null;

            //If fishType == "ReefFish"
            if (fishType == typeof(ReefFish).Name)
            {
                newFish = new ReefFish(fishName,points);
            }
            if (fishType == typeof(DeepSeaFish).Name)
            {
                newFish = new DeepSeaFish(fishName, points);
            }
            if (fishType == typeof(PredatoryFish).Name)
            {
                newFish = new PredatoryFish(fishName, points);
            }

            fish.AddModel(newFish);

            return String.Format(OutputMessages.FishCreated, fishName);
        }
    }
}
