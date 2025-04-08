// чтение и запись текстовых файлов. Классы StreamReader и StreamWriter

/* 
 * StreamWriter - класс, реализующий TextWriter для записи символов в поток в опр. кодировке
 * TextWriter - абстрактный класс
 * 
 */

Console.WriteLine("Введите название файла:");
string path = Console.ReadLine()!;
//Console.WriteLine("Введите текст:");
//string text  = Console.ReadLine()!;
//using(StreamWriter writer = new StreamWriter(path, false))
//{
//    await writer.WriteLineAsync(text);
//}

//using (StreamWriter writer = new StreamWriter(path, true))
//{
//    await writer.WriteLineAsync("Additional");
//    await writer.WriteLineAsync("123");
//}

//чтение файла

//1
//using(StreamReader sr = new StreamReader(path))
//{
//    Console.WriteLine("первый способ:");
//    string text = await sr.ReadToEndAsync();
//    Console.WriteLine(text);
//}

//2 построчно
using (StreamReader sr = new StreamReader(path))
{
    string? line;
    while ((line = sr.ReadLine()) != null) Console.WriteLine(line);
}