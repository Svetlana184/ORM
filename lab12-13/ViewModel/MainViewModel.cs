using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab12_13.Infrastructure;
using lab12_13.Model;
using lab12_13.View;

namespace lab12_13.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<ClassMoto> Motos { get; set; }

        public MainViewModel()
        {
            Motos = new ObservableCollection<ClassMoto>();
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return AddCommand ??
                    (addCommand = new RelayCommand((o) =>
                    {
                        MotoView view = new MotoView(new ClassMoto());
                        if(view.ShowDialog() == true)
                        {

                        }
                    }));
            }
        }
    }
}
