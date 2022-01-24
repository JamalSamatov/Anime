using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp10
{
   
    public partial class SeriaWin : Window, INotifyPropertyChanged
    {
        private Seria selectedSeria;

        public Seria SelectedSeria
        {
            get => selectedSeria;
            set
            {
                selectedSeria = value;
                Signal();
            }
        }

        public ObservableCollection<Seria> Serias
        {
            get => Data.Serias;
        }
        public SeriaWin()
        {
            InitializeComponent();
            DataContext = this;
        }

        void Signal([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this,
                      new PropertyChangedEventArgs(name));
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void AddSeria(object sender, RoutedEventArgs e)
        {
            Serias.Add(new Seria { Title = "Новый бренд" });
        }

        private void DeleteSeria(object sender, RoutedEventArgs e)
        {
            if (SelectedSeria == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранный бренд?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Serias.Remove(SelectedSeria);
            }
        }
    }
}
