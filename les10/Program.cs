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
//int Add(int x, int y) => x + y;
//int Sub(int x, int y) => x - y;
//int Mult(int x, int y) => x * y;
//int Div(int x, int y) => x / y;

//Operation operation = Add;
//Console.WriteLine(operation(5, 8));
//operation = Sub;
//Console.WriteLine(operation(10, 5));
//Operation operation1 = new Operation(Mult); //присвоение ссылки на метод
//operation1 = Div;
//Console.WriteLine(operation1.Invoke(6, 3));

//Console.WriteLine(operation1(1, 3));
//delegate int Operation(int x, int y);

//ЦЕПОЧКИ ДЕЛЕГАТОВ

//void Hello() => Console.WriteLine("Hello");
//void HowAreYou() => Console.WriteLine("How are you?");

//добавление и удаление элементов из цепочки делегатов
//Message message = Hello;
//message += HowAreYou;
//message += Hello;
//message += Hello;
//message();
//Console.WriteLine();
//message -= Hello;
//message -= Hello;
//message -= Hello;
//if (message != null) message();

//сложение делегатов
//Message message1 = HowAreYou;
//Message message2 = message + message1;
//Console.WriteLine();
//message2();
//delegate void Message();


//ОБОБЩЁННЫЕ ДЕЛЕГАТЫ

//decimal Square(int n) => n * n;
//int Double(int n) => n + n;

//Operation<decimal, int> squareOperation = Square;
//Console.WriteLine(squareOperation(5));
//Operation<int, int> doubleOperation = Double;
//Console.WriteLine(doubleOperation(5));

//delegate T Operation<T, K>(K val);


//ДЕЛЕГАТЫ КАК ПАРАМЕТРЫ МЕТОДОВ



//int Add(int x, int y) => x + y;
//int Sub(int x, int y) => x - y;
//int Div(int  x, int y) => x / y;
//int Mult(int  x, int y) => x * y;
//void DoOperation(int a, int b, Operation op)
//{
//    Console.WriteLine(op(a, b));
//}

//Operation SelectOperation(OperationType opType)
//{
//    switch (opType)
//    {
//        case OperationType.Add: return Add;
//        case OperationType.Sub: return Sub;
//        case OperationType.Div: return Div;
//        default: return Mult;
//    }

//}
//Console.WriteLine("введите первую переменную:");
//int x = int.Parse(Console.ReadLine()!);
//Console.WriteLine("введите вторую переменную:");
//int y = int.Parse(Console.ReadLine()!);
//Console.WriteLine("введите операцию (+, -, /, *)");
//char op = char.Parse(Console.ReadLine()!);
//Operation operatio;
//switch (op)
//{
//    case '+':
//        operatio = SelectOperation(OperationType.Add);
//        break;
//    case '-':
//        operatio = SelectOperation(OperationType.Sub);
//        break;
//    case '/':
//        operatio = SelectOperation(OperationType.Div);
//        break;
//    default:
//        operatio = SelectOperation(OperationType.Mult);
//        break;
//}
//Console.WriteLine(operatio(x,y));
//enum OperationType
//{
//    Add,
//    Sub,
//    Div,
//    Mult
//}
//delegate int Operation(int x, int y);



//ДЕЛЕГАТЫ ACTION, PREDICATE, FUNC

//action
void Add(int x, int y) => Console.WriteLine($"{x}+{y}={x+y}");
void Sub(int x, int y) => Console.WriteLine($"{x}-{y}={x - y}");
void Mult(int x, int y) => Console.WriteLine($"{x}*{y}={x * y}");

void DoOperation(int a, int b, Action<int, int> op)=> op(a, b);

DoOperation(16, 15, Add);
DoOperation(16, 15, Sub);
DoOperation(16, 15, Mult);
Console.WriteLine();

//Predicate
Predicate<int> isPositive = (int x) => x > 0;
Console.WriteLine(isPositive(6));
Console.WriteLine(isPositive(-6));
Console.WriteLine();

//Func
int Square(int n) => n * n;
int Double(int n) => n + n;

int DoOperationFunc(int n, Func<int, int> op) => op(n);
Console.WriteLine(DoOperationFunc(6, Square));
Console.WriteLine(DoOperationFunc(6, Double));
