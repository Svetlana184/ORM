Console.WriteLine("введите радиус окружности");
double radius = double.Parse(Console.ReadLine()!);
Circle circle = new Circle()
{
    Name = "окружность",
    Radius = radius
};
Console.WriteLine(circle);
Console.WriteLine("введите ширину");
double width = double.Parse(Console.ReadLine()!);
Console.WriteLine("введите длину");
double length = double.Parse(Console.ReadLine()!);
Rectangle rectangle = new Rectangle()
{
    Name = "прямоугольник",
};
abstract class Figure
{
    public string? Name { get; set; }
    public abstract double GetArea();
    public abstract double GetPerimetr();

}

class Circle : Figure
{
    public double Radius { get; set; }
    public override double GetArea() => Math.PI * Radius * Radius;

    public override double GetPerimetr() => 2 * Math.PI * Radius;

    public override string? ToString()
    {
        return $"Площадь: {GetArea():F2}, периметр: {GetPerimetr():F2}";
    }
}

class Rectangle : Figure
{
    public double Width { get; set; }
    public double Length { get; set; }
    public override double GetArea() => Width * Length;

    public override double GetPerimetr() => 2 * (Width + Length);

    public override string? ToString()
    {
        return $"Площадь: {GetArea():F2}, периметр: {GetPerimetr():F2}";
    }
}

class Parallelepiped : Figure
{
    private double Width { get; set; }
    private double Height { get; set; }
    private double Length { get; set; }
    public override double GetArea() => (Width + Length) * Height + 2 * (Width * Length);

    public override double GetPerimetr() => (Width + Length + Height) * 4;

    public double GetVolume() => Width * Height * Length;

    public override string? ToString()
    {
        return $"Площадь: {GetArea():F2}, периметр: {GetPerimetr():F2}, объём: {GetVolume():F2}";
    }
}
