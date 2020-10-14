using System;
using System.Collections.Generic;
using AstronoSound;
using AstronoSound.Attributs;
using AstronoSound.ListesDeMusiques;
using Modele;

namespace StubTest
{
    public class TestsUnitaires
    {
        public string TestEqualsMusique()//Test égalité de deux musiques
        {
            Musique mus1 = new Musique("Musique1", new List<Artiste>() { new Artiste("A1"), new Artiste("A2") }, new Url("test"));
            Musique mus2 = new Musique("Musique1", new List<Artiste>() { new Artiste("A2"), new Artiste("A1") }, new Url("test"));

            return mus1.Equals(mus2) ? "true (résultat attendu)" : "false (résultat non attendu)";
        }
        public string CreationDePlaylistParUtilisateur()//Test de création d'une playlist et d'égalité
        {
            Utilisateur user = GetTheCurrent.Mgr.Donnee.User;
            user.CreerUnePlaylist("Titre", "Description", "", Genre.Classique);
            user.AjouterMusiquePlaylist(user.LesPlaylists[user.LesPlaylists.IndexOf(new PlaylistPersonnelle("Titre", "Description", "", Genre.Classique))], new Musique("Musique1", new List<Artiste>() { new Artiste("A2"), new Artiste("A1") }, new Url("test")));
            return $"La playlist {user.LesPlaylists[user.LesPlaylists.IndexOf(new PlaylistPersonnelle("Titre", "Description", "", Genre.Classique))].Titre} a été crée et elle contient la musique {user.LesPlaylists[user.LesPlaylists.IndexOf(new PlaylistPersonnelle("Titre", "Description", "", Genre.Classique))].LesMusiques[0].Titre}\nRésultat attendu:\nLa playlist Titre a été crée et elle contient la musique Musique1";
        }
        public string Recherche()//Test de recherches
        {
            Utilisateur user = GetTheCurrent.Mgr.Donnee.User;

            Musique mus1 = new Musique("Musique1", new List<Artiste>() { new Artiste("A1"), new Artiste("A2") }, new Url("test"));
            Musique mus2 = new Musique("Musique2", new List<Artiste>() { new Artiste("A2"), new Artiste("A1") }, new Url("test"));
            Musique musCible = new Musique("MusiqueMotClé", new List<Artiste>() { new Artiste("A3"), new Artiste("A2") }, new Url("test"));
            Musique mus3 = new Musique("Musique3", new List<Artiste>() { new Artiste("A2"), new Artiste("A1") }, new Url("test"));

            GetTheCurrent.Mgr.CreerMusique(mus1);
            GetTheCurrent.Mgr.CreerMusique(mus2);
            GetTheCurrent.Mgr.CreerMusique(musCible);
            GetTheCurrent.Mgr.CreerMusique(mus3);

            user.CreerUnePlaylist("Playlist1", "Description", "", Genre.Classique);
            user.CreerUnePlaylist("Playlist MotClé", "Description", "", Genre.Classique);
            user.CreerUnePlaylist("Playlist2", "Description", "", Genre.Classique);

            string ret = "Résultats attendus:\nMusiques trouvées: MusiqueMotClé\nPlaylists trouvées: \"Playlist MotClé\"\n\n";
            foreach (Musique m in GetTheCurrent.Mgr.MusiquesRecherches("A3"))
            {
                ret += $"Musiques trouvées: \"{m.Titre}\"\n";
            }
            foreach (Playlist p in GetTheCurrent.Mgr.PlaylistRecherches("motclé"))
            {
                ret += $"Playlists trouvées: \"{p.Titre}\"\n";
            }
            return ret;
        }
        public string SuppressionPlaylist()//Test de supression
        {
            Utilisateur user = GetTheCurrent.Mgr.Donnee.User;

            user.CreerUnePlaylist("Titre", "Description", "", Genre.Classique);

            string ret = $"Playlist crée: {user.LesPlaylists[user.LesPlaylists.IndexOf(new PlaylistPersonnelle("Titre", "Description", "", Genre.Classique))].Titre}\n";
            user.LesPlaylists.Remove(user.LesPlaylists[user.LesPlaylists.IndexOf(new PlaylistPersonnelle("Titre", "Description", "", Genre.Classique))]);
            if(user.LesPlaylists.Contains(user.LesPlaylists[user.LesPlaylists.IndexOf(new PlaylistPersonnelle("Titre", "Description", "", Genre.Classique))]))
            {
                ret += "Supression échouée";
            }
            else
            {
                ret += "Suppression effectuée";
            }
            ret += "\nRésultat attendu: Suppression effectuée";
            return ret;
        }
        public string CreassionPlaylistEtAjouterMusique()
        {
            string AfficherPlaylist(Playlist p)
            {
                return $"Titre: {p.Titre}\t\tDescription:{p.Description}\t\tNombre de Musique: {p.NombreDeMusique}\n\n";
            }

            Musique mus1 = new Musique("Musique1", new List<Artiste>() { new Artiste("A1"), new Artiste("A2") }, new Url("test"));
            Utilisateur user = GetTheCurrent.Mgr.Donnee.User;
            user.CreerUnePlaylist("Lofi", "Playlist de type lofi.", "", Genre.Pop);
            string mess = "";

            foreach (Playlist p in GetTheCurrent.Mgr.PlaylistRecherches("Lofi"))
            {
                mess += AfficherPlaylist(p);
            }
            mess += "Ajout d'une musique";
            foreach (Playlist p in GetTheCurrent.Mgr.PlaylistRecherches("Lofi"))
            {
                p.AjouterMusique(mus1);
                mess += AfficherPlaylist(p);
            }
            return mess;
        }
        public string InitialisationDuManager()
        {
            string mess = $"Il y a {GetTheCurrent.Mgr.Donnee.LesPlaylist.Count} playlists:\n";
            foreach (Playlist p in GetTheCurrent.Mgr.Donnee.LesPlaylist)
            {
                mess += p.Titre + "\n";
                foreach (Musique m in p.LesMusiques)
                {
                    mess += $"\t{m.Titre}\n";
                }
            }
            return mess;
        }
    }
}
