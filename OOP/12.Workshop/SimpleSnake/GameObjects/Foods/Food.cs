using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    
    public abstract class Food : Point
    {
        private Random _random;
        private Wall _wall;
        private char _foodSymbol;

        protected Food(Wall wall, char foodSymbol, int foodPoints) : base(wall.LeftX,wall.TopY)
        {
            _random = new Random();
            _wall = wall;
            _foodSymbol = foodSymbol;
            FoodPoints = foodPoints;
        }

        public int FoodPoints { get; private set; }

        //Слагаме храна на рандом позиция
        public void SetRandomPosition(Queue<Point> snakeElements)
        {   
            //-2 отстояние, 1 от стената, и 1 от големината на матрицата
            LeftX = _random.Next(2,_wall.LeftX - 2);
            TopY = _random.Next(2, _wall.TopY - 2);

            bool isPointOnTheSnake = snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY);

            //Проверяваме, дали змията е изяла точката с храна
            while (isPointOnTheSnake)
            {
                LeftX = _random.Next(2, _wall.LeftX - 2);
                TopY = _random.Next(2, _wall.TopY - 2);

                isPointOnTheSnake = snakeElements.Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

            Console.BackgroundColor = ConsoleColor.Green;
            Draw(_foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snakeHead)
        {
            return snakeHead.TopY == TopY && snakeHead.LeftX == LeftX;
        }
    }
}
