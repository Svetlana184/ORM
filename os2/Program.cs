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

AppDomain domain = AppDomain.CurrentDomain;
Console.WriteLine(domain.FriendlyName);
Console.WriteLine(domain.BaseDirectory);
Assembly[] assemblies = domain.GetAssemblies();
foreach (Assembly assembly in assemblies)
{
    Console.WriteLine(assembly.GetName().Name);
}