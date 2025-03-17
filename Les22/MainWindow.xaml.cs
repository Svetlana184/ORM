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

namespace Les22
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string opertaion = (sender as Button).Content.ToString();
            double var1 = double.Parse(First.Text);
            double var2 = double.Parse(Second.Text);
            double result = 0;
            switch (opertaion)
            {
                case "+":
                    result = var1 + var2;
                    break;
                case "-":
                    result = var1 - var2;
                    break;
                case "*":
                    result = var1 * var2;
                    break;
                case ":":
                    result = var1 / var2;
                    break;
                default: 
                    break;
            }
            Result.Content = $"{var1} {opertaion} {var2} = {result:F2}";

        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    string text = textBoxMessage.Text;
        //    labelMessage.Content = text;
        //}
    }
}