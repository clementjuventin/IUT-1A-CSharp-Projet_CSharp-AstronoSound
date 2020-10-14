using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using AstronoSound;
using AstronoSound.Attributs;
using AstronoSound.ListesDeMusiques;
using Modele;

namespace AstronoSound
{
    [DataContract]
    public class Utilisateur: INotifyPropertyChanged
    {
        //Attributs
        [DataMember]
        private int vues;       //Nombre de fois ou l'utilisateur a visionné une musique/Playlist
        [DataMember]
        private int ajouts;     //Nombre d'ajout (musique ou playlist) effectués sur l'application
        [DataMember]
        private int experience;   //Niveau de l'utilisateur
        private int percent;
        [DataMember]
        private ObservableCollection<PlaylistPersonnelle> lesPlaylists; //Playlist crées par l'utilisateur
        [DataMember]
        private ObservableCollection<Musique> lesMusiques;  //Les musiques ajoutées par l'utilisateur

        //Affichage et binding
        private PlaylistPersonnelle selectedPlaylist;
        private string lesPlaylistsCount;   //Nombre de playlists
        private string lesMusiquesCount;    //Nombre de musiques dans selected playlist
        private Musique musiqueRechercheeSelectionnee;  //Musique en cours de sélection qui appartient à la playlist selectionné
        private List<Playlist> recherchePlaylist;   //La liste des musiques recherches par l'utilisateur
        private List<Musique> rechercheMusique;     //La liste des musiques recherchées par l'utilisateur
        public string Niveau { get { return GetNiveau().ToString(); } set { Niveau = value; } } //Niveau de l'utilisateur
        //  5 niveaux => 100, 400, 2000, 9000, 40000        une vue = 1,  Une musique = 5, une playlist = 20 

        /// <summary>
        /// Implémentation de INotifyPropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //Constructeur
        public Utilisateur()
        {
            this.vues = 0;
            this.ajouts = 0;
            this.experience = 0;
            lesPlaylists = new ObservableCollection<PlaylistPersonnelle>();
            lesMusiques = new ObservableCollection<Musique>();
        }

        //Accesseurs
        public PlaylistPersonnelle SelectedPlaylist
        {
            get { return selectedPlaylist; }
            set
            {
                selectedPlaylist = value;
                Vues++;
            }
        } //Playlist selectionnée
        public int Vues 
        { 
            get { return vues; } 
            set 
            { 
                vues = value;
                AugmenterNiveau(1);
                OnPropertyChanged();
            } 
        }
        public int Ajouts { get { return ajouts; } set { ajouts = value; } }
        public int Experience { get { return experience; } 
            set { 
                experience = value;
                OnPropertyChanged(nameof(Percent));
                OnPropertyChanged(nameof(Niveau));
            } 
        }
        public ObservableCollection<PlaylistPersonnelle> LesPlaylists { get { return lesPlaylists; } set { lesPlaylists = value;} }
        public ObservableCollection<Musique> LesMusiques { get { return lesMusiques; } set { lesMusiques = value; } }
        public string LesMusiquesCount 
        { 
            get 
            { 
                return lesMusiques.Count.ToString(); 
            } 
            set 
            { 
                lesMusiquesCount = value;
                OnPropertyChanged();
            } 
        }
        public string LesPlaylistsCount 
        {
            get { return lesPlaylists.Count.ToString(); } 
            set 
            { 
                lesPlaylistsCount = value;
                OnPropertyChanged();
            } 
        }
        public int Percent
        {
            get
            {
                if (Niveau.Equals("5")) { return 100; }
                return 100 * (Experience - (int)FonctionNiveau(GetNiveau() - 1)) / ((int)FonctionNiveau(GetNiveau()) - (int)FonctionNiveau(GetNiveau() - 1));
            }
            set { percent = value; }
        }
        public Musique MusiqueRechercheeSelectionnee
        {
            get
            {
                return musiqueRechercheeSelectionnee;
            }
            set
            {
                musiqueRechercheeSelectionnee = value;
                OnPropertyChanged();
            }
        }
        public List<Playlist> RecherchePlaylist
        {
            get
            {
                return recherchePlaylist;
            }
            set
            {
                recherchePlaylist = value;
                OnPropertyChanged();
            }
        }
        public List<Musique> RechercheMusique
        {
            get
            {
                return rechercheMusique;
            }
            set
            {
                rechercheMusique = value;
                OnPropertyChanged();
            }
        }

        //Méthodes
        /// <summary>
        /// Quand l'utilisateur recherche un temre cette fonction est appellée pour mettre à jour RecherchePlaylist et RechercheMusique
        /// </summary>
        /// <param name="chaine"></param>
        public void WhenSearch(string chaine)
        {
            RecherchePlaylist = GetTheCurrent.Mgr.PlaylistRecherches(chaine);
            RechercheMusique = GetTheCurrent.Mgr.MusiquesRecherches(chaine);
        }
        /// <summary>
        /// Méthode qui permet d'augmenter Utilisateur.exp en testant sa valeur pour savoir en quelle circonstance l'exp a été attribué
        /// </summary>
        /// <param name="exp">Expérience ajoutée</param>
        public void AugmenterNiveau(int exp)
        {
            Experience += exp;
        }
        /// <summary>
        /// Permet de créer une playlist de type PlaylistPersonnelle et de l'ajouter à la liste de playlist qu'a l'utilisateur.
        /// </summary>
        /// <param name="titre"></param>
        /// <param name="description"></param>
        /// <param name="photo">Miniature utilisée</param>
        /// <param name="genre"></param>
        public void CreerUnePlaylist(string titre, string description, string photo, Genre? genre)
        {
            PlaylistPersonnelle playlist = new PlaylistPersonnelle(titre, description, photo, genre);
            LesPlaylists.Add(playlist);
            OnPropertyChanged(nameof(LesPlaylistsCount));
            AugmenterNiveau(20);
        }
        /// <summary>
        /// Permet de supprimer une playlist
        /// </summary>
        /// <param name="playlist"></param>
        public void SupprimerUnePlaylist(PlaylistPersonnelle playlist)
        {
            lesPlaylists.Remove(playlist);
            OnPropertyChanged(nameof(LesPlaylistsCount));
        }
        /// <summary>
        /// Permet d'ajouter une musique à une playlist
        /// </summary>
        /// <param name="playlist"></param>
        /// <param name="musique"></param>
        public void AjouterMusiquePlaylist(PlaylistPersonnelle playlist, Musique musique)
        {
            playlist.AjouterMusique(musique);
            AugmenterNiveau(5);
        }
        /// <summary>
        /// Permet de supprimer un titre de playlist
        /// </summary>
        /// <param name="playlist"></param>
        /// <param name="musique"></param>
        public void SupprimerTitre(PlaylistPersonnelle playlist,Musique musique)
        {
            if (!(playlist.LesMusiques.Contains(musique))) { throw new ArgumentException("La playlist traitées ne contient pas la musique souhaitée."); }
            playlist.SupprimerUneMusique(musique);
        }
        /// <summary>
        /// Permet à l'utilisateur de créer une musique
        /// </summary>
        /// <param name="titre"></param>
        /// <param name="lesArtistes"></param>
        /// <param name="dateDeSortie"></param>
        /// <param name="genre"></param>
        /// <param name="url"></param>
        public void CreerMusique(string titre, List<Artiste> lesArtistes, Genre? genre, Url? url)
        {
            Musique m = new Musique(titre, lesArtistes, genre, url);
            GetTheCurrent.Mgr.CreerMusique(m);
            LesMusiques.Add(m);
            OnPropertyChanged(nameof(LesMusiquesCount));
        }
        /// <summary>
        /// Renvoi un nombre d'exp en fonction de x. Voir GetNiveau() pour les détails
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private double FonctionNiveau(int x)
        {
            return 100 * Math.Exp((double)(3 / 2 * x));
        }
        /// <summary>
        /// Retourne le niveau de l'utilisateur
        /// </summary>
        /// <returns></returns>
        public int GetNiveau()
        {
            if (experience < FonctionNiveau(0)) { return 0; }//   100
            if (experience < FonctionNiveau(1)) { return 1; }//   400
            if (experience < FonctionNiveau(2)) { return 2; }// 2 000
            if (experience < FonctionNiveau(3)) { return 3; }// 9 000
            if (experience < FonctionNiveau(4)) { return 4; }//40 000
            return 5;
        }

        //Redéfinitions
        public override string ToString()
        {
            string message;
            message = $"Utilisateur\n\nNiveau: {GetNiveau()}\nVues: {vues}\nAjouts: {ajouts}\nExperience: {experience}\n\nLes Playlist:\n\n";
            foreach(Playlist p in lesPlaylists)
            {
                message += $"- {p.Titre}\n";
                foreach(Musique m in p.LesMusiques)
                {
                    message += $"\t: {m.Titre}\n";
                }
            }
            message += "\n";
            return message;
        }
    }
}
