using GeometricFigures;

Console.WriteLine("Implementation of the inheritance mechanism on the example of geometric shapes on C#.");
Console.WriteLine("Created by Kozlov D., group VPI-31.");

Triangle a = new Triangle() { AB = 3.0, BC = 4.0, CA = 5.0, Name = "Triangle ABC"};

Console.WriteLine($"{ a.GetPerimeter() }");
Console.WriteLine($"{ a.GetName() }");