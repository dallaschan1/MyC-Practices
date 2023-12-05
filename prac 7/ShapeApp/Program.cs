using System;
using System.Collections.Generic;
using System.Linq;


public abstract class Shape
{
    protected string type;
    protected string color;

    public Shape(string type, string color)
    {
        this.type = type;
        this.color = color;
    }

    public abstract double FindArea();
    public abstract double FindPerimeter();

    public override string ToString()
    {
        return $"Shape: {type}, Color: {color}";
    }
}

public class Circle : Shape
{
    private double radius;

    public Circle(string color, double radius) : base("Circle", color)
    {
        this.radius = radius;
    }

    public override double FindArea()
    {
        return Math.PI * Math.Pow(radius, 2);
    }

    public override double FindPerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public void SetRadius(double radius)
    {
        this.radius = radius;
    }

    public override string ToString()
    {
        return base.ToString() + $", Radius: {radius}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Circle> circleList = new List<Circle>();
        InitCircleList(circleList);

        while (true)
        {
            Console.WriteLine("\n1. List all circles\n2. Display areas of circles\n3. Display perimeters of circles\n4. Change size of a circle\n5. Add a new circle\n6. Delete a circle\n7. Display circles sorted by area\n0. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    ListCircles(circleList);
                    break;
                case 2:
                    DisplayAreas(circleList);
                    break;
                case 3:
                    DisplayPerimeters(circleList);
                    break;
                case 4:
                    ChangeCircleSize(circleList);
                    break;
                case 5:
                    AddCircle(circleList);
                    break;
                case 6:
                    DeleteCircle(circleList);
                    break;
                case 7:
                    DisplaySortedCircles(circleList);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void InitCircleList(List<Circle> cList)
    {
        cList.Add(new Circle("Red", 2.5));
        cList.Add(new Circle("Green", 3.5));
        cList.Add(new Circle("Blue", 4.5));
    }

    static void ListCircles(List<Circle> cList)
    {
        foreach (var circle in cList)
        {
            Console.WriteLine(circle);
        }
    }

    static void DisplayAreas(List<Circle> cList)
    {
        foreach (var circle in cList)
        {
            Console.WriteLine($"{circle}: Area = {circle.FindArea():F2}");
        }
    }

    static void DisplayPerimeters(List<Circle> cList)
    {
        foreach (var circle in cList)
        {
            Console.WriteLine($"{circle}: Perimeter = {circle.FindPerimeter():F2}");
        }
    }

    static void ChangeCircleSize(List<Circle> cList)
    {
        ListCircles(cList);
        Console.Write("Enter circle index to resize: ");
        int index = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter new radius: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        cList[index].SetRadius(radius);
    }

    static void AddCircle(List<Circle> cList)
    {
        Console.Write("Enter color of new circle: ");
        string color = Console.ReadLine();
        Console.Write("Enter radius of new circle: ");
        double radius = Convert.ToDouble(Console.ReadLine());
        cList.Add(new Circle(color, radius));
    }

    static void DeleteCircle(List<Circle> cList)
    {
        ListCircles(cList);
        Console.Write("Enter circle index to delete: ");
        int index = Convert.ToInt32(Console.ReadLine());
        cList.RemoveAt(index);
    }

    static void DisplaySortedCircles(List<Circle> cList)
    {
        var sortedCircles = cList.OrderBy(c => c.FindArea()).ToList();
        foreach (var circle in sortedCircles)
        {
            Console.WriteLine(circle);
        }
    }
}
