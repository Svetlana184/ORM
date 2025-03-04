using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;

//IP адресация
IPAddress localip = new IPAddress(new byte[] { 127, 0, 0, 1 });
Console.WriteLine(localip);
IPAddress someIp = new IPAddress(0x0100007F);
Console.WriteLine(someIp);
IPAddress ip = IPAddress.Parse("127.0.0.1");
IPAddress anyIp = IPAddress.Any; //любой
Console.WriteLine(anyIp);
IPAddress loopIP = IPAddress.Loopback; //возвращает объект IPAdress для адреса 127.0.0.1
Console.WriteLine(loopIP);
IPAddress broadcastIP = IPAddress.Broadcast;  //возвращает объект IPAdress для адреса 255.255.255.255
Console.WriteLine(broadcastIP);
Console.WriteLine();

Console.WriteLine(localip.AddressFamily);
Console.WriteLine();

IPEndPoint endPoint1 = new IPEndPoint(ip, 8080); //конечная точка
IPEndPoint endPoint2 = IPEndPoint.Parse("127.0.0.1:8080");

Console.WriteLine(endPoint2.Address);
Console.WriteLine(endPoint2.Port);
Console.WriteLine();


//Uri
string uri = "https://mail.ru";
Uri myUri = new(uri);
Console.WriteLine(myUri.AbsolutePath);
Console.WriteLine(myUri.AbsoluteUri);
Console.WriteLine(myUri.Fragment);
Console.WriteLine(myUri.Host);
Console.WriteLine(myUri.IsAbsoluteUri);
Console.WriteLine(myUri.IsDefaultPort);
Console.WriteLine(myUri.IsFile);
Console.WriteLine(myUri.IsLoopback);
Console.WriteLine(myUri.OriginalString);
Console.WriteLine(myUri.PathAndQuery);
Console.WriteLine(myUri.Port);
Console.WriteLine(myUri.Query);
Console.WriteLine(myUri.Scheme);
Console.WriteLine(string.Join(",",myUri.Segments));
Console.WriteLine(myUri.UserInfo);

//NetworkInterface
var adapters = NetworkInterface.GetAllNetworkInterfaces();
Console.WriteLine("всего:" + " " + adapters.Length);
foreach (NetworkInterface adapter in adapters)
{
    Console.WriteLine();
    Console.WriteLine(adapter.Id);
    Console.WriteLine(adapter.Name);
    Console.WriteLine(adapter.Description);
    Console.WriteLine(adapter.NetworkInterfaceType);
    Console.WriteLine(adapter.GetPhysicalAddress());
    Console.WriteLine(adapter.OperationalStatus);
    Console.WriteLine(adapter.Speed);
    IPInterfaceStatistics stats = adapter.GetIPStatistics();
    Console.WriteLine(stats.BytesReceived);
    Console.WriteLine(stats.BytesSent);
}
Console.Clear();

