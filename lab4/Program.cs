Order<int>[] mas = new Order<int>[3];
for (int i = 0; i < mas.Length; i++)
{
    Console.WriteLine("введите р/c плательщика");
    int rsp = int.Parse(Console.ReadLine()!);
    Console.WriteLine("введите р/c получателя");
    int rsd = int.Parse(Console.ReadLine()!);
    Console.WriteLine("введите сумму перевода");
    int summa = int.Parse(Console.ReadLine()!);
    mas[i] = new Order<int>(rsp, rsd, summa);
}

Array.Sort(mas);
foreach (var order in mas)
{
    Console.WriteLine(order);
}

Array.Sort(mas, new SortbySumma());
foreach (var order in mas)
{
    Console.WriteLine(order);
}

class Order<T> : ICloneable, IComparable
{
    public T RSpayment { get; set; }
    public T RSDestination { get; set; }
    public decimal Summa { get; set; }

    public Order(T rSpayment, T rSDestination, decimal summa)
    {
        RSpayment = rSpayment;
        RSDestination = rSDestination;
        Summa = summa;
    }

    public override string? ToString()
    {
        return $"Плательщик {RSpayment}, получатель {RSDestination}, сумма {Summa}";
    }

    public object Clone()
    {
        return new Order<T>(RSpayment, RSDestination, Summa);
    }

    public int CompareTo(object? obj)
    {
        if (obj is Order<int>)
        {
            Order<int> temp = (obj as Order<int>)!;
            return int.Parse(RSpayment!.ToString()!) - int.Parse(temp.RSpayment.ToString());
        }
        else if (obj is Order<string>)
        {
            Order<string> temp = (obj as Order<string>)!;
            return RSpayment!.ToString()!.CompareTo(temp.RSpayment);
        }
        else throw new Exception("лох");
    }
}

class SortbySumma : System.Collections.IComparer
{
    public int Compare(object? x, object? y)
    {
        if (x is Order<int>)
        {
            Order<int> X = (x as Order<int>)!;
            Order<int> Y = (y as Order<int>)!;
            if (X.Summa - Y.Summa > 0) return 1;
            else if (X.Summa - Y.Summa == 0) return 0;
            return -1;
        }
        else if (x is Order<string>)
        {
            Order<string> X = (x as Order<string>)!;
            Order<string> Y = (y as Order<string>)!;
            if (X.Summa - Y.Summa > 0) return 1;
            else if (X.Summa - Y.Summa == 0) return 0;
            return -1;
        }
        else throw new ArgumentException("Некорректное значение параметра");
    }
}