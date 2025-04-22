using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using lab12_13.Model;
using Xceed.Wpf.Toolkit;

namespace lab12_13.View
{
    /// <summary>
    /// Логика взаимодействия для MotoView.xaml
    /// </summary>
    public partial class MotoView : Window
    {
        public ClassMoto Moto { get; set; }
        public MotoView()
        {
            InitializeComponent();
            DataContext = Moto;
            int x = 0;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}
