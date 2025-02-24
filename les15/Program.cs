//ОДНОСВЯЗНЫЙ СПИСОК

using les15;

les15.LinkedList<string> list = new les15.LinkedList<string>();

list.Add("Tom");
list.Add("Bob");
list.Add("Sam");
list.Add("Ann");
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
list.Remove("Ann");
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
Console.WriteLine(list.Count());
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();
Console.WriteLine(list.Contains("Sam")?"присутствует":"отсутствует");
list.Clear();
list.AppendFirst("Bill");
foreach (var item in list)
{
    Console.Write(item + " ");
}
Console.WriteLine();