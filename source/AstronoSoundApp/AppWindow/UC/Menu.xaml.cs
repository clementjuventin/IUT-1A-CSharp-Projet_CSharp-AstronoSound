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
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        private Navigator Navigator = (App.Current as App).Navigator;
        public Menu()
        {
            InitializeComponent();
            DataContext = GetTheCurrent.Mgr.Donnee;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)//Si e.AddedItems est vide cad qu'on vient de supprimer une playlist
            {
                return;
            }
            GetTheCurrent.Mgr.Donnee.SelectedCasualPlaylist = e.AddedItems[0] as Playlist;
            Navigator.GoTo(Navigator.DETAIL_FOR_CASUAL_PLAYLIST);
        }
    }
}
