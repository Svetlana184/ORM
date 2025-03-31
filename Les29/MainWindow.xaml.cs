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

namespace Les29
{
    /// <summary>
    ///Модель событий wpf. команды wpf
    ///
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //uutton.Click += Button_Click1;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Hi from button");
        //}

        //private void Button_Click1(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Hi from button1");
        //}

        //private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    textt.Text += "Sender: " + sender.ToString() + "\n";
        //    textt.Text += "Sourse: " + e.Source.ToString() + "\n\n";
        //}

        //прикрепленное событие
        private void Radio_click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadio = (RadioButton)e.Source;
            MessageBox.Show(selectedRadio.Content.ToString());
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z ) return;
            e.Handled = true;
            //textBlock.Text += e.Key.ToString();
        }
    }
}