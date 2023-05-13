using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace C8N5NZ_HFT_2022231.WpfClient
{
    public class MenuViewModel
    {
        public ICommand ArtistsCommand { get; set; }
        public ICommand AlbumsCommand { get; set; }
        public ICommand SongsCommand { get; set; }
        public ICommand StatisticsCommand { get; set; }

        public MenuViewModel()
        {
            ArtistsCommand = new RelayCommand(() =>
            {
                ArtistWindow artistWindow = new ArtistWindow();
                artistWindow.ShowDialog();
            });

            AlbumsCommand = new RelayCommand(() =>
            {
                AlbumWindow albumWindow = new AlbumWindow();
                albumWindow.ShowDialog();
            });

            SongsCommand = new RelayCommand(() =>
            {
                SongWindow songWindow = new SongWindow();
                songWindow.ShowDialog();
            });

            StatisticsCommand = new RelayCommand(() =>
            {
                StatWindow statWindow = new StatWindow();
                statWindow.ShowDialog();
            });

        }
    }
}
