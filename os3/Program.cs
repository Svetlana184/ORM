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
//int x = 0;
//Lock lockObj = new();
//for (int i = 0; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток: {i}";
//    myThread.Start();
//}
//void Print()
//{
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
//    using (lockObj.EnterScope())
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


//СОБЫТИЯ (AutoResetEvent)
//int x = 0;
//AutoResetEvent waitHandler = new AutoResetEvent(true);
//for (int i = 0; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток: {i}";
//    myThread.Start();
//}
//void Print()
//{
//    waitHandler.WaitOne();
//        x = 1;
//        for (int i = 0; i < 6; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    waitHandler.Set();
//}


//Мьютекс
//int x = 0;
//Mutex mutexObj = new();
//for (int i = 0; i < 6; i++)
//{
//    Thread myThread = new(Print);
//    myThread.Name = $"Поток: {i}";
//    myThread.Start();
//}
//void Print()
//{
//    mutexObj.WaitOne();
//    x = 1;
//    for (int i = 0; i < 6; i++)
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name} : {x}");
//        x++;
//        Thread.Sleep(100);
//    }
//    mutexObj.ReleaseMutex();
//}


//Семафоры
//задача про читателей

class Reader
{
    static Semaphore sem = new Semaphore(3, 3);
    Thread myThread;
    int count = 3;

    public Reader(int i)
    {
        myThread = new Thread(Read);
        myThread.Name = $"Reader {i}";
        myThread.Start();
    }
    public void Read()
    {
        while (count > 0)
        {
            sem.WaitOne();
            Console.WriteLine($"{Thread.CurrentThread.Name} goes");
            Console.WriteLine($"{Thread.CurrentThread.Name} reads");
            Thread.Sleep( 1000 );
            Console.WriteLine($"{Thread.CurrentThread.Name} goes away");
            sem.Release();
            count--;
            Thread.Sleep( 1000 );

        }
    }
}