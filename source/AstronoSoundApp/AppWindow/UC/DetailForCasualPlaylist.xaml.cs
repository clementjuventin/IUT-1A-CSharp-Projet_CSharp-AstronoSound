using AstronoSound;
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
    /// Logique d'interaction pour DetailForCasualPlaylist.xaml
    /// </summary>
    public partial class DetailForCasualPlaylist : UserControl
    {
        public DetailForCasualPlaylist()
        {
            InitializeComponent();
            DataContext = GetTheCurrent.Mgr.Donnee.SelectedCasualPlaylist;

            GetTheCurrent.Mgr.Donnee.SelectedCasualPlaylist.NombreVisions++;
            if (GetTheCurrent.Mgr.Donnee.SelectedCasualPlaylist.LesMusiques.Count > 0)
            {
                GetTheCurrent.Mgr.Donnee.SelectedCasualPlaylist.SelectedMusic = GetTheCurrent.Mgr.Donnee.SelectedCasualPlaylist.LesMusiques[0];
            }
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
            {
                return;
            }
            GetTheCurrent.Mgr.Donnee.SelectedCasualPlaylist.SelectedMusic = e.AddedItems[0] as Musique;
        }
    }
}
