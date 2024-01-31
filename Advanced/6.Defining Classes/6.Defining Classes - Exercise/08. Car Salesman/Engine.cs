﻿using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;

        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"  {Model}:");
            sb.AppendLine();
            sb.Append($"    Power: {Power}");
            sb.AppendLine();
            sb.Append(Displacement == 0 ? "    Displacement: n/a" : $"    Displacement: {Displacement}");
            sb.AppendLine();
            sb.Append(string.IsNullOrEmpty(Efficiency) ? "    Efficiency: n/a" : $"    Efficiency: {Efficiency}");
            return sb.ToString();
        }
    }
}
