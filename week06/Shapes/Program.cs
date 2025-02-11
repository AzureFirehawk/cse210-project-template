using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");

        List<Shape> shapes = new List<Shape>();
        Square square = new Square("red", 5.0);
        Rectangle rectangle = new Rectangle("blue", 4.0, 6.0);
        Circle circle = new Circle("green", 3.0);

        shapes.Add(square);
        shapes.Add(rectangle);    
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} {shape.GetArea()}");
        }
        
    }
}