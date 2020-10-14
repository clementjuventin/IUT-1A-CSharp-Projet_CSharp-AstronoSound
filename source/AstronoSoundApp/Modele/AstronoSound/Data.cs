using AstronoSound.Attributs;
using AstronoSound.ListesDeMusiques;
using Modele;
using Modele.AstronoSound.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

namespace AstronoSound
{
    public class Data: INotifyPropertyChanged
    {
        const string DATA_PATH = "dataAstronoSound";

        private List<Musique> lesMusiques;         //Enssemble des musiques présentes dans la base de donnée
        private List<Playlist> lesPlaylist;       //Enssemble des playlist présentes dans la base de donnée
        private Utilisateur user;//A changer car pas serialiser
        private Playlist selectedCasualPlaylist;

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public List<Decouverte> LesDecouvertes { get { return GetDecouvertes(); } }
        public List<Album> LesAlbums { get { return GetAlbums(); } }
        public Data()
        {
            try
            {
                DataPersistance data = Persistance.ChargerDonnee(DATA_PATH);
                LesMusiques = new List<Musique>();
                if(data.LesMusiques != null)
                {
                    LesMusiques.AddRange(data.LesMusiques);
                }
                if (data.User != null)
                {
                    User = data.User;
                }
                else
                {
                    User = new Utilisateur();
                }
                LesPlaylist = new List<Playlist>();
                if (data.LesAlbums != null)
                {
                    LesPlaylist.AddRange(data.LesAlbums);
                }
                if (data.LesDecouvertes != null)
                {
                    LesPlaylist.AddRange(data.LesDecouvertes);
                }
            }
            catch (FileNotFoundException) 
            {
                try
                {
                    LesMusiques = Serialiser<Musique>.DeserialiserListe("musiqueData");
                }
                catch (Exception) { LesMusiques = new List<Musique>(); }
                LesPlaylist = new List<Playlist>();
                User = new Utilisateur();
                User.LesPlaylists.Add(new PlaylistPersonnelle("Ma première playlist", "Cette playlist a été crée pour vous afin que vous testiez l'application, n'hésitez pas à ajouter ou importer des musiques que vous aimez!", "", Attributs.Genre.Pop));
                ChargerLaPreparation();
            }
        }
        

        //Accesseurs
        public List<Musique> LesMusiques { get { return lesMusiques; } set { lesMusiques = value; } }
        public List<Playlist> LesPlaylist { get { return lesPlaylist; } set { lesPlaylist = value; } }
        public Utilisateur User { get { return user; } set { user = value; } }
        public List<Album> GetAlbums()
        {
            List<Album> lesAlbums = new List<Album>();
            foreach (Playlist p in LesPlaylist)
            {
                if (p is Album) { lesAlbums.Add(p as Album); }
            }
            return lesAlbums;
        }
        public List<Decouverte> GetDecouvertes()
        {
            List<Decouverte> lesDecouvertes = new List<Decouverte>();
            foreach (Playlist p in LesPlaylist)
            {
                if (p is Decouverte) { lesDecouvertes.Add(p as Decouverte); }
            }
            return lesDecouvertes;
        }
        public Playlist SelectedCasualPlaylist
        {
            get { return selectedCasualPlaylist; }
            set
            {
                selectedCasualPlaylist = value;
                User.Vues++;
                OnPropertyChanged();
            }
        }

        public void OnClose()
        {
            Persistance.SauvegarderDonee(DATA_PATH);
        }
        private void ChargerLaPreparation()
        {
            Musique m1 = new Musique("Sound Of Violence", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));
            Musique m2 = new Musique("Lost Day", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));
            Musique m3 = new Musique("Cops", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));
            Musique m4 = new Musique("All Eyes - For Their Love", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));
            Musique m5 = new Musique("Dead Language", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));
            Musique m6 = new Musique("Nites Out", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));
            Musique m7 = new Musique("We Wait", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));
            Musique m8 = new Musique("Hey Hey I", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));
            Musique m9 = new Musique("Who's Gonna Love Us", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));
            Musique m10 = new Musique("Sideways", new List<Artiste> { new Artiste("Other Lives") }, Genre.Rocknroll, new Url("https://open.spotify.com/album/7DlB2yPrKNT45Zhu2rnOR1?autoplay=true&v=L"));

            List<Musique> unAlbum = new List<Musique> { m1,m2,m3,m4,m5,m6,m7,m8,m9,m10 };
            Album A1 = new Album("For Their Love", "L’art, peu importe sa forme, arrive toujours à rentrer dans nos têtes pour nous transporter ailleurs. Souvent loin de notre quotidien, voire loin de notre propre réalité. La musique a cet effet sur le corps si l’on ferme les yeux. Ce sentiment de liberté, cet appel au voyage, c’est la clé depuis des années pour Other Lives, qui fait partie de leur ADN. Ce groupe nous venant tout droit des plaines de l’Oklahoma pousse les frontières de la folk, avec un nouvel album des plus captivants, For Their Love (PIAS).  ", Genre.Rocknroll ,"24/04/2020", new Artiste("Other Lives"),"20 mins", new Url("data:image/jpeg;base64,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"));

            foreach(Musique m in unAlbum)
            {
                LesMusiques.Add(m);
                A1.AjouterMusique(m);
            }
            LesPlaylist.Add(A1);

            Musique m11 = new Musique("Future Nostalgia", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m12 = new Musique("Don't Start Now", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m13 = new Musique("Cool", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m14 = new Musique("Physical", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m15 = new Musique("Levitating", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m16 = new Musique("Pretty Please", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m17 = new Musique("Hallucinate", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m18 = new Musique("Love Again", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m19 = new Musique("Break My Heart", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m20 = new Musique("Good In Bed", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));
            Musique m21 = new Musique("Boys Will Be Boys", new List<Artiste> { new Artiste("Dua Lipa") }, Genre.Pop, new Url("https://open.spotify.com/album/4KwrZSxfPq67eTcNsjRMW6?autoplay=true&v=L"));

            List<Musique> unAlbum2 = new List<Musique> { m11, m12, m13, m14, m15, m16, m17, m18, m19, m20, m21 };
            Album A2 = new Album("Future Nostalgia", "Future Nostalgia est le deuxième album studio de la chanteuse britannique Dua Lipa. Il est sorti le 27 mars 2020. ", Genre.Pop, "27/03/2020", new Artiste("Dua Lipa"), "37:17", new Url("data:image/jpeg;base64,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"));

            foreach (Musique m in unAlbum2)
            {
                LesMusiques.Add(m);
                A2.AjouterMusique(m);
            }
            LesPlaylist.Add(A2);

            Decouverte d1 = new Decouverte("Mon Mix 1", "Un mix original proposé par les créateurs d'AstronoSound", "", Genre.Pop);
            d1.SeGenererAleatoirement(LesMusiques, 14);
            Decouverte d2 = new Decouverte("Mon Mix 2", "Un mix original proposé par les créateurs d'AstronoSound", "", Genre.Pop);
            d2.SeGenererAleatoirement(LesMusiques, 12);
            Decouverte d3 = new Decouverte("Mon Mix 3", "Un mix original proposé par les créateurs d'AstronoSound", "", Genre.Pop);
            d3.SeGenererAleatoirement(LesMusiques, 16);

            LesPlaylist.Add(d1);
            LesPlaylist.Add(d2);
            LesPlaylist.Add(d3);
        }
    }
}
