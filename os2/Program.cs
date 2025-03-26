//процесс System.Diagnostics - Process
/*свойства
 * 
 * 
 */

using System.Diagnostics;
using System.Reflection;
using System.Threading.Channels;

//var process = Process.GetCurrentProcess();
//Console.WriteLine(process.Id);
//Console.WriteLine(process.Handle);
//Console.WriteLine(process.MachineName);
//Console.WriteLine(process.MainModule);
//Console.WriteLine(process.ProcessName);
//Console.WriteLine(process.StartTime);
//Console.WriteLine(process.PagedMemorySize64);
//Console.WriteLine(process.VirtualMemorySize64);


//foreach (Process pr in Process.GetProcesses())
//{
//    Console.WriteLine($"Id: {pr.Id}, Name: {pr.ProcessName}");
//}
//Console.WriteLine();
//Console.WriteLine();

//Process[] vsproc = Process.GetProcessesByName("devenv");
//foreach(Process pr in vsproc)
//{
//    Console.WriteLine($"Id: {pr.Id}, Name: {pr.ProcessName}");
//}

//Process[] vsproc = Process.GetProcessesByName("CalculatorApp");
//foreach (Process pr in vsproc) pr.Kill();

//Process calcProc = new Process();
//calcProc.StartInfo = new ProcessStartInfo("calc.exe");
//calcProc.Start();

//vsproc = Process.GetProcessesByName("devenv");
//foreach (Process pr in vsproc)
//{
//    pr.Kill();
//}


//Process vsproc = Process.GetProcessesByName("devenv")[0];
//ProcessThreadCollection processThreads = vsproc.Threads;
//ProcessModuleCollection modules = vsproc.Modules;
//foreach (ProcessThread thread in processThreads)
//{
//    Console.WriteLine($"ThreadId: {thread.Id}");
//}
//foreach (ProcessModule module in modules)
//{
//    Console.WriteLine($"{module.ModuleName} Filename: {module.FileName}");
//}

//Process.Start(@"C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", "https://mail.ru");

//ДОМЕНЫ ПРИЛОЖЕНИЙ
/*при запуске приложений, написанных на си шарп, ос создает процесс, а среда common language runtime (clr)
 * создает внутри этого процесса логический контейнер, который называется доменом приложения и 
 * внутри которого работает запущенное приложение
 * 
 * 
 */

//AppDomain domain = AppDomain.CurrentDomain;
//Console.WriteLine(domain.FriendlyName);
//Console.WriteLine(domain.BaseDirectory);
//Assembly[] assemblies = domain.GetAssemblies();
//foreach (Assembly assembly in assemblies)
//{
//    Console.WriteLine(assembly.GetName().Name);
//}




//ПАРАЛЛЕЛЬНОЕ ПРОГРАММИРОВАНИЕ((((( И БИБЛИОТЕКА TPL (task parallel library)

/* библиотека упрощает работу с многопроцессорными, многоядерными системами, упрощает работу по созданию
 * новых потоков
 * 
 * в основе библиотеки лежит концепция задач, каждая из которых описывает отдельную
 * продолжительную операцию (Task). Данный класс описывает отдельную задачу, которая запускается 
 * асинхронно в одном из потоков из пула потоков
 * 
 * задача это НЕ поток 1!!11!1!1
 * 
 * 
 * 
 */

//Task task1 = new Task(()=> 
//{
//    Console.WriteLine("Hello, world");
//    Thread.Sleep(1000);

//});
//task1.Start();
//Task task2 = Task.Factory.StartNew(() => 
//{
//    Console.WriteLine("Hello, world");
//    Thread.Sleep(1000);
//});
//Task task3 = Task.Run(() =>
//{
//    Console.WriteLine("Hello, task");
//    Thread.Sleep(1000);
//});

//task1.Wait();
//task2.Wait();
//task3.Wait();
//Console.WriteLine(task1.Id);
//Console.WriteLine(task1.AsyncState);
//Console.WriteLine(task1.Status);
//Console.WriteLine(task1.Exception);
//Console.WriteLine(task1.IsCompleted);
//Console.WriteLine(task1.IsCanceled);
//Console.WriteLine(task1.IsFaulted);
//Console.WriteLine(task1.IsCompletedSuccessfully);

//ВЛОЖЕННЫЕ ЗАДАЧИ

//var outer = Task.Factory.StartNew(() =>
//{
//    Console.WriteLine("Outer task starting ...");
//    var inner = Task.Factory.StartNew(() =>
//    {
//        Console.WriteLine("Inner task starting ...");
//        Thread.Sleep(2000);
//        Console.WriteLine("Inner task finishing ...");
//    }, TaskCreationOptions.AttachedToParent);
//});
//outer.Wait();
//Console.WriteLine("End of main");

//МАССИВ ЗАДАЧ

//Task[] tasks1 = new Task[3]
//{
//    new Task(() => Console.WriteLine("First task")),
//    new Task(() => Console.WriteLine("Second task")),
//    new Task(() => Console.WriteLine("Third task"))
//};

//foreach (var task in tasks1) task.Start();
//Task.WaitAll(tasks1);


//int Sum(int x, int y) => x + y;
//int n = 6, m = 7;
//Task<int> taskSum = new Task<int>(() => Sum(n, m));
//taskSum.Start();
//int res = taskSum.Result;
//Console.WriteLine($"{n} + {m} = {res}");


//Задачи продолжения continuation task
//int Sum(int x, int y) => x + y;
//void PrintResult(int sum) => Console.Write($"Sum: {sum}");
//Task<int> taskSum = new Task<int>(() => Sum(4,8));
//Task printTask = taskSum.ContinueWith(task => PrintResult(task.Result));
//taskSum.Start();
//printTask.Wait();



//класс Parallel

//void Print()
//{
//    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//    Thread.Sleep(1000);
//}
//void Square(int n)
//{
//    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//    Thread.Sleep(3000);
//    Console.WriteLine($"Результат {n*n}");
//}
//Parallel.Invoke(
//    Print,
//    () =>
//    {
//        Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//        Thread.Sleep(3000);
//    },
//    ()=>Square(10)
//);



//void Square(int n, ParallelLoopState pls)
//{
//    if (n==4) pls.Break();
//    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
//    Thread.Sleep(3000);
//    Console.WriteLine($"Результат {n * n}");
//}


//Parallel.For
//Parallel.For(1, 5, Square);

//Parallel.ForEach
//ParallelLoopResult result = Parallel.ForEach<int>(new List<int>() { 5,2,9,4}, Square);
//ParallelLoopResult result = Parallel.For(1, 10, Square);
//if (!result.IsCompleted) Console.WriteLine($"Завершение на итерации {result.LowestBreakIteration}");

//отмена задач и параллельных операций. CancellationToken


//мягкий выход из задачи без исключения OperationCanceledException
//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;
//Task task = new Task(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//        {
//            Console.WriteLine("операция прервана");
//            return;
//        }
//        Console.WriteLine($"квадрат числа {i} равен {i * i}");
//        Thread.Sleep(200);
//    }
//}, token);
//task.Start();
//cancelTokenSource.Cancel();
//Thread.Sleep(1000);
//Console.WriteLine($"TaskStatus: {task.Status}");
//cancelTokenSource.Dispose();

//отмена задачи с помощью генерации исключения

//CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
//CancellationToken token = cancelTokenSource.Token;
//Task task = new Task(() =>
//{
//    for (int i = 0; i < 10; i++)
//    {
//        if (token.IsCancellationRequested)
//        {
//            Console.WriteLine("операция прервана");
//            return;
//        }
//        Console.WriteLine($"квадрат числа {i} равен {i * i}");
//        Thread.Sleep(200);
//    }
//}, token);
//try
//{
//    task.Start();
//    Thread.Sleep(1000);
//    cancelTokenSource.Cancel();
//    task.Wait();
//}
//catch (AggregateException ae)
//{

//}
//finally
//{
//    cancelTokenSource.Dispose();
//}

//регистрация обработчика отмены задачи

CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
CancellationToken token = cancelTokenSource.Token;
Task task = new Task(() =>
{
    for (int i = 0; i < 10; i++)
    {
        if (token.IsCancellationRequested)
        {
            Console.WriteLine("операция прервана");
            return;
        }
        Console.WriteLine($"квадрат числа {i} равен {i * i}");
        Thread.Sleep(200);
    }
}, token);
task.Start();

//передача токенов во внешний метод

//отмена параллельных операций

