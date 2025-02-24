//СЛОВАРЬ хранит объекты, который представляют пару ключ-значение 
/*Dictionary<K, V> типизируется двумя типами: параметр K - тип ключей, V предоставляет тип значений
 * Ключи не могут повторяться!!!!!
 * 
 */

Dictionary<int, string> people = new Dictionary<int, string>();


//methods
people.Add(1, "Bob");
people.Add(2, "Tom");
people.Add(3, "Sam");
//people.Add(1, "Jerry");
people.Add(4, "Sam");

foreach (var person in people)
{
    Console.WriteLine($"{person.Key} : {person.Value}");
}
Console.WriteLine();
people.Remove(2);
foreach (var person in people)
{
    Console.WriteLine($"{person.Key} : {person.Value}");
}
Console.WriteLine();

//ПОИСК
Console.WriteLine(people.ContainsKey(1));
Console.WriteLine(people.ContainsValue("Bob"));
Console.WriteLine(people[1]);