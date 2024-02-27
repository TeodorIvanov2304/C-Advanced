namespace ClassBoxData
{
    public class Box
    {
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
            get
            {
                return length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }


        public double SurfaceArea(double length, double width, double height)
        {
            //Surface area formula: 2lw + 2lh + 2wh
            double surfaceArea = (2 * length * width) + (2 * length * height) + (2 * width * height);
            return surfaceArea;
        }

        public double  LateralSurfaceArea(double length, double width, double height)
        {
            //Lateral surface area forumula = 2lh + 2wh
            double lateralSurfaceArea = (2 * length * height) + (2 * width * height);
            return lateralSurfaceArea;
        }
        public double Volume(double length, double width, double height)
        {
            //Volume formula = lwh
            double volume = length * width * height;
            return volume;
        }
    }
}
