

//GENERICS


Person<int, int> person1 = new Person<int, int>(457, "Tom", 45);
Person<string, string> person2 = new Person<string, string>("eee3", "Bob", "pppp");
Console.WriteLine(person1.Id);
Console.WriteLine(person2.Id);
Company<Person<int, int>> chromenSoft = new Company<Person<int, int>>(person1);
Console.WriteLine(chromenSoft.CEO.Id);
Console.WriteLine(chromenSoft.CEO.Name);

Console.WriteLine();
IUser<int> user1 = new User<int>(123);
Console.WriteLine(user1.id);
IUser<string> user2 = new User<string>("qwerty");
Console.WriteLine(user2.id);


class Person<T, K>
{
    public T Id { get;}
    public K Password { get; set; }
    public string Name { get;}

    public Person(T id, string name, K password)
    {
        Id = id;
        Name = name;
        Password = password;
    }
}

class Company<P>
{
    public P CEO { get; set; }

    public Company(P ceo)
    {
        CEO = ceo;
    }
}

class UniversalPerson<T, K> : Person<T, K>
{
    public UniversalPerson(T id, string name, K password) : base(id, name, password)
    {

    }
}


interface IUser<T>
{
    T id { get; }

}
class User<T> : IUser<T>
{
    public T id { get; }
    public User(T id)
    {
        this.id = id;
    }
}


//class PersonInt
//{
//    public object Id { get; }
//    public string Name { get; }

//    public PersonInt(object id, string name)
//    {
//        Id = id;
//        Name = name;
//    }
//}
//class PersonString
//{
//    public string Id { get; }
//    public string Name { get; }

//    public PersonString(string id, string name)
//    {
//        Id = id;
//        Name = name;
//    }
//}