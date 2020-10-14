using AstronoSound;
using AstronoSound.ListesDeMusiques;
using Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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
    /// Logique d'interaction pour Research.xaml
    /// </summary>
    public partial class Research : UserControl
    {
        private Navigator Navigator = (App.Current as App).Navigator;
        public Research()
        {
            InitializeComponent();
            DataContext = GetTheCurrent.Mgr.Donnee.User;
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
            {
                return;
            }
            GetTheCurrent.Mgr.Donnee.User.MusiqueRechercheeSelectionnee = e.AddedItems[0] as Musique;
        }

        private void ListBox_SelectionChanged_Playlist(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1)
            {
                return;
            }
            if(GetTheCurrent.Mgr.Donnee.LesPlaylist.Contains(e.AddedItems[0] as Playlist))
            {
                GetTheCurrent.Mgr.Donnee.SelectedCasualPlaylist = e.AddedItems[0] as Playlist;
                Navigator.GoTo(Navigator.DETAIL_FOR_CASUAL_PLAYLIST);
            }
            else
            {
                GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist = e.AddedItems[0] as PlaylistPersonnelle;
                Navigator.GoTo(Navigator.DETAIL_FOR_PLAYLIST);
            }
        }
    }
}
