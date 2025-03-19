using System.Net;
using System.Net.Sockets;

IPEndPoint ipPoint = new IPEndPoint(IPAddress.Loopback, 8888);
using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

socket.Bind(ipPoint);

Console.WriteLine(socket.LocalEndPoint);

socket.Listen(1000); //1000 - количество входящих подключений, которые можно уместить в очередь
Console.WriteLine("Сервер подключен");

using Socket client = await socket.AcceptAsync();
Console.WriteLine("адрес клиента:" + client.RemoteEndPoint);
