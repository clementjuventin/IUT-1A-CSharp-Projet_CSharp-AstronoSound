using AstronoSound.Attributs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstronoSound.ListesDeMusiques
{
    [System.Runtime.Serialization.DataContract]
    public class Decouverte : Playlist
    {
        //Constructeur
        public Decouverte(string titre, string description, string photo, Genre genre) : base(titre, description, photo, genre) { }
        public Decouverte() : base() { }
        public void SeGenererAleatoirement(List<Musique> listeMusiques, int taille)
        {
            Random rand = new Random();
            int index;
            while(this.LesMusiques.Count < taille)
            {
                index = rand.Next(listeMusiques.Count);
                this.AjouterMusique(listeMusiques[index]);
            }
        }
    }
}
