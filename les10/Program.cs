//ДЕЛЕГАТ - объект, безопасный в отношении типов, указывающий на метод
/*
 * СОДЕРЖИТ
 * ссылку на объект
 * ссылку на метод
 * 
 * 
 */


//пример 1
//void Hello() => Console.WriteLine("Hello"); 
//void Display() => Console.WriteLine("...");
//Message mes; //2. создаем переменную делегата
//mes = Hello; //3. присваиваем переменной адрес метода
//mes(); //4. вызываем метод 
//mes = Display;
//mes();
//mes = Welcome.Print;
//mes();
//class Welcome
//{
//    public static void Print() => Console.WriteLine("Welcome");
//}
//delegate void Message(); //1. объявление делегата



//пример 2 
int Add(int x, int y) => x + y;
int Sub(int x, int y) => x - y;
int Mult(int x, int y) => x * y;
int Div(int x, int y) => x / y;

Operation operation = Add;
Console.WriteLine(operation(5, 8));
operation = Sub;
Console.WriteLine(operation(10, 5));
Operation operation1 = new Operation(Mult); //присвоение ссылки на метод

Console.WriteLine(operation1(1, 3));
delegate int Operation(int x, int y);
