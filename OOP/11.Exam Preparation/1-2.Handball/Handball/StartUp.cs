using Handball.Core;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using System;
using System.Xml.Linq;

namespace Handball
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //ITeam cska = new Team("CSKA Sofia");
            //IPlayer karanga = new ForwardWing("Fernando Karanga");
            //cska.SignContract(karanga);
            //cska.SignContract(new Goalkeeper("Gustavo Busato"));
            //cska.SignContract(new CenterBack("Georgi Turitsov"));
            //IRepository<ITeam> teams = new TeamRepository();
            //IRepository<IPlayer> players = new PlayerRepository();
            //players.AddModel(karanga);
            //teams.AddModel(cska);
            //Console.WriteLine(cska.OverallRating);
            //cska.Win();
            //cska.Win();
            //cska.Draw();
            //Console.WriteLine(cska.PointsEarned);

            //IController controller = new Controller();
            //Console.WriteLine(controller.NewTeam("Muhals"));
            //Console.WriteLine(controller.NewTeam("Muhals"));
            //Console.WriteLine(controller.NewPlayer("CentarNapadatel", "Slabak Govedo"));
            //Console.WriteLine(controller.NewPlayer("Goalkeeper", "Slabak Govedo"));
            ////John Smith is already added to the PlayerRepository as Goalkeeper.
            ////John Smith is already added to the TeamRepository as PlayerRepository. - TОВА ИЗКАРВА!
            //Console.WriteLine(controller.NewPlayer("Goalkeeper", "Slabak Govedo"));
            //Console.WriteLine(controller.NewPlayer("Goalkeeper", "Slabak Govedo"));
            //controller.NewPlayer("ForwardWing", "Fernando Karanga");
            ////controller.NewContract("Grungel Tozi", "CSKA Sofia");
            //Console.WriteLine(controller.NewContract("Slabak Govedo", "Muhals"));
            //Console.WriteLine(controller.NewContract("Slabak Govedo", "Muhals"));
            

            IEngine engine = new Engine();
            engine.Run();            
        }
    }
}
