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
   
    public partial class SeasonWin : Window, INotifyPropertyChanged
    {
        private Season selectedSeason;

        public Season SelectedSeason
        {
            get => selectedSeason;
            set
            {
                selectedSeason = value;
                Signal();
            }
        }

        public ObservableCollection<Season> Season
        {
            get => Data.Seasons;
        }
        public SeasonWin()
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

        private void AddSeason(object sender, RoutedEventArgs e)
        {
            Season.Add(new Season { SeasonAnime = "Коллаборация" });
        }

        private void DeleteSeason(object sender, RoutedEventArgs e)
        {
            if (SelectedSeason == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранную коллаборацию?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Season.Remove(SelectedSeason);
            }
        }
    }
}
