namespace Composite_Pattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            Shape figure = new Shape(0, new Position(0, 0));
            Shape page = new Shape(0, new Position(0, 0));
            Rectangle rectangle = new Rectangle(5, new Position(10, 10));
            Rectangle rectangle2 = new Rectangle(8, new Position(22, 7));
            Rectangle rectangle3 = new Rectangle(5, new Position(40, 10));
            //Вместо да чертаем всичко по отделно
            //rectangle.Draw();
            //rectangle2.Draw();
            //rectangle3.Draw();

            figure.AddChild(rectangle);
            figure.AddChild(rectangle2);
            figure.AddChild(rectangle3);


            Line line = new Line(8, new Position(2, 2));
            Line line2 = new Line(8, new Position(17, 2));
            Line line3 = new Line(8, new Position(10, 4));
            Shape figure2 = new Shape(0, new Position(0, 0));

            figure2.AddChild(line);
            figure2.AddChild(line2);
            figure2.AddChild(line3);

            page.AddChild(figure);
            page.AddChild(figure2);


            while (true)
            {
                //Изчистваме конзолата
                Console.Clear();

                //Вместо целият този код, съкращаваме с общ абстрактен метод
                //rectangle.Move(Direction.Right);
                //rectangle2.Move(Direction.Right);
                //rectangle3.Move(Direction.Right);
                //rectangle.Draw();
                //rectangle2.Draw();
                //rectangle3.Draw();


                figure.Move(Direction.Right);
                page.Draw();
                figure2.Move(Direction.Down);

                //Казваме на конзолата да заспи за 0.5 секунди
                Thread.Sleep(500);
            }
        }
    }
}