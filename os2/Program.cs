//процесс System.Diagnostics - Process
/*свойства
 * 
 * 
 */

using System.Diagnostics;


var process = Process.GetCurrentProcess();
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

Process[] vsproc = Process.GetProcessesByName("CalculatorApp");
foreach (Process pr in vsproc) pr.Kill();

Process calcProc = new Process();
calcProc.StartInfo = new ProcessStartInfo("calc.exe");
calcProc.Start();

vsproc = Process.GetProcessesByName("devenv");
foreach (Process pr in vsproc)
{
    pr.Kill();
}
