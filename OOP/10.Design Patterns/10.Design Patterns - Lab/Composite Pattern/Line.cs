namespace Composite_Pattern
{
    public class Line : Shape
    {
        public Line(int size, Position position) : base(size, position)
        {

        }


        //Method for drawing a line
        public override void Draw()
        {
            base.Draw();

            Console.SetCursorPosition(Position.X, Position.Y);

            for (int i = 0; i < Size; i++)
            {
                Console.Write("-");
            }
        }
    }
}
