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
 
    public partial class AnimeInfoWin : Window, INotifyPropertyChanged
    {
        private AnimeInfo selectedAnimeInfo;

        public AnimeInfo SelectedAnimeInfo
        {
            get => selectedAnimeInfo;
            set
            {
                selectedAnimeInfo = value;
                Signal();
            }
        }
        public ObservableCollection<AnimeInfo> AnimeInfos
        {
            get => Data.AnimeInfos;
        }
        public ObservableCollection<Seria> Serias
        {
            get => Data.Serias;
        }
        public ObservableCollection<Season> Seasons
        {
            get => Data.Seasons;
        }
        public AnimeInfoWin()
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

        private void AddAnimeInfo(object sender, RoutedEventArgs e)
        {
            AnimeInfos.Add(new AnimeInfo { Title = "Новая страна производства" });
        }

        private void DeleteAnimeInfo(object sender, RoutedEventArgs e)
        {
            if (SelectedAnimeInfo == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранную страну?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                AnimeInfos.Remove(SelectedAnimeInfo);
            }
        }

    }
}
