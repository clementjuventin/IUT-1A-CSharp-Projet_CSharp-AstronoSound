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
    /// Logique d'interaction pour backgroundLeftContainerUC.xaml
    /// </summary>
    public partial class BackgroundLeftContainerUC : UserControl
    {
        public BackgroundLeftContainerUC()
        {
            InitializeComponent();
            DataContext = GetTheCurrent.Mgr.Donnee.User;
        }
        public int PlaylistNumber
        {
            set
            {
                namePlaylistNumber.Text = value.ToString();
            }
        }
        public int MusicNumber
        {
            set
            {
                nameAjoutNumber.Text = value.ToString();
            }
        }
        public int ConsultationNumber
        {
            set
            {
                nameConsultationNumber.Text = value.ToString();
            }
        }
        public int Niveau
        {
            set
            {
                nameNiveauNumber.Text = value.ToString();
            }
        }
    }
}
