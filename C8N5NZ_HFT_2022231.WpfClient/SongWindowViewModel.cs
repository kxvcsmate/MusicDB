using C8N5NZ_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace C8N5NZ_HFT_2022231.WpfClient
{
    public class SongWindowViewModel : ObservableRecipient
    {
        public RestCollection<Song> Songs { get; set; }

        private Song selectedSong;
        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                if (value != null)
                {
                    selectedSong = new Song()
                    {
                        SongTitle = value.SongTitle,
                        Length = value.Length,
                        SongId = value.SongId,
                    };
                    OnPropertyChanged();
                    (UpdateSongCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteSongCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateSongCommand { get; set; }

        public ICommand DeleteSongCommand { get; set; }

        public ICommand UpdateSongCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public SongWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Songs = new RestCollection<Song>("http://localhost:53770/", "song", "hub");
                CreateSongCommand = new RelayCommand(() =>
                {
                    Songs.Add(new Song()
                    {
                        SongTitle = SelectedSong.SongTitle,
                        Length = SelectedSong.Length,
                    });
                });

                UpdateSongCommand = new RelayCommand(() =>
                {
                    Songs.Update(SelectedSong);
                });

                DeleteSongCommand = new RelayCommand(() =>
                {
                    Songs.Delete(SelectedSong.SongId);
                },
                () =>
                {
                    return SelectedSong != null;
                });
                SelectedSong = new Song();
            }
        }
    }
}
