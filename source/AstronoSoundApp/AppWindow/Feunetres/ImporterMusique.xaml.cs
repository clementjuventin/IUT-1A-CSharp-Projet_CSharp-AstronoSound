using AstronoSound;
using Modele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppWindow.Feunetres
{
    /// <summary>
    /// Logique d'interaction pour ImporterMusique.xaml
    /// </summary>
    public partial class ImporterMusique : Window
    {
        public IEnumerable<Musique> LesMusiques { get; set; } = new List<Musique>();
        public ImporterMusique()
        {
            InitializeComponent();
            DataContext = this;
            LesMusiques = GetTheCurrent.Mgr.Donnee.LesMusiques.OrderBy(n => n.Titre);
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetTheCurrent.Mgr.Donnee.User.AjouterMusiquePlaylist(GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist, e.AddedItems[0] as Musique);
            this.Close();
        }
    }
}
