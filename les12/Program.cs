//ЗАМЫКАНИЯ
//Action Outer()
//{
//    int x = 5;
//    void Inner()
//    {
//        x++;
//        Console.WriteLine(x);
//    }
//    return Inner;
//}
//var OuterFn = () =>
//{
//    int x = 10;
//    var innerFn = () => Console.WriteLine(++x);
//    return innerFn;
//};
//var f = Outer();
//f();
//f();
//f();
//f();
//Console.WriteLine();
//var fn = OuterFn();
//fn();
//fn();
//fn();
//Console.WriteLine();

//Func<int, int> fact = null!;
//fact = (int x) => x > 1 ? x * fact(x - 1) : 1;
//Console.WriteLine(fact(5));
//Console.WriteLine();

//var mult = (int n) => (int m) => m * n;
//var fmult = mult(5);
//Console.WriteLine(fmult(3));
//Console.WriteLine(fmult(4));




//СОБЫТИЯ - некоторая программная конструкция, которая упрощает создание делегатов и методов
void DisplayMessage(Account sender, AccountEventArgs e)
{
    Console.WriteLine($"Сумма транзакций: {e.Sum}");
    Console.WriteLine(e.Message);
    Console.WriteLine($"Текущая сумма на счёте: {sender.Sum}");
    Console.WriteLine();
}

Account account = new Account(100);
account.Notify += DisplayMessage;
account.Put(20);
account.Take(70);
//account.Notify -= DisplayMessage;
account.Take(180);

class AccountEventArgs
{
    public string Message { get; }
    public int Sum { get; }

    public AccountEventArgs(string message, int sum)
    {
        Message = message;
        Sum = sum;
    }
}
class Account
{
    public delegate void AccountHandler(Account sender, AccountEventArgs e);
    public event AccountHandler? Notify;
    public int Sum { get; private set; }
    public Account(int sum) => Sum = sum;
    public void Put(int sum)
    {
        Sum += sum;
        Notify?.Invoke(this, new AccountEventArgs($"На счёт поступило {sum}. Баланс {Sum}", sum));
    }
    
    public void Take(int sum)
    {
        if (Sum >= sum)
        {
            Sum -= sum;
            Notify?.Invoke(this, new AccountEventArgs($"Снято со счёта {sum}. Баланс {Sum}", sum));
        }
        else
        {
            Notify?.Invoke(this, new AccountEventArgs($"На счётe недостаточно средств. Баланс {Sum}", sum));
        }
    }
}

//Ковариантность (приведение от частного к общему) и контрвариантность (приведение общего к частному) делегатов и интерфейсов