//НАСЛЕДОВАНИЕ ОТ ИНТЕРФЕЙСА
/*Интерфейс - ссылочный тип, который состоит только из абстрактных членов
 * Когда класс реализует интерфейс, он должен предоставить реализацию для всех членов интерфейса
 * 
 * создание интерфейса (interface)
 * все методы публичные
 * нет полей, есть свойства
 * 
 */

Diablo diablo = new Diablo() { Name = "Хроменков"};
diablo.Move();
diablo.Eat();
Car car = new Car() { Name="БМВ"};
car.Move();
DoAction(diablo);
DoAction(car);



void DoAction(IMovable movable) => movable.Move();
interface IMovable
{
    const int minSpeed = 0;
    const int maxSpeed = 220;
    void Move();
    string Name { get; set; }
}
interface IEatable
{
    void Eat();
}
class Diablo : IMovable, IEatable
{
    public string Name { get; set ; }

    public void Eat()
    {
        Console.WriteLine($"{Name} ест всякую гадость");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} ползает по дну, ракообразное создание");
    }
}
class Car : IMovable
{
    public string Name { get; set; }

    public void Move()
    {
        Console.WriteLine($"{Name} едет по дороге!");
    }
}