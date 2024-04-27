namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            //Метода ConsoleWindow.CustomizeConsole() променя цвета на конзолата на бял
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall);
            Engine engine = new Engine(wall,snake) ;
            engine.Run();
            //Point p = new Point(1, 0);
            //p.Draw('@');

            //Wall wall = new Wall(50, 30);
            
        }
    }
}
