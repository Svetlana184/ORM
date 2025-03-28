﻿
namespace lab3
{
    internal class Circle : IFigure
    {
        public string Name { get; set; }
        public double Radius { get; set; }

        public double Area()=>Math.PI * Radius * Radius;

        public double Perimetr()=> 2* Math.PI* Radius;

        public override string? ToString()
        {
            return $"{Name} площадью {Area():F2}, периметром {Perimetr():F2}";
        }
    }
}
