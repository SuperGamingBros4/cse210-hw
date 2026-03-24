using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test Square class
        Square square = new Square("red", 2);
        Console.WriteLine($"Square, color: {square.GetColor()}, area: {square.GetArea()}");

        // Test Rectangle class
        Rectangle rectangle = new Rectangle("yellow", 2, 4);
        Console.WriteLine($"Rectangle, color: {rectangle.GetColor()}, area: {rectangle.GetArea()}");

        // Test Circle class
        Circle circle = new Circle("green", 3);
        Console.WriteLine($"Circle, color: {circle.GetColor()}, area: {circle.GetArea()}");


        // Create a list of Shapes
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("red", 1.5));
        shapes.Add(new Square("green", 2.5));
        shapes.Add(new Circle("blue", 2.5));
        shapes.Add(new Rectangle("cyan", 1, 7.5));
        shapes.Add(new Rectangle("green", 14, 3.5));
        shapes.Add(new Circle("yellow", 10));

        // Print the color and area of the shapes
        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"color: {color}, area: {area}");
        }
    }
}