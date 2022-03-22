namespace GeometricFigures
{
    public abstract class MyGeometricFigure
    {
        public string? Name { get; set; }
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public string GetName()
        {
            return Name;
        }
    }

    class Rectangle : MyGeometricFigure
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return 2.0 * (Height + Width);
        }
    }

    class Triangle : MyGeometricFigure
    {
        public double AB { get; set; }
        public double BC { get; set; }
        public double CA { get; set; }

        public override double GetArea()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt(p * (p - AB) * (p - BC) * (p - CA));
        }

        public override double GetPerimeter()
        {
            return AB + BC + CA;
        }

        public double GetInscribedCircleRadius()
        {
            return 1.0 / GetPerimeter() * GetArea();
        }

        public double GetCircumscribedCircleRadius()
        {
            return (AB * BC * CA) / (4.0 * GetArea());
        }
    }

    class Quadrangle : MyGeometricFigure
    {
        public double AB { get; set; }
        public double BC { get; set; }
        public double CD { get; set; }
        public double DA { get; set; }

        public override double GetArea()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt(p * (p - AB) * (p - BC) * (p - CD) * (p - DA));
        }

        public override double GetPerimeter()
        {
            return AB + BC + CD + DA;
        }
    }

    class Square : MyGeometricFigure
    {
        public double SideLength { get; set; }

        public override double GetArea()
        {
            return SideLength * SideLength;
        }

        public override double GetPerimeter()
        {
            return 4.0 * SideLength;
        }
    }

    class Pentagon : MyGeometricFigure
    {
        public double SideLength { get; set; }

        public override double GetArea()
        {
            return Math.Sqrt(5.0) * Math.Sqrt(5.0 + 2.0 * Math.Sqrt(5)) / 4.0 * Math.Pow(SideLength, 2.0);
        }

        public override double GetPerimeter()
        {
            return 5.0 * SideLength;
        }

        public double GetInscribedCircleRadius()
        {
            return Math.Sqrt(5.0) * Math.Sqrt(5.0 + 2.0 * Math.Sqrt(5)) / 10.0 * SideLength;
        }

        public double GetCircumscribedCircleRadius()
        {
            return Math.Sqrt(10.0) * Math.Sqrt(5.0 + Math.Sqrt(5)) / 10.0 * SideLength;
        }
    }
    /*class Hexagon : MyGeometricFigure
    {
        public override double GetArea()
        {
            return;
        }

        public override double GetPerimeter()
        {
            return;
        }
    }*/

}
