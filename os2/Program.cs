//процесс System.Diagnostics - Process
/*свойства
 * 
 * 
 */

using System.Diagnostics;
using System.Reflection;

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

Task task1 = new Task(()=> 
{
    Console.WriteLine("Hello, world");
    Thread.Sleep(1000);
        
});
task1.Start();
Task task2 = Task.Factory.StartNew(() => 
{
    Console.WriteLine("Hello, world");
    Thread.Sleep(1000);
});
Task task3 = Task.Run(() =>
{
    Console.WriteLine("Hello, task");
    Thread.Sleep(1000);
});

task1.Wait();
task2.Wait();
task3.Wait();
Console.WriteLine(task1.Id);
Console.WriteLine(task1.AsyncState);
Console.WriteLine(task1.Status);
Console.WriteLine(task1.Exception);
Console.WriteLine(task1.IsCompleted);
Console.WriteLine(task1.IsCanceled);
Console.WriteLine(task1.IsFaulted);
Console.WriteLine(task1.IsCompletedSuccessfully);