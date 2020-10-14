using AstronoSound.Attributs;
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
    /// Logique d'interaction pour CréationMusique.xaml
    /// </summary>
    public partial class CréationMusique : Window
    {
        public List<string> lesGenres = new List<string>(Enum.GetNames(typeof(Genre)));
        public Genre? GenreSelectionne { get; private set; }
        public CréationMusique()
        {
            InitializeComponent();
            comboBox.ItemsSource = lesGenres;
            comboBox.Text = "--";
            comboBox.IsEditable = true;
        }
        private void Button_Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void AddArtist(object sender, RoutedEventArgs e)
        {
            if (Artiste.Text.Trim().Equals(""))
            {
                MessageBox.Show("Pour ajouter un artiste il faut saisir un nom.");
                return;
            }
            LesArtistes.Add(new Artiste(Artiste.Text));
            nomsArtistes.Text = string.Join(", ", LesArtistes);
            Artiste.Clear();
        }
        private void Artiste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                AddArtist(null, null);
            }
        }

        private string titleData;
        private Url urlData;
        private List<Artiste> lesArtistes = new List<Artiste>();
        public string Titre
        {
            get { return titleData; }
            set { titleData = value; }
        }
        public Url UrlData
        {
            get { return urlData; }
            set { urlData = value; }
        }
        public List<Artiste> LesArtistes
        {
            get { return lesArtistes; }
            set { lesArtistes = value; }
        }

        private void SendButton(object sender, EventArgs e)
        {
            Titre = Title.Text;
            if (titleData.Trim().Equals(""))
            {
                MessageBox.Show("La playlist doit contenir un titre au minimum");
                return;
            }
            if (Url.Text.Trim().Equals(""))
            {
                UrlData = null;
            }
            else
            {
                UrlData = new Url(Url.Text);
            }
            GetTheCurrent.Mgr.Donnee.User.CreerMusique(Titre, LesArtistes, GenreSelectionne, UrlData);
            GetTheCurrent.Mgr.Donnee.User.SelectedPlaylist.AjouterMusique(GetTheCurrent.Mgr.Donnee.User.LesMusiques.Last());
            this.Close();
        }
        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            GenreSelectionne = Enum.Parse<Genre>(comboBox.SelectedItem as string);
        }
    }
}
