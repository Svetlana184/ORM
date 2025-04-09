using System.Net.Sockets;
using System.Text;

using TcpClient tcpclient = new TcpClient();
Console.WriteLine("started");
await tcpclient.ConnectAsync("192.168.110.60", 8888);
//if (tcpclient.Connected) Console.WriteLine($"подключение установлено {tcpclient.Client.RemoteEndPoint}");
//else Console.WriteLine("не удалось подключиться");

byte[] data = new byte[512];
var stream = tcpclient.GetStream();
int bytes = await stream.ReadAsync(data);
string time = Encoding.UTF8.GetString(data, 0, bytes);
Console.WriteLine("текущее время " + time);