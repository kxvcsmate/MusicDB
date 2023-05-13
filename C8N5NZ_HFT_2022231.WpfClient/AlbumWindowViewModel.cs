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
    public class AlbumWindowViewModel : ObservableRecipient
    {
        public RestCollection<Album> Albums { get; set; }

        private Album selectedAlbum;
        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album()
                    {
                        AlbumTitle = value.AlbumTitle,
                        AlbumId = value.AlbumId,
                    };
                    OnPropertyChanged();
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAlbumCommand { get; set; }

        public ICommand DeleteAlbumCommand { get; set; }

        public ICommand UpdateAlbumCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public AlbumWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Album>("http://localhost:53770/", "album", "hub");
                CreateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Add(new Album()
                    {
                        AlbumTitle = SelectedAlbum.AlbumTitle
                    });
                });

                UpdateAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Update(SelectedAlbum);
                });

                DeleteAlbumCommand = new RelayCommand(() =>
                {
                    Albums.Delete(SelectedAlbum.AlbumId);
                },
                () =>
                {
                    return SelectedAlbum != null;
                });
                SelectedAlbum = new Album();
            }
        }
    }
}
