using Lab8.Models;
using Lab8.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace Lab8
{
    public sealed partial class MainPage : Page
    {
        public ObservableCollection<MusicTrack> Tracks { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            Tracks = new ObservableCollection<MusicTrack>();
            MigrationService.MigrateDatabase();
            LoadData();
        }

        private void LoadData()
        {
            var tracks = DataRepository.GetAllTracks();
            tracks.ForEach(t => Tracks.Add(t));
        }

        private void AddTrackButton_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string artist = txtArtist.Text;
            string album = txtAlbum.Text;
            int year = int.Parse(txtYear.Text);

            var newTrack = new MusicTrack { Title = title, Artist = artist, Album = album, Year = year };
            DataRepository.AddTrack(newTrack);
            Tracks.Add(newTrack);

            txtTitle.Text = "";
            txtArtist.Text = "";
            txtAlbum.Text = "";
            txtYear.Text = "";
        }

        private void UpdateTrackButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTrack = musicListView.SelectedItem as MusicTrack;
            if (selectedTrack != null)
            {
               
            }
        }

        private void RemoveTrackButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTrack = musicListView.SelectedItem as MusicTrack;
            if (selectedTrack != null)
            {
                DataRepository.RemoveTrack(selectedTrack);
                Tracks.Remove(selectedTrack);
            }
        }

        private void RemoveAllTracksButton_Click(object sender, RoutedEventArgs e)
        {
            DataRepository.RemoveAllTracks();
            Tracks.Clear();
        }
    }
}



