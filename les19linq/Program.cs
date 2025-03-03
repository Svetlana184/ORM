// встроенный язык запросов



bool result = GetCars().All(c => c.Year > 1960);

bool result1 = GetCars().Any(c => c.Year <= 1960);

var strings = new MyStringList { "orange", "apple", "grape", "pear" };

foreach (var item in strings.Where(s => s.Length == 5))
{
    Console.Write(item + " ");
}
Console.WriteLine();
var q = strings.AsQueryable();
Console.WriteLine(q.ElementType);
Console.WriteLine(q.Expression);
Console.WriteLine(q.Provider);


int[] scores = { 88, 77, 99, 34, 68 };
IEnumerable<Object> objects = scores.Cast<object>();
object[] items = new object[] { 55, "Hello", 22, "Goodbye" };
foreach (var intItem in items.OfType<int>())
{
    Console.WriteLine(intItem);
}
Console.WriteLine();
Console.WriteLine("Max: " + scores.Max());
Console.WriteLine("Min: " + scores.Min());
Console.WriteLine("Average: " + scores.Average());
Console.WriteLine("Sum: " + scores.Sum());
Console.WriteLine("Count: " + scores.Count());
Console.WriteLine(scores.ElementAtOrDefault(99)); //защита от ошибок
//int score1 = scores.Where(x => x > 50 && x < 60).Single();
int score2 = scores.Where(x => x > 100).SingleOrDefault();
//Console.WriteLine(score1);
Console.WriteLine(score2);
Console.WriteLine();


var evenScore = scores.Where(p => p%2==0).ToList();
foreach (var score in evenScore)
{
    Console.WriteLine(score);
}
var cars = GetCars();
var carsByVin = cars.ToDictionary(c => c.VIN);
Car myCar = carsByVin["HIJ123"];
Console.WriteLine(myCar.Year + " " + myCar.Make + " " + myCar.Model);

//
List<Car> GetCars()
{
    return new List<Car>
                {
                    new Car { VIN = "ABC123", Make = "Ford",
                            Model = "F-250", Year = 2000 },
                    new Car { VIN = "DEF123", Make = "BMW",
                            Model = "Z-3", Year = 2005 },
                    new Car { VIN = "ABC456", Make = "Audi",
                            Model = "TT", Year = 2008 },
                    new Car { VIN = "HIJ123", Make = "VW",
                            Model = "Bug",  Year = 1956  },
                    new Car { VIN = "DEF456", Make = "Ford",
                            Model = "F-150", Year = 1998 }
                };
}
public class Car
{
    public string VIN { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }


}

public class MyStringList : List<string>
{
    public IEnumerable<string> Where(Predicate<string> filter)
    {
        return this.Select(s => filter(s) ? s.ToUpper() : s);
    }
}
