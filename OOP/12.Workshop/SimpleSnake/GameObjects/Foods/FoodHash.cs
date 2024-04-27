﻿namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int FoodPoints = 3;
        public FoodHash(Wall wall) : base(wall, FoodSymbol, FoodPoints)
        {

        }
    }
}
