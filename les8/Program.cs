//ВСТРОЕННЫЕ ИНТЕРФЕЙСЫ
/*
 * ICloneable - поддерживает копирование, который создает новый экземпляр класса с тем же значением, что и существующий экземпляр
 * Перегружаемый метод Clone()
 * 
 * IComparable и IComparer - сортировка объектов
 * Ienumerator и IEnuramirable
 * IDisposible
 * 
 */

//ОПЕРАТОРЫ AS и IS
//as используется для выполнения опр преобразований типов
//is проверяет совместимость

var tom = new Person("RRR", 234, new Company("b"));
var bob = (Person)tom.Clone();
bob.Work.Name = "a";
bob.Name = "Vasya";
var helen = new Person("Helen", 234567, new Company("tr"));
Console.WriteLine(tom.Work.Name);
Console.WriteLine(bob.Work.Name);
Console.WriteLine();
Console.WriteLine(tom.CompareTo(bob));
Person[] mas = new Person[3]
{
    tom,
    bob,
    helen
};
Console.WriteLine();
Array.Sort(mas);
foreach (Person ma in mas) Console.WriteLine(ma);
Console.WriteLine();

Array.Sort(mas, new PeopleNameComparer());
foreach (Person ma in mas) Console.WriteLine(ma);
Console.WriteLine();

Array.Sort (mas, new PeopleAgeComparer());
foreach (Person ma in mas) Console.WriteLine(ma);
Console.WriteLine();

class Person : ICloneable, IComparable
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Company Work { get; set; }
    public Person(string name, int age, Company company)
    {
        Name = name;
        Age = age;
        Work = company;
    }

    public object Clone()
    {
        return new Person(Name, Age, new Company(Work.Name));
        //return new Person(Name,Age);
        //return MemberwiseClone();
    }

    public int CompareTo(object? obj)
    {
        if (obj is Person)
        {
            var person = obj as Person;
            var res = this.Work.Name.CompareTo(person?.Work.Name);
            if (res != 0)
            {
                return res;
            }
            return this.Name.CompareTo(person?.Name);
        }
        else
        {
            throw new Exception("невозможно сравнить два объекта");
        }
    }

    public override string? ToString()
    {
        return this.Name + " " + this.Age + " " + this.Work.Name;
    }

}
class PeopleNameComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x is null || y is null) throw new Exception("пользователь дурачёк");
        return x.Name.CompareTo(y.Name);
    }
}
class PeopleAgeComparer : IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x is null || y is null) throw new Exception("пользователь дурачёк");
        return x.Age-y.Age;
    }
}
class Company
{
    public string Name { get; set; }

    public Company(string name)=> Name = name;

}