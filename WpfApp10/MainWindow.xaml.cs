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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp10
{
    
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Osnovaanime selectedOsnovaanime;

        public ObservableCollection<Osnovaanime> Osnovaanimes
        {
            get => Data.Osnovaanimes;
        }
        public ObservableCollection<AnimeInfo> AnimeInfos
        { 
            get => Data.AnimeInfos;
        }

        public Osnovaanime SelectedOsnovaanime
        {
            get => selectedOsnovaanime;
            set
            {
                selectedOsnovaanime = value;
                Signal();
            }
        }

        public MainWindow()
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

        private void AddOsnovaanime(object sender, RoutedEventArgs e)
        {
            Osnovaanimes.Add(new Osnovaanime
            {
                LastName = "Новый товар",
                Vykhod = DateTime.Today
            });
        }

        private void DeleteOsnovaanime(object sender, RoutedEventArgs e)
        {
            if (SelectedOsnovaanime == null)
                return;
            if (MessageBox.Show("Действительно удалить выбранный товар?",
                "Предупреждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Osnovaanimes.Remove(SelectedOsnovaanime);
                SelectedOsnovaanime = null;
            }
        }

        private void OpenSerias(object sender, RoutedEventArgs e)
        {
            SeriaWin win = new SeriaWin();
            win.ShowDialog();
        }

        private void OpenAnimeInfo(object sender, RoutedEventArgs e)
        {
            AnimeInfoWin win = new AnimeInfoWin();
            win.ShowDialog();
        }

        private void OpenSeasons(object sender, RoutedEventArgs e)
        {
            SeasonWin win = new SeasonWin();
            win.ShowDialog();
        }

        private void OpenAnimeInfos(object sender, RoutedEventArgs e)
        {
            AnimeInfoWin win = new AnimeInfoWin();
            win.ShowDialog();
        }
    }
}
