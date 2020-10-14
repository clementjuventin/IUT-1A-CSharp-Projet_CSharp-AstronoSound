using AppWindow.UC;
using AstronoSound;
using AstronoSound.ListesDeMusiques;
using StubTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Navigator Navigator => (App.Current as App).Navigator;
        public Manager Mgr => (App.Current as App).LeManager;

        public MainWindow()
        {
            //DonneeBrutte.CreerUtilisateur();
            //DonneeBrutte.CreerDesPlaylist();
            InitializeComponent();
            DataContext = this;
        }
    }
}
