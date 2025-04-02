using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Les33.Model;

namespace Les33.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private Phone selectedPhone;
        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set { selectedPhone = value; }
        }
        public MainViewModel()
        {

            Phones = new ObservableCollection<Phone>
            {
                new Phone { Title = "Samsung Galaxy", Price = 30000, Company = "Samsung" },
                new Phone { Title = "NX400", Price = 30000, Company = "Xiaomi" },
                new Phone { Title = "IPhone 15", Price = 150000, Company = "Apple" }
            };
                

                public ObservableCollection<Phone> Phones
                {
                    get; set;
                }


                public event PropertyChangedEventHandler? PropertyChanged;

                public void OnPropertyChanged([CallerMemberName] string prop = "")
                {
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(prop));
                    }
                }
        }
        
    }
}
