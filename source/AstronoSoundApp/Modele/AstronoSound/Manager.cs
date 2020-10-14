using AstronoSound;
using AstronoSound.ListesDeMusiques;
using Modele;
using System;
using System.Collections.Generic;
using System.Text;

namespace AstronoSound
{
    public class Manager
    {
        public Data donnee = new Data();    //Données de l'application (le constructeur déserialise les données stockées)

        //Accesseurs
        public Data Donnee { get { return donnee; } private set { donnee = value; } }

        //Méthodes
        /// <summary>
        /// Permet la création d'une Musique et l'ajout à la base de donnée
        /// </summary>
        /// <param name="m"></param>
        public void CreerMusique(Musique m)
        {
            Donnee.LesMusiques.Add(m);
        }
        /// <summary>
        /// Permet la création d'une Playlist par l'utilisateur
        /// </summary>
        /// <param name="playlist"></param>
        public void CreerPlaylist(Playlist playlist)
        {
            if (playlist.GetType()==typeof(Playlist))
            {
                ((Decouverte) playlist).SeGenererAleatoirement(GetTheCurrent.Mgr.Donnee.LesMusiques, 10);
            }
            Donnee.LesPlaylist.Add(playlist);
        }
        /// <summary>
        /// Retourne une liste de musiques dont les titres ou l'auteur contiennent la chaine "titre" passé en paramètre: Indépendément de la caste.
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        public List<Musique> MusiquesRecherches(string titre)
        {
            List<Musique> correspondance = new List<Musique>();
            foreach (Musique m in Donnee.LesMusiques)
            {
                if (m.Titre.ToLower().Contains(titre.ToLower()) || m.LesArtistes.ToString().Contains(titre))
                {
                    correspondance.Add(m);
                }
            }
            return correspondance;
        }
        /// <summary>
        /// Retourne une liste de playlist dont les titres ou l'auteur contiennent la chaine "titre" passé en paramètre: Indépendément de la caste.
        /// </summary>
        /// <param name="titre"></param>
        /// <returns></returns>
        public List<Playlist> PlaylistRecherches(string titre)
        {
            List<Playlist> correspondance = new List<Playlist>();
            foreach (Playlist p in Donnee.LesPlaylist)
            {
                if (p.Titre.ToLower().Contains(titre.ToLower()))
                {
                    correspondance.Add(p);
                }
            }
            foreach (Playlist p in Donnee.User.LesPlaylists)
            {
                if (p.Titre.ToLower().Contains(titre.ToLower()))
                {
                    correspondance.Add(p);
                }
            }
            return correspondance;
        }
    }
}