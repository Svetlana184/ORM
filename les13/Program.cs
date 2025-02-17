/*КОЛЛЕКЦИИ:
 * списки (list)
 * множества (set) - без повторений
 * словари (dictionary) - ключ-значение
 */


//ArrayList
//не использовать(((((((
//ArrayList al1 = new ArrayList();
//al1.Add(56);
//al1.Add(3.14);
//al1.Add("tttttt");
//al1.Add(true);
//al1.Add('h');
//Console.WriteLine(al1.Count);
//Console.WriteLine(al1[2]);
//Console.WriteLine(al1.Capacity);


//List
//List<string> people1 = new List<string>() {"ttttt", "eeeee", "lll"};
//List<string> people2 = new List<string>(people1);
//List<string> people3 = ["Sasha", "Masha", "Eeeee"];
//List<string> people4 = [];
//List<string> people5 = new List<string>(16); //начальная емкость
//people1.Add("Sam");
//people1.AddRange(new List<string> { "SSS", "wwww"});
//foreach (string person in people1)
//{
//    Console.Write(person + " ");
//}
//Console.WriteLine();
//people1.Insert(2, "Tom"); //вставка
//people1.InsertRange(4, new[] { "kkkkkk", "fff" });
//foreach (string person in people1)
//{
//    Console.Write(person + " ");
//}
//Console.WriteLine();
//people1.RemoveAt(5); //удаление по индексу
//people1.Remove("Tom"); //удаление по значению
//people1.RemoveAll(p => p.Length == 6);
//people1.RemoveRange(2, 4);
//foreach (string person in people1)
//{
//    Console.Write(person + " ");
//}
//Console.WriteLine();
//Console.WriteLine();
//var isEee = people1.Contains("eeeee"); //есть ли элемент в массиве
//Console.WriteLine(isEee);
//var isTom = people1.Contains("Tom");
//Console.WriteLine(isTom);
//Console.WriteLine(people1.Exists(p => p.Length == 5));
//Console.WriteLine(people1.Find(p => p.Length == 5));
//List<string> peopleWithLengths = people1.FindAll(p => p.Length == 5);
//foreach (string person in peopleWithLengths)
//{
//    Console.Write(person + " ");
//}
//Console.WriteLine();
//List<string> range = people1.GetRange(0, 1);
//string[] masPeople = new string[2];
//people1.CopyTo(0, masPeople, 0, 2);
//people1.Reverse();
//foreach (string person in people1)
//{
//    Console.Write(person + " ");
//}
//Console.WriteLine();

using System.Collections;


//LinkedList - двусвязный список
var list = new List<string>() { "Sam", "Tom", "Boba" };
LinkedList<string> people1 = new LinkedList<string>();
//Value - значение
//Next - ссылка на следующий элемент
//Previous - ссылка на предыдущий элемент
LinkedList<string> people2 = new LinkedList<string>(list);
Console.WriteLine(people2.Count);
Console.WriteLine(people2.First?.Value);
Console.WriteLine(people2.Last?.Value);
var currentNode = people2.First;
while (currentNode != null)
{
    Console.Write(currentNode.Value + " ");
    currentNode = currentNode.Next;
}
Console.WriteLine();
currentNode = people2.Last;
while (currentNode != null)
{
    Console.Write(currentNode.Value + " ");
    currentNode = currentNode.Previous;
}
Console.WriteLine();

people2.AddAfter(people2.Last!, "Jerry");
people2.AddBefore(people2.First!, "Duck");
people2.AddFirst("Ann");
people2.AddLast("Samon");

currentNode = people2.First;
while (currentNode != null)
{
    Console.Write(currentNode.Value + " ");
    currentNode = currentNode.Next;
}
Console.WriteLine();
people2.RemoveFirst();
people2.RemoveLast();
currentNode = people2.First;
while (currentNode != null)
{
    Console.Write(currentNode.Value + " ");
    currentNode = currentNode.Next;
}
Console.WriteLine();