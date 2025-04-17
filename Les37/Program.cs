//string path = "person.dat";

//// создаем объект BinaryWriter
//using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
//{
//    // записываем в файл строку
//    writer.Write("Tom");
//    // записываем в файл число int
//    writer.Write(37);
//    Console.WriteLine("File has been written");
//}

//using (BinaryReader reader = new BinaryReader(File.Open("person.dat", FileMode.Open)))
//{
//    // считываем из файла строку
//    string name = reader.ReadString();
//    // считываем из файла число 
//    int age = reader.ReadInt32();
//    Console.WriteLine($"Name: {name}  Age: {age}");
//}

using System;

string path = "people.dat";

// массив для записи
Person[] people =
{
    new Person("Tom", 37),
    new Person("Bob", 41)
};

using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
{
    // записываем в файл значение каждого свойства объекта
    foreach (Person person in people)
    {
        writer.Write(person.Name);
        writer.Write(person.Age);
    }
    Console.WriteLine("File has been written");
}

List<Person> people1 = new List<Person>();

// создаем объект BinaryWriter
using (BinaryReader reader = new BinaryReader(File.Open("people.dat", FileMode.Open)))
{
    // пока не достигнут конец файла
    // считываем каждое значение из файла
    while (reader.PeekChar() > -1)
    {
        string name = reader.ReadString();
        int age = reader.ReadInt32();
        // по считанным данным создаем объект Person и добавляем в список
        people1.Add(new Person(name, age));
    }
}
// выводим содержимое списка people на консоль
foreach (Person person in people1)
{
    Console.WriteLine($"Name: {person.Name}  Age: {person.Age}");
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}