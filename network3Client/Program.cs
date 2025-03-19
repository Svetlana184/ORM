
using System.Net.Sockets;


using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
try
{
    await socket.ConnectAsync("192.168.113.2", 8888);
    Console.WriteLine($"подключение к {socket.RemoteEndPoint} установлено");
}
catch
{
    Console.WriteLine($"подключение к {socket.RemoteEndPoint} не установлено(((((");
}