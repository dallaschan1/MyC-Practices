class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the length (a) Square Pyramid in metre: ");
        double length = double.Parse(Console.ReadLine());
        Console.Write("Enter the height (h) of Square Pyramid in metre: ");
        double height = Double.Parse(Console.ReadLine());
        SquarePyramid squarePyramid = new SquarePyramid(length, height);
        Console.WriteLine($"Volume of Square Pyramid : {squarePyramid.GetVolume()} cubic metre.");
        Console.WriteLine($"Surface Area of Square Pyramid : {squarePyramid.GetSurfaceArea()} square metre.");


    }
}

class SquarePyramid
{
    private double a;
    private double b;

    public double A { get { return a; } set { a = value; } }
    public double B { get { return b; } set { b = value; } }

    public SquarePyramid() { }
    public SquarePyramid(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public double GetVolume()
    {
        return ((Math.Pow(A,2) * B) / 3);
    }

    public double GetSurfaceArea()
    {
        return (A * (A + Math.Sqrt(Math.Pow(A,2) + 4 * Math.Pow(B,2))));
    }
}