using AstronoSound.Attributs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AstronoSound.ListesDeMusiques
{
    public class PlaylistPersonnelle : Playlist
    {
        private IEnumerable<Musique> lesMusiquesTriees; //Les musiques triées avec linq

        //Constructeur
        public PlaylistPersonnelle(string titre, string description, string photo, Genre? genre) : base(titre, description, photo, genre) 
        {
            lesMusiquesTriees = this.LesMusiques.OrderBy(n => n.Titre);
        }
        public PlaylistPersonnelle() : base() { }

        //Méthodes
        /// <summary>
        /// Permet d'ajouter une musique à la playlist
        /// </summary>
        /// <param name="musique"></param>
        public new void AjouterMusique(Musique musique)
        {
            this.LesMusiques.Add(musique);
            NombreDeMusique = NombreDeMusique;
        }
        /// <summary>
        /// Supprime une musique de la playlist
        /// </summary>
        /// <param name="musique"></param>
        public new void SupprimerUneMusique(Musique musique)
        {
            this.LesMusiques.Remove(musique);
            NombreDeMusique = NombreDeMusique;
        }
    }
}
