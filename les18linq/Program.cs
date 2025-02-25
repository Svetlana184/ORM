//ОСНОВЫ linq
/*
 * Составляющие:
 * 
 * автоматические св-ва
 * 
 * инициализаторы объектов и коллекций
 * 
 * анонимные типы
 * 
 * методы расширения
 * 
 * лямбда-выражения
 * 
 */
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

//var car = new { Make = "VW", Model = "Bug" }; //анонимный тип
string mail = "golubchikov@mail.ru";
Console.WriteLine(mail.IsValidEmailAddress());
Console.WriteLine(mail.CountWord('u'));
//List<Car> cars = GetCars();
//List<Car> filtered = new List<Car>();
//foreach (Car car in cars)
//{
//    if (car.Year > 1990 && car.Model.StartsWith("F"))
//    {
//        filtered.Add(car);
//    }
//}
//foreach (Car car in filtered)
//{
//    Console.Write(car.Model + " ");
//}

//List<Car> cars = GetCars();
////List<Car> filtered = new List<Car>();
//List<FilterPredicate> predicates = new List<FilterPredicate>();
//predicates.Add(delegate (Car car) { return car.Year > 1990; });
//predicates.Add(delegate (Car car) { return car.Model.StartsWith("F"); });
//List<Car> filtered = new List<Car>();
//foreach (Car car in cars)
//{
//    if (CheckPredicates(car, predicates)) { filtered.Add(car); }
//}

////foreach (Car car in cars)
////{
////    if (FilterYear(car) && FilterModel(car))
////    {
////        filtered.Add(car);
////    }
////}
//foreach (Car car in filtered)
//{
//    Console.Write(car.Model + " ");
//}

List<Car> cars = GetCars();

List<FilterPredicate> predicates = new List<FilterPredicate>();
predicates.Add(car => car.Year > 1990);
predicates.Add(car => car.Model.StartsWith("F"));

List<Car> filtered = new List<Car>();
foreach (Car car in cars)
{
    if (CheckPredicates(car, predicates)) { filtered.Add(car); }
}
foreach (Car car in filtered)
{
    Console.Write(car.Model + " ");
}


bool FilterYear(Car car) { return car.Year > 1990; }
bool FilterModel(Car car) { return car.Model.StartsWith("F"); }
bool CheckPredicates(Car car, IList<FilterPredicate> predicates)
{
    foreach (FilterPredicate p in predicates)
    {
        if (!p(car)) { return false; }
    }

    return true;
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
    public string Model {  get; set; }
    public int Year { get; set; }
    public string Color { get; set; }
    

}

public static class MyExtension
{
    public static bool IsValidEmailAddress(this string s)
    {
        Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
        return regex.IsMatch(s);

    }
    public static int CountWord(this string str, char ch)
    {
        int count = 0;
        foreach (char i in str)
        {
            if (i == ch) count++;
        }
        return count;
    }
}
public delegate bool FilterPredicate(Car car);

/*ПРАВИЛА МЕТОДОВ РАСШИРЕНИЙ
 * Метод расширения и класс, в котором он объявлен, должны быть статическими с модификатором public
Первый параметр определяет, с каким типом оперирует метод, и перед параметром идет модификатор this
Методы расширения не могут получить доступ к закрытым переменным типа, для расширения которого они используются
Методы расширения находятся в области действия, только если пространство имен было явно импортировано в исходный код с помощью директивы using 
Методы расширения не могут переопределить методы класса

 */