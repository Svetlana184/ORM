using System.Net;
using System.Net.Sockets;
using System.Text;

var tcpListener = new TcpListener(IPAddress.Any, 8888);
try
{
    tcpListener.Start();
    Console.WriteLine("Сервер запущен. Ожидание подключений ...");
    while (true)
    {
        using var tcpClient = await tcpListener.AcceptTcpClientAsync();
        //Console.WriteLine($"Входящее подключение: {tcpClient.Client.RemoteEndPoint}");
        var stream = tcpClient.GetStream();
        byte[] data = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());
        await stream.WriteAsync(data);
        Console.WriteLine($"клиенту {tcpClient.Client.RemoteEndPoint} отправлены данные ");
    }
}
finally
{
    tcpListener.Stop();
}