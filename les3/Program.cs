//индексаторы позволяют индексировать объекты и обращаться к данным по индексу
//по форме они напоминают свойста со стандартными блоками get и set, который возвращают и присваивают значения
//определение индексатора:
//возвр_тип this [тип параметр1, ..]
//{
//get {}
//set{}
//}
Person p1 = new Person("Голубчиков");
Person p2 = new Person("Габитов");
Person p3 = new Person("Хроменков");
Person[] comp = new Person[3];
comp[0] = p1;
comp[1] = p2;
comp[2] = p3;

Company company = new Company(comp);
Console.WriteLine(company.people[0].Name); //без индексатора
Console.WriteLine(company[0].Name);  //с индексатором
class Person
{
    public string? Name { get; }
    public Person(string? name) => Name = name;

}

class Company
{
    public Person[] people;
    public Company(Person[] people) => this.people = people;
    public Person this[int index]
    {
        get
        {
            if (index >= 0 && index < people.Length) return people[index];
            else throw new ArgumentOutOfRangeException();
        }
        set
        {
            if (index >= 0 && index < people.Length) people[index] = value;
        }
    }

}
