using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Yellow", 5);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Orange", 2, 6);
        shapes.Add(s2);

        Circle s3 = new Circle("Blue", 7);
        shapes.Add(s3);

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}