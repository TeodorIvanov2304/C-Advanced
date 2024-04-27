using System;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        //Wall Symbol  - ■ 
        private const char wallSymbol = '\u25A0';
        
        //Initialize the borders directly in the constructor
        public Wall(int leftX, int topY) : base(leftX, topY)
        {   
           InitializeWallBorders(leftX,topY);
        }


        public bool isPointOnWall(Point point)
        {
            return point.LeftX == 0 ||
                point.TopY == 0 ||
                point.LeftX == LeftX ||
                point.TopY == TopY;

        }
        //Draw Horizontal Wall
        private void SetHorizontalLine(int topY)
        {
            for (int leftX = 0; leftX < LeftX; leftX++)
            {
                Draw(leftX, topY,wallSymbol);
            }
        }

        //Draw Vertical Wall
        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < TopY; topY++)
            {
                Draw(leftX, topY, wallSymbol);
            }
        }

        //Draw borders
        private void InitializeWallBorders(int leftX, int topY)
        {
            SetHorizontalLine(0);
            SetHorizontalLine(topY);

            SetVerticalLine(0);
            SetVerticalLine(leftX);
        }
    }
}
