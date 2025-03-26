using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace network4Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<string> Send(string strUrl, int p)
        {
            int port = p;
            string url = strUrl;
            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                await socket.ConnectAsync(url, port);
                var message = $"GET / HTTP/1.1\r\nHost: {url}\r\n\r\nConnection: close\r\n\r\n";
                var messageBytes = Encoding.UTF8.GetBytes(message);
                await socket.SendAsync(messageBytes);
                socket.Shutdown(SocketShutdown.Send);
                var responceBytes=new byte[512];
                var builder = new StringBuilder();
                int bytes;
                do
                {
                    bytes = await socket.ReceiveAsync(responceBytes);
                    string responsePart = Encoding.UTF8.GetString(responceBytes,0,bytes);
                    builder.Append(responsePart);
                }
                while (bytes > 0);
                return builder.ToString();
            }
            catch(SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "";
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = TextBoxAddress.Text;
            int port = int.Parse(TextBoxPort.Text);
            Dispatcher.Invoke(() =>
            {
                Task<string> task = Task.Run(async () => await Send(url, port));
                TextBlockResponse.Text = task.Result;
            });
            
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}