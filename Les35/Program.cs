// работа с файлами
using System.Text;
//абсолютный путь
//string path1 = @"D:\MyFolder\file1.txt";

//относительный путь
//string path2 = @"MyDir/content.txt";

//FileInfo fileInfo = new FileInfo(path2);
//if (fileInfo.Exists)
//{
//    Console.WriteLine(fileInfo.FullName);
//    Console.WriteLine(fileInfo.Name);
//    Console.WriteLine(fileInfo.Length);
//    Console.WriteLine(fileInfo.CreationTime);
//    Console.WriteLine(fileInfo.CreationTimeUtc);
//    Console.WriteLine(fileInfo.Directory);
//    Console.WriteLine(fileInfo.DirectoryName);
//    Console.WriteLine(fileInfo.Extension);
//    Console.WriteLine(fileInfo.IsReadOnly);
//    Console.WriteLine(fileInfo.LastAccessTime);
//}

//создание файла
//FileInfo f1 = new FileInfo(@"MyDir/content.txt");
//if (!f1.Exists)
//{
//    f1.Create();
//}
//else
//{
//    f1.Delete();
//    //File.Delete(@"MyDir/content.txt");
//}
//перемещение файла
//string newPath = @"myFile.txt";
//f1.MoveTo(newPath, true);
//File.Move(path2, newPath);

//копирование файла
//string copyPath = @"MyDir/content.txt";
//FileInfo f2 = new FileInfo(@"myFile.txt");
//if (f2.Exists)
//{
//    f2.CopyTo(newPath, true);
//    //File.Copy(@"myFile.txt", copyPath);
//}

//запись в файл
//Console.WriteLine("введите текст");
//string text = Console.ReadLine()!;
//using (FileStream fileStream = new FileStream(@"myFile.txt", FileMode.OpenOrCreate))
//{
//    byte[] buffer = Encoding.Default.GetBytes(text);
//    await fileStream.WriteAsync(buffer, 0, buffer.Length);
//}

//чтение из файла
//using (FileStream fileStream = File.OpenRead(@"myFile.txt"))
//{
//    byte[] buffer = new byte[fileStream.Length];
//    await fileStream.ReadAsync(buffer, 0, buffer.Length);
//    string text = Encoding.Default.GetString(buffer);
//    Console.WriteLine(text);
//}

//произвольный доступ к файлам


using (FileStream fileStream = new FileStream(@"myFile.txt", FileMode.OpenOrCreate))
{
    string replaceText = "house";
    fileStream.Seek(-5, SeekOrigin.End);
    byte[] input = Encoding.Default.GetBytes(replaceText);
    await fileStream.WriteAsync(input, 0, input.Length);

    fileStream.Seek(0, SeekOrigin.Begin);
    byte[] output = new byte[fileStream.Length];

}



