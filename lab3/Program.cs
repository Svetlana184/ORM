using lab3;

Console.WriteLine("Введите радиус окружности:");
double r = Double.Parse(Console.ReadLine()!);
Circle circle = new Circle()
{
    Radius = r,
    Name = "Окружность"
};
Console.WriteLine(circle);
Console.WriteLine("введите длину");
double l = Double.Parse(Console.ReadLine()!);
Console.WriteLine("введите ширину");
double w = Double.Parse(Console.ReadLine()!);
Triangle triangle = new Triangle()
{
    Name = "Треугольник",
    Width = w,
    Height = l,

};
Console.WriteLine(triangle);