//СЛОВАРИ И МНОЖЕСТВА

/* коллекция, содержащая только отличающиеся элементы - множество (set)
 * два вида множеств:
 * hashset<T> - содержит неупорядоченный список различающихся элементов
 * sortedset<T> - элементы упорядочены
 * 
 * ISet<T> - предоставляет методы для создания, объединения нескольких множеств, пересечения множеств и 
 * определения, является ли одно множество надмножеством или подмножеством другого
 * 
 */

//int a = 79;
//Console.WriteLine(a.GetHashCode());
//string str1 = "tttttii";
//Console.WriteLine(str1.GetHashCode());
//string str2 = "tttttii";
//Console.WriteLine(str2.GetHashCode());
//str2 = "ttttti";
//Console.WriteLine(str2.GetHashCode());


////HASHSET
//HashSet<string> stringHash = new HashSet<string>();
//stringHash.Add("Sam");
//stringHash.Add("Tom");
//stringHash.Add("Bob");
//stringHash.Add("Tom");
//foreach (string k in stringHash) //Sam, Tom, Bob
//{
//    Console.Write(k + " ");
//}
//Console.WriteLine();

////SORTEDSET
//SortedSet<int> intSet = new SortedSet<int>();
//Random random = new Random();
//for (int i = 0;  i < 20; i++)
//{
//    intSet.Add(random.Next(10));
//}
//foreach (int i in intSet)
//{
//    Console.Write(i + " ");
//}
//Console.WriteLine();
////работает по принципу бинарного дерева

//List<int> list = new List<int>();
//for (int i = 0; i < 30; i++)
//{
//    list.Add(random.Next(20));
//}
//foreach (int i in list)
//{
//    Console.Write(i + " ");
//}
//Console.WriteLine();


//SortedSet<int> intSet2 = new SortedSet<int>(list);
//foreach (int i in intSet2)
//{
//    Console.Write(i + " ");
//}
//Console.WriteLine();


//HashSet<int> intSet3 = new HashSet<int>(list);
//foreach (int i in intSet3)
//{
//    Console.Write(i + " ");
//}
//Console.WriteLine();


//ОПЕРАЦИИ НАД МНОЖЕСТВАМИ

SortedSet<int> intSet4 = new SortedSet<int>();
intSet4.Add(4);
intSet4.Add(2);
intSet4.Add(3);
intSet4.Add(5);
intSet4.Add(8);

SortedSet<int> intSet5 = new SortedSet<int>();
intSet5.Add(9);
intSet5.Add(7);
intSet5.Add(1);
intSet5.Add(8);
intSet5.Add(4);

//симметрическая разность
//intSet4.SymmetricExceptWith(intSet5);
//foreach (var i in intSet4) Console.Write(i + " ");
//Console.WriteLine();


//объединение множеств
//intSet4.UnionWith(intSet5);
//foreach (var i in intSet4) Console.Write(i + " ");
//Console.WriteLine();

//пересечение множеств
//intSet4.IntersectWith(intSet5);
//foreach (var i in intSet4) Console.Write(i + " ");
//Console.WriteLine();

//разность множеств
intSet4.ExceptWith(intSet5);
foreach (var i in intSet4) Console.Write(i + " ");
Console.WriteLine();




