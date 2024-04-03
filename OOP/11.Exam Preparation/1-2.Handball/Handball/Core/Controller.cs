using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Handball.Core
{
    public class Controller : IController
    {
        private IRepository<IPlayer> _players;
        private IRepository<ITeam> _teams;

        public Controller()
        {
            _players = new PlayerRepository();
            _teams = new TeamRepository();
        }

        public string LeagueStandings()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");

            foreach (var team in this._teams.Models.OrderByDescending(t => t.PointsEarned).ThenByDescending(t => t.OverallRating).ThenBy(t => t.Name))
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!_players.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, _players.GetType().Name);
            }
            if (!_teams.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, _teams.GetType().Name);
            }


            //Създаваме играч и отбор по подадените имена, преди да проверим, дали играча има договор
            IPlayer player = _players.GetModel(playerName);
            ITeam team = _teams.GetModel(teamName);

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName); ;
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam team1 = _teams.GetModel(firstTeamName);
            ITeam team2 = _teams.GetModel(secondTeamName);

            if (team1.OverallRating > team2.OverallRating)
            {
                team1.Win();
                team2.Lose();

                return string.Format(OutputMessages.GameHasWinner, team1.Name, team2.Name);
            }
            else if (team1.OverallRating < team2.OverallRating)
            {
                team2.Win();
                team1.Lose();

                return string.Format(OutputMessages.GameHasWinner, team2.Name, team1.Name);
            }

            team1.Draw();
            team2.Draw();
            return string.Format(OutputMessages.GameIsDraw, team1.Name, team2.Name);
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName is not ("Goalkeeper" or "CenterBack" or "ForwardWing"))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (_players.GetModel(name) is not null)
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, _players.GetType().Name, _players.GetModel(name).GetType().Name);
            }

            IPlayer newPlayer = null;

            if (typeName == "Goalkeeper")
            {
                newPlayer = new Goalkeeper(name);
            }
            else if (typeName == "CenterBack")
            {
                newPlayer = new CenterBack(name);
            }
            else if (typeName == "ForwardWing")
            {
                newPlayer = new ForwardWing(name);
            }

            _players.AddModel(newPlayer);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewTeam(string name)
        {

            if (_teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, _teams.GetType().Name);
            }
            ITeam newTeam = new Team(name);
            _teams.AddModel(newTeam);
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, _teams.GetType().Name);
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");
            ITeam team = _teams.GetModel(teamName);
            var orderedPlayers = team.Players.OrderByDescending(r => r.Rating).ThenBy(r => r.Name).ToList();

            foreach (var player in orderedPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
