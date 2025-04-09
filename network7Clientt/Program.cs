using System.Net.Sockets;

using TcpClient tcpclient = new TcpClient();
Console.WriteLine("started");
await tcpclient.ConnectAsync("127.0.0.1", 8888);
if (tcpclient.Connected) Console.WriteLine($"подключение установлено {tcpclient.Client.RemoteEndPoint}");
else Console.WriteLine("не удалось подключиться");