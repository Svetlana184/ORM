using System.Net;
using System.Net.Sockets;

var tcpListener = new TcpListener(IPAddress.Any, 8888);
try
{
    tcpListener.Start();
    Console.WriteLine("Сервер запущен. Ожидание подключений ...");
    while (true)
    {
        using var tcpClient = await tcpListener.AcceptTcpClientAsync();
        Console.WriteLine($"Входящее подключение: {tcpClient.Client.RemoteEndPoint}");
    }
}
finally
{
    tcpListener.Stop();
}