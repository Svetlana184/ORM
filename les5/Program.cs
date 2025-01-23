Console.WriteLine("введите x");
double x1 = double.Parse(Console.ReadLine()!);
Console.WriteLine("введите y");
double y1 = double.Parse(Console.ReadLine()!);

Number n = new Number(x1,y1);

Console.WriteLine($"{n.X} + {n.Y} = {n.Add()}");
Console.WriteLine($"{n.X} - {n.Y} = {n.Sub()}");
Console.WriteLine($"{n.X} * {n.Y} = {n.Mult()}");
Console.WriteLine($"{n.X} / {n.Y} = {n.Div():F2}");
Console.WriteLine("введите x");
double x2 = double.Parse(Console.ReadLine()!);
Console.WriteLine("введите y");
double y2 = double.Parse(Console.ReadLine()!);

Number n2 = new Number(x2,y2);

Console.WriteLine(n + n2);


public interface IArOperation
{
    double Add();
    double Sub();
    double Mult();
    double Div();
}

public interface ISqrSqrt
{
    double Sqr();
    double Sqrt();
}

class Number : IArOperation, ISqrSqrt
{
    double x, y;
    public double X
    {
        get => x; 
        set { x = value; }
    }
    public double Y
    {
        get => y;
        set { y = value; }
    }
    public Number(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double Add() => x + y;

    public double Sub() => x - y;

    public double Mult() => x * y;

    public double Div()=> x / y;

    public double Sqr()=>x*x + y*y;

    public double Sqrt()=> Math.Sqrt(x*x + y*y);

    public static double operator +(Number a, Number b)
    {
        return a.X * b.X + a.Y * b.Y;
    }

}