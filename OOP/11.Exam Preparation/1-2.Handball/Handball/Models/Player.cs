using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        private string _playerName;
        private double _rating;
        private string _team;

        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;

        }

        public string Name 
        {
            get => _playerName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                _playerName = value;
            }
        }
        //Protected?
        public double Rating { get => _rating; protected set => _rating = value; }

        public string Team 
        { 
            get => _team;

            private set
            {
                _team = value;
            }
        }
        //В този случай, само метода JoinTeam може да сетне value
        //In this case, only the JoinTeam method can set a value

        //!!
        public void JoinTeam(string name)
        {
            this.Team = name;
        }

        public abstract void IncreaseRating();
        public abstract void DecreaseRating();

        //!! ЕДНА ШИБАНА СКОБА, ЦЯЛ ДЕН ТЪРСЯ
        public override string ToString()
        {
            StringBuilder sb = new();
            //Зададено е като playerTypeName
            //sb.AppendLine($"{this.GetType().Name}: {Name})");
            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Rating: {Rating}");
            return sb.ToString().TrimEnd();

        }
    }
}
