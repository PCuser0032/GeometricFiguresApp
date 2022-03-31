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

    class Circle : MyGeometricFigure
    {
        public double Radius { get; set; }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2.0);
        }

        public override double GetPerimeter()
        {
            return 2.0 * Math.PI * Radius;
        }
    }

    class RegularPolygon : MyGeometricFigure
    {
        public double SideLength { get; set; }
        double NumberOfSides;

        public override double GetArea()
        {
            return NumberOfSides / 4.0 * Math.Pow(SideLength, 2.0) * 1.0 / Math.Tan(Math.PI / NumberOfSides);
        }

        public override double GetPerimeter()
        {
            return NumberOfSides * SideLength;
        }
        public double GetInscribedCircleRadius()
        {
            return GetCircumscribedCircleRadius() * Math.Cos(Math.PI / NumberOfSides);
        }

        public double GetCircumscribedCircleRadius()
        {
            return SideLength * 1 / 2.0 * 1.0 / Math.Sin(Math.PI / NumberOfSides);
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
        public double AngleAlpha { get; set; }
        public double AngleBeta { get; set; }

        public override double GetArea()
        {
            double p = GetPerimeter() / 2.0;
            return Math.Sqrt((p - AB) * (p - BC) * (p - CD) * (p - DA) - AB * BC * CD * DA * Math.Pow(Math.Cos(((AngleAlpha + AngleBeta) * Math.PI / 180.0) / 2.0), 2.0));
        }

        public override double GetPerimeter()
        {
            return AB + BC + CD + DA;
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

    class Trapeze : Quadrangle
    {
        public double Height { get; set; }

        public override double GetArea()
        {
            return (AB + CD) / 2.0 * Height;
        }
    }

    class Parallelogram : Quadrangle
    {
        public double Angle { get; set; }
        public override double GetArea()
        {
            return AB * DA * Math.Sin(Angle * Math.PI / 180.0);
        }
    }

    class Rhombus : Parallelogram
    {
        public override double GetArea()
        {
            return Math.Pow(AB, 2.0) * Math.Sin(Angle * Math.PI / 180.0);
        }

        public override double GetPerimeter()
        {
            return 4.0 * AB;
        }
    }

    class Square : RegularPolygon
    {
        public override double GetArea()
        {
            return SideLength * SideLength;
        }

        public override double GetPerimeter()
        {
            return 4.0 * SideLength;
        }
    }

    class Pentagon : RegularPolygon
    {
    }
    class Hexagon : RegularPolygon
    {
    }

    class Heptagon : RegularPolygon
    {
    }

    class Octagon : RegularPolygon
    {
    }

    class Nonagon : RegularPolygon
    {
    }

    class Decagon : RegularPolygon
    {
    }
}
