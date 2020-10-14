using AstronoSound.Attributs;
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
using System.Windows.Shapes;
using System.Runtime;
using Modele;

namespace AppWindow.Feunetres
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class CreationPlaylist : Window
    {
        public List<string> lesGenres = new List<string>(Enum.GetNames(typeof(Genre)));
        public Genre? GenreSelectionne { get; private set; }
        public CreationPlaylist()
        {
            InitializeComponent();
            DataContext = this;
            comboBox.ItemsSource = lesGenres;
            comboBox.Text = "--";
            comboBox.IsEditable = true;
        }

        private void Button_Annuler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string titledata;
        private string descriptiondata;
        public string Titre
        {
            get { return titledata; }
            set { titledata = value; }
        }
        public string DescriptionData
        {
            get { return descriptiondata; }
            set { descriptiondata = value; }
        }
        private void SendButton(object sender, EventArgs e)
        {
            titledata = Title.Text;
            if (titledata.Trim().Equals(""))
            {
                MessageBox.Show("La playlist doit contenir un titre au minimum");
                return;
            }
            descriptiondata = Description.Text;
            this.Close();
            GetTheCurrent.Mgr.Donnee.User.CreerUnePlaylist(titledata, descriptiondata, "", GenreSelectionne);
        }

        /*
        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            Genre genre = Enum.Parse<Genre>(comboBox.SelectedItem as string);
            if (GenresSelectionnes.Contains(genre)) { return; }
            GenresSelectionnes.Add(genre);
            string message = "";
            if (GenresSelectionnes.Count == 1)
            {
                enumDisplay.Text = comboBox.SelectedItem as string;
                return;
            }
            enumDisplay.Text = enumDisplay.Text+", "+ (comboBox.SelectedItem as string);
        }
        */
        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
            GenreSelectionne = Enum.Parse<Genre>(comboBox.SelectedItem as string);
        }
    }
}
