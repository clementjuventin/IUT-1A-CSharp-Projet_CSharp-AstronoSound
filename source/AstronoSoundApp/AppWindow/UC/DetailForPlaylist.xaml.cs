using AstronoSound;
using Modele;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWindow.UC
{
    /// <summary>
    /// Logique d'interaction pour DetailForPlaylist.xaml
    /// </summary>
    public partial class DetailForPlaylist : UserControl
    {
        Navigator Navigator = (App.Current as App).Navigator;
        public DetailForPlaylist()
        {
            InitializeComponent();
            DataContext = GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist;
            GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist.NombreVisions++;
            if (GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist.LesMusiques.Count > 0)
            {
                GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist.SelectedMusic = GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist.LesMusiques[0];
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }
            GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist.SelectedMusic = e.AddedItems[0] as Musique;
        }
        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            var createMusicWindow = new Feunetres.CréationMusique();
            createMusicWindow.ShowDialog();
        }
        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous vraiment supprimer la playlist?", "Attention", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    GetTheCurrent.Mgr.Donnee.User.SupprimerUnePlaylist(GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist);
                    Navigator.GoTo(Navigator.MENU);
                    break;
                case MessageBoxResult.No:
                    return;
            }
        }
        private void Button_Click_Delete_Music(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous vraiment supprimer la playlist?", "Attention", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    GetTheCurrent.Mgr.Donnee.User.SupprimerTitre(GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist, GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist.SelectedMusic);
                    break;
                case MessageBoxResult.No:
                    return;
            }
        }
        private void Button_Click_Import(object sender, RoutedEventArgs e)
        {
            var importMusicWindow = new Feunetres.ImporterMusique();
            importMusicWindow.ShowDialog();
        }
        private void Supprimer_Musique_Playlist(object sender, RoutedEventArgs e)
        {
            try
            {
                GetTheCurrent.Mgr.Donnee.User.SupprimerTitre(GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist, GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist.SelectedMusic);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("La musique que vous souhaitez supprimer n'existe pas.", "Attention");
            }
        }
        /*
        private void Supprimer_Musique(object sender, RoutedEventArgs e)
        {
            Musique m = GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist.SelectedMusic;
            GetTheCurrent.Mgr.Donnee.User.LesMusiques.Remove(m);
            foreach(AstronoSound.ListesDeMusiques.PlaylistPersonnelle p in GetTheCurrent.Mgr.Donnee.User.LesPlaylists)
            {
                if (p.LesMusiques.Contains(m))
                {
                    p.LesMusiques.Remove(m);
                }
            }
        }
        */
    }
}
