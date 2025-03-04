using System.Xml.Linq;

int[] arrayInt = { 5, 34, 67, 12, 94, 42 };

IEnumerable<int> query = from i in arrayInt
                         where i%2==0
                         orderby i descending //сортировка
                         select i;
foreach (var item in query)
{
    Console.Write(item + " ");
}
Console.WriteLine();
var people = new List<Person>
{
    new Person()
    {
        Name="Tom",
        Age=25
    },
    new Person()
    {
        Name="Bob",
        Age=28
    },
    new Person()
    {
        Name="Sam",
        Age=31
    },
    new Person()
    {
        Name="Alice",
        Age=17
    }
};
//var names = from p in people select p.Name;
var names = people.Select(p => p.Name);
foreach (var name in names)
{
    Console.Write(name + " ");
}
Console.WriteLine();
//var birthDays = from p in people
//                select new
//                {
//                    Name = p.Name,
//                    Year = DateTime.Now.Year - p.Age
//                };
//var birthDays = people.Select(
//                p => new
//                {
//                    Name = p.Name,
//                    Year = DateTime.Now.Year - p.Age
//                });
var birthDays = from p in people
                let name=$"Mr.{p.Name}"
                let year = DateTime.Now.Year - p.Age
                select new
                {
                    Name = name,
                    Year = year
                };

foreach (var birthDay in birthDays)
{
    Console.WriteLine(birthDay.Name + " " + birthDay.Year);
}
Console.WriteLine();
//разность коллекций
int[] mas1 = { 5, 2, 8, 1, 9, 4 };
int[] mas2 = { 7, 2, 3, 4, 5, 10 };
var res1 = mas1.Except(mas2);
foreach (var res in res1)
{
    Console.Write(res + " ");
}
Console.WriteLine();
var res2 = mas1.Intersect(mas2);
foreach (var res in res2)
{
    Console.Write(res + " ");
}
Console.WriteLine();
var res3 = mas1.Distinct();
foreach (var res in res3)
{
    Console.Write(res + " ");
}
Console.WriteLine();
var res4 = mas1.Union(mas2);
foreach (var res in res4)
{
    Console.Write(res + " ");
}
Console.WriteLine();


//агрегатные функции
foreach (var i in mas1) Console.Write(i + " ");
Console.WriteLine();
int q = mas1.Aggregate((x, y) => x - y); 
Console.WriteLine(q);
q = mas1.Aggregate((x,y) => x + y);
Console.WriteLine(q);

int countMas1 = mas1.Count();
Console.WriteLine(countMas1);
int count2 = mas1.Count(x => x % 2 != 0 && x > 3);
Console.WriteLine(count2);

int sum1 = mas1.Sum();
Console.WriteLine(sum1);
int sum2= mas2.Where(p => p%2!=0).Sum();
Console.WriteLine(sum2); //нечетные чиселки
Console.WriteLine(mas1.Max(x => x%2!=0));
Console.WriteLine(mas1.Min(x => x % 2 == 0));
Console.WriteLine(mas1.Where(x => x%2==0).Average());

//обращение к индексам
Console.WriteLine(mas1.Where((m,n)=> n %2!=0).Sum());
Random random = new Random();
//mas1 = mas1.Where((m, n) => m = random.Next(20));
int[] mas = new int[32];
mas = mas.Select((i,j)=> i = random.Next(1, 10)).ToArray();
foreach (int x in mas)
{
    Console.Write(x + " ");
}
Console.WriteLine();
//метод skip - пропускает кол-во элементов, которые передаются как параметр

int s1 = mas.Skip(4).Sum();
Console.WriteLine(s1);
int s2 = mas.SkipLast(4).Sum();
Console.WriteLine(s2);
int s3 = mas.SkipWhile(x => x%2!=0).Sum(); //пропускает нечетные элементы
Console.WriteLine(s3);

int t1 = mas.Take(3).Sum();
Console.WriteLine(t1);
int t2 = mas.TakeLast(4).Sum();
Console.WriteLine(t2);
int t3 = mas.TakeWhile(x => x % 2 == 0).Sum(); //берет только четные элементы
Console.WriteLine(t3);
Console.Clear();
//for (int j = 0; j < mas.Length/10+1; j++)
//{
//    Console.Clear();
//    int[] temp = mas.Skip(j*10).Take(10).ToArray();
//    foreach(int x in temp) Console.Write(x + " ");
//    Console.ReadKey();
//}
//var cars = GetCars();
//var company = cars.GroupBy(p => p.Make);
//foreach (var car in company)
//{
//    Console.WriteLine(car.Key);
//    foreach (var j in car)
//    {
//        Console.WriteLine(j.Year + " " + j.Model + " " + j.VIN);
//    }
//}
//var cars = GetCars().OrderBy(c => c.Make)
//                            .ThenByDescending(c => c.Model)
//                            .ThenBy(c => c.Year);
//foreach (var item in cars)
//{
//    Console.WriteLine("Car VIN:{0} Make:{1} Model:{2} Year:{3}",
//        item.VIN, item.Make, item.Model, item.Year);
//}


//JOIN

//var makes = new string[] { "Audi", "BMW", "Ford", "Mazda", "VW" };
//var cars = GetCars();

//var query1 = makes.Join(cars,
//    make => make, car => car.Make,
//    (make, innerCar) => new { Make = make, Car = innerCar });
//foreach (var item in query1)
//{
//    Console.WriteLine("Make: {0}, Car:{1} {2} {3}",
//                        item.Make, item.Car.VIN, item.Car.Make, item.Car.Model);
//}
//Console.WriteLine();

//GROUPJOIN

//var query2 = makes.GroupJoin(cars,
//    make => make, car => car.Make,
//    (make, innerCars) => new { Make = make, Cars = innerCars });
//foreach (var item in query2)
//{
//    Console.WriteLine("Make: {0}", item.Make);
//    foreach (var car in item.Cars)
//    { Console.WriteLine("Car VIN:{0}, Model:{1}", car.VIN, car.Model); }
//}


var numbers = Enumerable.Range(1, 1000);
var cars = GetCars();
var zip = numbers.Zip(cars, (i, c) => new
{
    Number = i,
    CarMake = c.Make
});
foreach (var it in zip)
{
    Console.WriteLine("Number:{0} Make:{1}", it.Number, it.CarMake);
}



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
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

}