using C8N5NZ_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace C8N5NZ_HFT_2022231.WpfClient
{
    class ArtistWindowViewModel : ObservableRecipient
    {
        public RestCollection<Artist> Artists { get; set; }

        private Artist selectedArtist;
        public Artist SelectedArtist
        {
            get { return selectedArtist; }
            set 
            {
                if (value != null)
                {
                    selectedArtist = new Artist()
                    {
                        Name = value.Name,
                        ArtistId = value.ArtistId
                    };
                    OnPropertyChanged();
                    (DeleteArtistCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateArtistCommand { get; set; }

        public ICommand DeleteArtistCommand { get; set; }

        public ICommand UpdateArtistCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ArtistWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Artists = new RestCollection<Artist>("http://localhost:53770/", "artist", "hub");
                CreateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Add(new Artist()
                    {
                        Name = SelectedArtist.Name
                    });
                });

                UpdateArtistCommand = new RelayCommand(() =>
                {
                    Artists.Update(SelectedArtist);
                });

                DeleteArtistCommand = new RelayCommand(() =>
                {
                    Artists.Delete(SelectedArtist.ArtistId);
                },
                () =>
                {
                    return SelectedArtist != null;
                });
                SelectedArtist = new Artist();
            }
        }
    }
}
