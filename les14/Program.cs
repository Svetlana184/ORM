//СТЕКИ И ОЧЕРЕДИ
/*
 * 
 * 
 * 
 */

//Queue<string> people1 = new Queue<string>();
//Queue<string> people2 = new Queue<string>(16);
//var employees = new List<string> {"Tom", "Sam", "Bob" };
//Queue<string> people3 = new Queue<string>(employees);
//foreach (var p in people3)
//{
//    Console.Write(p + " ");
//}
//Console.WriteLine();
//Console.WriteLine(people3.Count());
//people1.Enqueue("Melony");
//people1.Enqueue("Susan");
//people1.Enqueue("Eeeeeeeeee");
//Console.WriteLine(people1.Peek());
//Console.WriteLine(people1.Dequeue());
//foreach (var p in people1)
//{
//    Console.Write(p + " ");
//}
//Console.WriteLine();
//if (people1.Count() > 0)
//{
//    var success = people1.TryDequeue(out var p1);
//    if (success) Console.WriteLine(p1);
//    success = people1.TryDequeue(out var p2);
//    if (success) Console.WriteLine(p2);
//    success = people1.TryDequeue(out var p3);
//    if (success) Console.WriteLine(p3);
//    success = people1.TryPeek(out var p4);
//    if (success) Console.WriteLine(p3);
//}

Stack<string> people1 = new Stack<string>();
Stack<string> people2 = new Stack<string>(16);
var employees = new List<string> {"Tom", "Sam", "Bob" };
Stack<string> people3 = new Stack<string>(employees);
foreach (var p in people3) Console.WriteLine(p + " ");
Console.WriteLine();
Console.WriteLine(people3.Count());
Console.WriteLine(people3.Contains("Sam"));
people1.Push("EE");
people1.Push("WW");
people1.Push("XX");
people1.Push("LL");

if  (people1.Count() > 0)
{
    var success = people1.TryPop(out var p1);
    if (success) Console.WriteLine(p1);
    success = people1.TryPeek(out var p2);
    if (success) Console.WriteLine(p2);
    success = people1.TryPop(out var p3);
    if (success) Console.WriteLine(p3);
    success = people1.TryPop(out var p4);
    if (success) Console.WriteLine(p4);
    success = people1.TryPop(out var p5);
    if (success) Console.WriteLine(p5);
}