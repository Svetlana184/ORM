using System.Net.Sockets;
using System.Text;

while (true)
{
    using TcpClient tcpclient = new TcpClient();

    await tcpclient.ConnectAsync("192.168.110.60", 8888);
    Console.WriteLine("Введите слово для перевода:");
    string word = Console.ReadLine()!;
    var stream = tcpclient.GetStream();
    int bytesRead = 10;
    byte[] data = Encoding.UTF8.GetBytes(word + "\n");
    await stream.WriteAsync(data);
    var response = new List<byte>();
    while ((bytesRead = stream.ReadByte()) != '\n')
    {
        response.Add((byte)bytesRead);
    }
    var translation = Encoding.UTF8.GetString(response.ToArray());
    Console.WriteLine($"слово {word}:{translation}");
    response.Clear();
    await Task.Delay(2000);
    await stream.WriteAsync(Encoding.UTF8.GetBytes("END\n"));
}
