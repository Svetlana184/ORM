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
mas1 = mas1.Where((m, n) => m = random.Next(20));
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

}