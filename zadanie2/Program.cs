Console.WriteLine("введите число секунд");
int s = int.Parse(Console.ReadLine()!);
OurTime timee = s;
Console.WriteLine(timee);
OurTime our = new OurTime()
{
    Hour = 3,
    Minute = 20,
    Seconds = 5

};
Console.WriteLine((int)our);

class OurTime
{
    public int Hour { get; set; }
    public int Minute { get; set; }
    public int Seconds { get; set; }

    public override string? ToString()
    {
        return Hour + ":" + Minute + ":" + Seconds;
    }

    public static implicit operator OurTime(int x)
    {
        return new OurTime
        {
            Hour = x / 3600,
            Minute = x % 3600 / 60,
            Seconds = x % 60
        };

    }

    public static explicit operator int(OurTime x) { return x.Hour * 3600 + x.Minute * 60 + x.Seconds; }
}