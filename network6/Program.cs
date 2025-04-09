using System.Net.Sockets;
using System.Text;

//TCP Client
using TcpClient tcpClient = new TcpClient();
try
{
    await tcpClient.ConnectAsync("www.google.com", 80);
    Console.WriteLine("соединение выполнено");
    Console.WriteLine(tcpClient.Connected);
    NetworkStream stream = tcpClient.GetStream();
    var requestMessage = $"GET / HTTP/1.1\r\nHost: www.google.com\r\nConnection: Close\r\n\r\n";
    var requestData = Encoding.UTF8.GetBytes(requestMessage);
    await stream.WriteAsync(requestData);

    var responceData = new byte[512];
    var responce = new StringBuilder();
    int bytes;
    do
    {
        bytes = await stream.ReadAsync(responceData);
        responce.Append(Encoding.UTF8.GetString(responceData, 0, bytes));
    }
    //while(bytes > 0);
    //while (tcpClient.Available > 0); 
    while (stream.DataAvailable);
    Console.WriteLine(responce);
}
catch(SocketException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    tcpClient.Close();
    Console.WriteLine(tcpClient.Connected);
}