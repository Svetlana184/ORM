// NetworkStream

using System.Net.Sockets;
using System.Text;

using var mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
var server = "www.google.com";
mySocket.Connect(server, 80);
using var stream = new NetworkStream(mySocket);
Console.WriteLine(stream.Socket.LocalEndPoint);
Console.WriteLine(stream.Socket.RemoteEndPoint);

var message = $"GET / HTTP/1.1\r\nHost: {server}\r\nConnection: Close\r\n\r\n";
var data = Encoding.UTF8 .GetBytes(message);
await stream.WriteAsync(data);
Console.WriteLine("send data to" + server);

var responceData = new byte[512];
var bytes = await stream.ReadAsync(responceData);
string responce = Encoding.UTF8.GetString(responceData, 0, bytes);
Console.WriteLine(responce);