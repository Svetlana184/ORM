// ИСКЛЮЧИТЕЛЬНЫЕ СИТУАЦИИ
/*
 * исключительная ситуация - это возникновение в программе непредвиденного события, 
 * которое может порождаться некорректным использованием аппаратуры или непавильной работы программы
 * 
 */
try
{
    Console.WriteLine("Введите число");
    int n = int.Parse(Console.ReadLine()!);
    if (n < 0)
    {
        throw new FactorialException("Факториал не может быть меньше нуля", n);
    }
}
catch(FactorialException e)
{
    Console.WriteLine(e.Message + " " + e.Value);
}





class FactorialException : Exception
{
    public int Value {  get;}
    public FactorialException(string? message, int val) : base(message)
    {
        Value = val;
    }
}


//try
//{
//    Console.WriteLine("введите сложный пароль");
//    string password = Console.ReadLine()!;
//    if (password == null || password.Length < 4)
//    {
//        throw new Exception("длина пароля не должна быть меньше 4 символов");
//    }
//    else
//    {
//        Console.WriteLine("Ваш пароль " + password);
//    }
//}
//catch(Exception ex)
//{
//    Console.WriteLine($"Ошибка: {ex.Message}");
//}

//int z = 0;
//try
//{
//    Console.WriteLine("введите z");
//    if (int.TryParse(Console.ReadLine(), out z))
//    {
//        int x = 3;
//        int y = x / z;
//        Console.WriteLine(y);
//        int w = z / x;
//        Console.WriteLine(w);
//    }
//    int[] mas = { 1, 2, 3 };
//    mas[1] = 67;
//    object str = "help";
//    int g = (int)str;
//}
//catch(DivideByZeroException) when (z == 0)
//{
//    Console.WriteLine("Нельзя z ноль");
//}
//catch (DivideByZeroException)
//{
//    Console.WriteLine("нельзя x ноль");
//}
//catch (IndexOutOfRangeException)
//{
//    Console.WriteLine("длина массива меньше");
//}
//catch(Exception e)
//{
//    Console.WriteLine(e.Message);
//}
//finally
//{
//    Console.WriteLine("блок завершил свою работу");
//}