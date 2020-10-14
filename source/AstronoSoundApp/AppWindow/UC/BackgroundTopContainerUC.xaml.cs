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
    /// Logique d'interaction pour backgroundTopContainerUC.xaml
    /// </summary>
    public partial class BackgroundTopContainerUC : UserControl
    {
        Navigator Navigator = (App.Current as App).Navigator;
        public BackgroundTopContainerUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.GoTo(Navigator.MENU);
        }

        private void SearchFor(object sender, RoutedEventArgs e)
        {
            GetTheCurrent.Mgr.Donnee.User.WhenSearch(search.Text);
            GetTheCurrent.Mgr.Donnee.User.MusiqueRechercheeSelectionnee = null;
            Navigator.GoTo(Navigator.RESEARCH);
        }

        private void Search_GotFocus(object sender, RoutedEventArgs e)
        {
            if (search.Text == "Recherche")
            {
                search.Clear();
            }
        }

        private void Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                SearchFor(null, null);
            }
        }
    }
}
