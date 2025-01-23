// ОБОБЩЁННЫЕ ТИПЫ ДАННЫХ (универсальные шаблоны)

/*generics - классы, структуры, интерфейсы и методы, в которых некоторые типы сами являются параметрами
 * универсальные шаблоны позволяют точно настроить метод, класс. структуру или интерфейс в соответствии с типом обрабатываемых данных
 * 
 */


//Console.WriteLine("введите х");
//var x = Console.ReadLine();
//Console.WriteLine("введите y");
//var y = Console.ReadLine();
//Console.WriteLine($"x = {x}, y = {y}");
//Swap(ref x, ref y);
//Console.WriteLine($"x = {x}, y = {y}");

//void Swap (ref int a, ref int b)
//{
//    int temp = a; 
//    a = b; 
//    b = temp;
//}

//void SwapDouble(ref double a, ref double b)
//{
//    double temp = a;
//    a = b;
//    b = temp;
//}

//void Swap<T>(ref T a, ref T b)
//{
//    T temp = a;
//    a = b;
//    b = temp;
//}

//ОГРАНИЧЕНИЯ ОБОБЩЕНИЙ


//SendMessage(new EmailMessage("hello from email"));
//SendMessage(new TelegramMessage("hello from telegram"));
//SendMessage(new Haker("хех")); - ошибка
Messanger<Message> email = new Messanger<Message>();
email.SendMessage(new Message("hello from email"));
Messanger<Message> telegram = new Messanger<Message>();
telegram.SendMessage(new Message("hello from email"));
//void SendMessage<T>(T message)  where T : Message
//{
//    Console.WriteLine($"Отправляется сообщение: {message.Text}");
//}

class Message
{
    public string Text { get; set; }
    public Message(string text)
    {
        Text = text;
    }

}
class Messanger<T> where T : Message
{
    public void SendMessage(T message)
    {
        Console.WriteLine($"Отправляется сообщение: {message.Text}");
    }
}
class EmailMessage : Message
{
    public EmailMessage(string text) : base(text) { }
}

class TelegramMessage : Message
{
    public TelegramMessage(string text) : base(text) { }
}

class Haker
{
    public string Text { get; set; }
    public Haker(string text)
    {
        Text = text;
    }
    public void Destroy() { }
}