using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using lab12_13.Infrastructure;
using lab12_13.Model;
using lab12_13.View;
using Microsoft.Win32;
using lab12_13.Converter;
using System.Runtime.CompilerServices;
using System.ComponentModel;
namespace lab12_13.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ClassMoto> Motos { get; set; }
        private ClassMoto? selectedMoto;
        public ClassMoto? SelectedMoto
        {
            get { return selectedMoto; }
            set
            {
                selectedMoto = value;
                OnPropertyChanged(nameof(SelectedMoto));
            }
        }
        private int records;

        public int Records 
        { 
            get { return records; }
            set { 
                records = value; 
                OnPropertyChanged(nameof(Records));
            }
        }


        public MainViewModel()
        {
            Motos = new ObservableCollection<ClassMoto>();
        }
        private RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand((o) =>
                  {
                      MotoView view = new MotoView(new ClassMoto());
                      if (view.ShowDialog() == true)
                      {
                          ClassMoto moto = view.Moto;
                          Motos.Add(moto);
                      }
                      Records = Motos.Count;
                  }));
            }
        }
        private RelayCommand? saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(async (o) =>
                  {
                     SaveFileDialog sfd = new SaveFileDialog();
                      sfd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                      if(sfd.ShowDialog() == true)
                      {
                          using (StreamWriter writer = new StreamWriter(sfd.FileName, false))
                          {
                              foreach(ClassMoto moto in Motos)
                              {
                                  await writer.WriteLineAsync(moto.ToString());
                                 
                              }
                          }
                      }
                  }));
            }
        }
        private RelayCommand? openCommand;
        public RelayCommand OpenCommand => openCommand ??
                  (openCommand = new RelayCommand(async (o) =>
                  {
                      OpenFileDialog ofd = new OpenFileDialog();
                      ofd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
                      if (ofd.ShowDialog() == true)
                      {
                          using (StreamReader reader = new StreamReader(ofd.FileName))
                          {
                              string? line;
                              while ((line = reader.ReadLine()) != null)
                              {
                                  string[] mas = line.Split(" ");
                                  ClassMoto moto = new ClassMoto
                                 (mas[0],
                                   (Color)ColorConverter.ConvertFromString(mas[1]),
                                   mas[2],
                                   mas[3],
                                 int.Parse(mas[4]),
                                 int.Parse(mas[5]),
                                 decimal.Parse(mas[6]));
                                  Motos.Add(moto);
                              }
                              Records = Motos.Count;
                          }
                      }
                  }));
        private RelayCommand? clearCommand;
        public RelayCommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new RelayCommand((o) =>
                {
                    Motos.Clear();
                    Records = Motos.Count;
                }));
            }
        }
        private RelayCommand? doubleCommand;
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??
                  (doubleCommand = new RelayCommand((o) =>
                  {
                      MotoView view = new MotoView(SelectedMoto!);
                      if (view.ShowDialog() == true)
                      {
                          ClassMoto moto = view.Moto;
                          Motos.Add(moto);
                      }
                      Records = Motos.Count;
                  }));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
