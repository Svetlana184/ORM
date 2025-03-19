//АЛГОРИТМЫ СИНХРОНИЗАЦИИ


//критическая секция
//int x = 0;
//object locker = new();
//for (int i = 0; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток: {i}";
//    myThread.Start();
//}
//void Print()
//{
//    lock (locker)
//    {
//        x = 1;
//        for (int i = 0; i < 6; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//}


//Монитор
//int x = 0;
//object locker = new();
//for (int i = 0; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток: {i}";
//    myThread.Start();
//}
//void Print()
//{
//    bool acquiredLock = false;
//    try {
//        Monitor.Enter(locker, ref acquiredLock);
//        x = 1;
//        for (int i = 0; i < 6; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//    finally
//    {
//        if(acquiredLock) Monitor.Exit(locker);
//    }     
//}

//system.Threading.Lock
//класс Lock и синхронизация
int x = 0;
Lock lockObj = new();
for (int i = 0; i < 6; i++)
{
    Thread myThread = new(Print);
    myThread.Name = $"Поток: {i}";
    myThread.Start();
}
void Print()
{
    //lock (lockObj)
    //{
    //    x = 1;
    //    for (int i = 0; i < 6; i++)
    //    {
    //        Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
    //        x++;
    //        Thread.Sleep(100);
    //    }
    //}
    //if (lockObj.TryEnter())
    //{
    //    try
    //    {
    //        x = 1;
    //        for (int i = 0; i < 6; i++)
    //        {
    //            Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
    //            x++;
    //            Thread.Sleep(100);
    //        }
    //    }
    //    finally
    //    {
    //        lockObj.Exit();
    //    }
    //}
    using (lockObj.EnterScope())
    {
        x = 1;
        for (int i = 0; i < 6; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
            x++;
            Thread.Sleep(100);
        }
    }


}