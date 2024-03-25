using System.ComponentModel;

namespace Composite_Pattern
{
    public  class Shape
    {
        protected List<Shape> children;

        public Shape(int size, Position position)
        {
            children = new List<Shape>();
            Size = size;
            Position = position;
        }

        protected Shape(int size)
        {
            Size = size;
        }

        public Position Position { get; set; }

        public int Size { get; set; }
        public void AddChild(Shape child)
        {
            children.Add(child);
        }

        //Virtual method for drawing
        public virtual void Draw()
        {
            foreach (Shape child in children)
            {
                child.Draw();
            }
        }

        public virtual void Move(Direction direction )
        {
            switch (direction)
            {
                case Direction.Top:
                    Position.Y--;
                    break;
                case Direction.Down:
                    Position.Y++;
                    break;
                case Direction.Left:
                    Position.X--;
                    break;
                case Direction.Right:
                    Position.X++;
                    break;
                default: break;
            }

            foreach (Shape child in children)
            {
                child.Move(direction);
            }
        }


    }


}
