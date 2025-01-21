
namespace lab3
{
    internal class Triangle : IFigure
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Area()=> Width * Height;
        public double Perimetr()=> 2 * (Width + Height);

        public override string? ToString()
        {
            return $"{Name} площадью {Area():F2}, периметром {Perimetr():F2}";
        }
    }
}
