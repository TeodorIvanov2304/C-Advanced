namespace Composite_Pattern
{
    public class Square : Shape
    {
        public Square(int size, Position position) : base(size, position)
        {

        }


        //Method for drawing a square
        public override void Draw()
        {
            base.Draw();
            Console.SetCursorPosition(Position.X, Position.Y);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write("#");
                }

                Console.SetCursorPosition(Position.X, Position.Y + i);
            }
        }
    }
}
