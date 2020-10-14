using AstronoSound;
using AstronoSound.Attributs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstronoSound.ListesDeMusiques
{
    [System.Runtime.Serialization.DataContract]
    public class Album : Playlist
    {
        private Artiste auteur;
        private string dateDeSortie;

        //Constructeur
        public Album(string titre, string description, Genre? genre, string dateDeSortie, Artiste auteur, string duree, Url image) : base(titre, description, image.Adresse, genre) 
        {
            this.auteur = auteur;
            this.dateDeSortie = dateDeSortie;
        }
        public Album(): base() { }

        public Artiste Auteur { get { return auteur; }set { auteur = value; } }
        public string DateDeSortie { get { return dateDeSortie; } set { dateDeSortie = value; } }
    }
}
