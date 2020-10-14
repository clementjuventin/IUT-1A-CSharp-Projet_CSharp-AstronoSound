using AstronoSound;
using AstronoSound.ListesDeMusiques;
using Modele;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour listPlaylistUC.xaml
    /// </summary>
    public partial class listPlaylistUC : UserControl
    {
        public Navigator Navigator => (App.Current as App).Navigator;
        public listPlaylistUC()
        {
            InitializeComponent();
            DataContext = GetTheCurrent.Mgr.Donnee.User;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var createPlaylistWindow = new Feunetres.CreationPlaylist();
            createPlaylistWindow.ShowDialog();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)//Si e.AddedItems est vide cad qu'on vient de supprimer une playlist
            {
                return;
            }
            GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist = e.AddedItems[0] as PlaylistPersonnelle;

            Navigator.GoTo(Navigator.DETAIL_FOR_PLAYLIST);
        }
    }
}
