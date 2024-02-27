namespace ClassBoxData
{
    public class Box
    {   
        //Create const string message 
        private const string PropertyValueExeptionMessage = "{0} cannot be zero or negative.";

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            //get=>length
            get
            {   
                
                return length;
            }
            private set
            //init can replace private set, it means that the field can be initialized just once!In the constructor
            {
                if (value <= 0)
                {   
                    //We use string.Format to print the const string, and nameof for the property name
                    throw new ArgumentException(string.Format(PropertyValueExeptionMessage),nameof(Length));
                }
                length = value;
            }
        }

        public double Width
        {
            //get=>width
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExeptionMessage), nameof(Width));
                }
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(PropertyValueExeptionMessage), nameof(Height));
                }
                height = value;
            }
        }

        //public double SurfaceArea() => 2 * Length * Width + LateralSurfaceArea();
        public double SurfaceArea(double length, double width, double height)
        {
            //Surface area formula: 2lw + 2lh + 2wh
            double surfaceArea = (2 * length * width) + (2 * length * height) + (2 * width * height);
            return surfaceArea;
        }

        public double LateralSurfaceArea(double length, double width, double height)
        {
            //Lateral surface area forumula = 2lh + 2wh
            double lateralSurfaceArea = (2 * length * height) + (2 * width * height);
            return lateralSurfaceArea;
        }

        //New modern syntax
        //public double Volume() => Length * Width * Height
        public double Volume(double length, double width, double height)
        {
            //Volume formula = lwh
            double volume = length * width * height;
            return volume;
        }
    }
}
