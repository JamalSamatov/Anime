using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfApp10
{
    
    static class Data
    {
        public static ObservableCollection<Seria> Serias = new ObservableCollection<Seria>();
        public static ObservableCollection<Osnovaanime> Osnovaanimes = new ObservableCollection<Osnovaanime>();
        public static ObservableCollection<AnimeInfo> AnimeInfos = new ObservableCollection<AnimeInfo>();
        public static ObservableCollection<Season> Seasons = new ObservableCollection<Season>();
    }
}
