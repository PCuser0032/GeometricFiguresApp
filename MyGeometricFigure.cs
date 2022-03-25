namespace GeometricFigures
{
    public abstract class MyGeometricFigure
    {
        public string? Name { get; set; }
        public abstract double GetArea();
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

        public double GetCircleLength()
        {
            return 2.0 * Math.PI * Radius;
        }

        public void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Длина окружности: { GetCircleLength }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Радиус: R = { Radius }");
        }
    }

    public abstract class Polygon : MyGeometricFigure
    {
        public abstract double GetPerimeter();
        public abstract void GetInfo();
    }

    public abstract class RegularPolygon : Polygon
    {
        public double SideLength { get; set; }
    }

    class Triangle : Polygon
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

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длины сторон: AB = { AB }, BC = { BC }, CA = { CA }");
        }
    }

    public class Quadrangle : Polygon
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

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длины сторон: AB = { AB }, BC = { BC }, CD = { CD }, DA = { DA }");
            Console.WriteLine($"Величины углов:  Alpha = { AngleAlpha }, Beta = { AngleBeta }");
        }
    }

    class Rectangle : Polygon
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

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длины сторон: AB = CD = { Width }, BC = DA = { Height }");
        }
    }

    class Trapeze : Quadrangle
    {
        public double Height { get; set; }

        public override double GetArea()
        {
            return (AB + CD) / 2.0 * Height;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длины сторон: AB = { AB }, BC = { BC }, CD = { CD }, DA = { DA }");
            Console.WriteLine($"Высота трапеции: h = { Height }");
        }
    }

    class Parallelogram : Quadrangle
    {
        public double Angle { get; set; }
        public override double GetArea()
        {
            return AB * DA * Math.Sin(Angle * Math.PI / 180.0);
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длины сторон: AB = CD = { AB }, BC = DA = { DA }");
            Console.WriteLine($"Угол между сторонами AB и DA: { Angle }");
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
        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длина стороны: { AB }");
            Console.WriteLine($"Угол между сторонами AB и DA: { Angle }");
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

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длина стороны: { SideLength }");
        }
    }

    class Pentagon : RegularPolygon
    {
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

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длина стороны: { SideLength }");
        }
    }
    class Hexagon : RegularPolygon
    {
        public override double GetArea()
        {
            return 3.0 * Math.Sqrt(3) / 2.0 * Math.Pow(SideLength, 2.0);
        }

        public override double GetPerimeter()
        {
            return 6.0 * SideLength;
        }

        public double GetInscribedCircleRadius()
        {
            return Math.Sqrt(3) / 2.0 * SideLength;
        }

        public double GetCircumscribedCircleRadius()
        {
            return SideLength;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длина стороны: { SideLength }");
        }
    }

    class Heptagon : RegularPolygon
    {
        public override double GetArea()
        {
            return 7.0 / 4.0 * Math.Pow(SideLength, 2.0) * 1.0 / Math.Tan(Math.PI / 7.0);
        }

        public override double GetPerimeter()
        {
            return 7.0 * SideLength;
        }

        public double GetInscribedCircleRadius()
        {
            return GetCircumscribedCircleRadius() * Math.Cos(Math.PI / 7.0);
        }

        public double GetCircumscribedCircleRadius()
        {
            return SideLength / (2.0 * Math.Sin(Math.PI / 7.0));
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длина стороны: { SideLength }");
        }
    }

    class Octagon : RegularPolygon
    {
        public override double GetArea()
        {
            return 2.0 * 1.0 / Math.Tan(Math.PI / 8.0) * Math.Pow(SideLength, 2.0);
        }

        public override double GetPerimeter()
        {
            return 8.0 * SideLength;
        }

        public double GetInscribedCircleRadius()
        {
            return (1.0 + Math.Sqrt(2.0)) / 2.0 * SideLength;
        }

        public double GetCircumscribedCircleRadius()
        {
            return SideLength * Math.Sqrt((1.0 + Math.Sqrt(2.0)) / ((1.0 + Math.Sqrt(2.0) - 1.0)));
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длина стороны: { SideLength }");
        }
    }

    class Nonagon : RegularPolygon
    {
        public override double GetArea()
        {
            return 9.0 / 4.0 * Math.Pow(SideLength, 2.0) * 1.0 / Math.Tan(Math.PI / 9.0);
        }

        public override double GetPerimeter()
        {
            return 9.0 * SideLength;
        }

        public double GetInscribedCircleRadius()
        {
            return GetCircumscribedCircleRadius() * Math.Cos(Math.PI / 9.0);
        }

        public double GetCircumscribedCircleRadius()
        {
            return SideLength / (2.0 * Math.Sin(Math.PI / 9.0));
        }
        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длина стороны: { SideLength }");
        }

    }

    class Decagon : RegularPolygon
    {
        public override double GetArea()
        {
            return 5.0 / 2.0 * Math.Pow(SideLength, 2.0) * Math.Sqrt(5.0 + 2.0 * Math.Sqrt(5.0));
        }

        public override double GetPerimeter()
        {
            return 10.0 * SideLength;
        }

        public double GetInscribedCircleRadius()
        {
            return Math.Sqrt(5.0 + 2.0 * Math.Sqrt(5.0)) / 2.0 * SideLength;
        }

        public double GetCircumscribedCircleRadius()
        {
            return (Math.Sqrt(5.0) + 1.0) / 2.0 * SideLength;
        }

        public override void GetInfo()
        {
            Console.WriteLine($"Имя фигруры: { GetName() }");
            Console.WriteLine($"Периметр: { GetPerimeter() }");
            Console.WriteLine($"Площадь: { GetArea() }");
            Console.WriteLine($"Длина стороны: { SideLength }");
        }
    }
}
