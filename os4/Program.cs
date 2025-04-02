//АССИНХРОННОСТЬ
// ассинхронность позволяет вынести отдельные задачи из основного потока в спец асинхронные методы. При этом более экономно использовать потоки
//асинхронные методы выполняются в отдельных потоках
/*
 * async/await
 * ассинхронный метод обладает след. признаками:
 *  - в заголовке метода используется модификатор async
 *  - метод содержит одно или несколько выражений await
 *  - в качестве возвращаемого типа используется один из: void, task, task<t>, valuetask<t>
 * 
 * ассинхронный метод не может определять параметры с модификаторами out, ref, in
 */

void Print()
{
    Thread.Sleep(3000);
    Console.WriteLine("Hello");
}
async Task PrintAsync()
{
    Console.WriteLine("начало метода PrintAsync");
    await Task.Run(Print);
    Console.WriteLine("конец метода PrintAsync");
}
async Task PrintNameAsync(string name)
{
    await Task.Delay(3000);
    Console.WriteLine(name);
}

async void VoidPrintAsync(string mes)
{
    await Task.Delay(1000);
    Console.WriteLine(mes);
}

//await PrintAsync();
//await PrintNameAsync("Tom");
//await PrintNameAsync("Bob");
//await PrintNameAsync("Sam");

//VoidPrintAsync("hi");
//await Task.Delay(2000);


//Task<T>
async Task<int> SquareAsync(int n)
{
    await Task.Delay(0);
    return n * n;
}
//int n1 = await SquareAsync(7);
//int n2 = await SquareAsync(9);
//Console.WriteLine($"n1={n1}; n2={n2}");



//ValueTask<T>

ValueTask<int> AddAsync(int a, int b)
{
    return new ValueTask<int>(a + b);
}
//var result = await AddAsync(2, 5);

//последовательное и параллельное выполнение. Task.WhenAll Task.WhenAny

//var task1 = PrintNameAsync("first");
//var task2 = PrintNameAsync("second");
//var task3 = PrintNameAsync("third");

//await task1;
//await task2;
//await task3;

//await Task.WhenAll(task1, task2, task3);
//await Task.WhenAny(task1, task2, task3);
async Task<int> SquareAsynccc(int n)
{
    await Task.Delay(1000);
    return n * n;
}
//var task4 = SquareAsynccc(3);
//var task5 = SquareAsynccc(8);
//var task6 = SquareAsynccc(5);

//int[] result = await Task.WhenAll(task4, task5, task6);
//foreach (int i in result) Console.WriteLine(i);
//await Task.WhenAll(task4, task5, task6);
//Console.WriteLine(task6.Result);

//async IAsyncEnumerable<int> GetNumberAsync()
//{
//    for (int i = 0; i < 10; i++)
//    {
//        await Task.Delay(1000);
//        yield return i;
//    }
//}
//await foreach (var num in GetNumberAsync())
//{
//    Console.WriteLine(num);
//}

//обработка ошибок в ассинхронных методах

async Task PrintException(string news)
{
    if(news.Length < 3)
    {
        throw new ArgumentException($"длина слишком маленькая");
    }
    await Task.Delay(1000);
    Console.WriteLine(news);
}

try
{
    await PrintException("hiiiii");
}
catch(Exception e)
{
    Console.WriteLine(e.ToString());
}