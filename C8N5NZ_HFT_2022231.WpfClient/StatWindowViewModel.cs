using C8N5NZ_HFT_2022231.Models;
using C8N5NZ_HFT_2022231.Models.DTOs;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace C8N5NZ_HFT_2022231.WpfClient
{
    public class StatWindowViewModel : ObservableRecipient
    {
        public RestService Rest { get; set; }
        public ObservableCollection<AVGRating> Results { get; set; }
        public ObservableCollection<AlbumStat> Results2 { get; set; }
        public ObservableCollection<ArtistStat> Results3 { get; set; }
        public ObservableCollection<AlbumLengthStat> Results4 { get; set; }
        public ObservableCollection<Song> Results5 { get; set; }

        private IEnumerable<AVGRating> avgRatingByArtist;

        public IEnumerable<AVGRating> AVGRatingByArtist
        {
            get { return avgRatingByArtist; }
            set { avgRatingByArtist = value; }
        }

        private IEnumerable<AlbumStat> numberOfSongsByAlbum;

        public IEnumerable<AlbumStat> NumberOfSongsByAlbum
        {
            get { return numberOfSongsByAlbum; }
            set { numberOfSongsByAlbum = value; }
        }

        private IEnumerable<ArtistStat> numberOfAlbumsByArtist;

        public IEnumerable<ArtistStat> NumberOfAlbumsByArtist
        {
            get { return numberOfAlbumsByArtist; }
            set { numberOfAlbumsByArtist = value; }
        }

        private IEnumerable<AlbumLengthStat> albumByLength;

        public IEnumerable<AlbumLengthStat> AlbumByLength
        {
            get { return albumByLength; }
            set { albumByLength = value; }
        }

        private IEnumerable<Song> getSongsByLength;

        public IEnumerable<Song> GetSongsByLength
        {
            get { return getSongsByLength; }
            set { getSongsByLength = value; }
        }


        public ICommand AVGRatingByArtistCommand { get; set; }
        public ICommand NumberOfSongsByAlbumCommand { get; set; }
        public ICommand NumberOfAlbumsByArtistCommand { get; set; }
        public ICommand AlbumByLengthCommand { get; set; }
        public ICommand GetSongsByLengthCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public StatWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Results = new ObservableCollection<AVGRating>();
                Results2 = new ObservableCollection<AlbumStat>();
                Results3 = new ObservableCollection<ArtistStat>();
                Results4 = new ObservableCollection<AlbumLengthStat>();
                Results5 = new ObservableCollection<Song>();
                Rest = new RestService("http://localhost:53770/");

                AVGRatingByArtistCommand = new RelayCommand(() =>
                {
                    Results.Clear();
                    AVGRatingByArtist = Rest.Get<AVGRating>("stat/avgratingbyartist");
                    foreach (var item in AVGRatingByArtist)
                    {
                        Results.Add(new AVGRating()
                        {
                            ArtistName = item.ArtistName,
                            avgRating = item.avgRating
                        });
                    }
                });

                NumberOfSongsByAlbumCommand = new RelayCommand(() =>
                {
                    Results2.Clear();
                    NumberOfSongsByAlbum = Rest.Get<AlbumStat>("stat/numberofsongsbyalbum");
                    foreach (var item in NumberOfSongsByAlbum)
                    {
                        Results2.Add(new AlbumStat()
                        {
                            AlbumTitle = item.AlbumTitle,
                            SongCount = item.SongCount,
                        });
                    }
                });

                NumberOfAlbumsByArtistCommand = new RelayCommand(() =>
                {
                    Results3.Clear();
                    NumberOfAlbumsByArtist = Rest.Get<ArtistStat>("stat/numberofalbumsbyartist");
                    foreach (var item in NumberOfAlbumsByArtist)
                    {
                        Results3.Add(new ArtistStat()
                        {
                            ArtistName = item.ArtistName,
                            AlbumCount = item.AlbumCount,
                        });
                    }
                });

                AlbumByLengthCommand = new RelayCommand(() =>
                {
                    Results4.Clear();
                    AlbumByLength = Rest.Get<AlbumLengthStat>("stat/albumbylength");
                    foreach (var item in AlbumByLength)
                    {
                        Results4.Add(new AlbumLengthStat()
                        {
                            AlbumTitle = item.AlbumTitle,
                            Length = item.Length,
                        });
                    }
                });

                GetSongsByLengthCommand = new RelayCommand(() =>
                {
                    Results5.Clear();
                    GetSongsByLength = Rest.Get<Song>("stat/getsongsbylength");
                    foreach (var item in GetSongsByLength)
                    {
                        Results5.Add(new Song()
                        {
                            SongTitle = item.SongTitle,
                            Length = item.Length,
                        });
                    }
                });
            }
        }
    }
}
