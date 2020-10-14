using AstronoSound;
using AstronoSound.ListesDeMusiques;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Modele.AstronoSound.Utils
{
    [DataContract]
    public class DataPersistance
    {
        [DataMember]
        public IEnumerable<Album> LesAlbums { get; set; } = GetTheCurrent.Mgr.Donnee.GetAlbums() as IEnumerable<Album>;
        [DataMember]
        public IEnumerable<Decouverte> LesDecouvertes { get; set; } = GetTheCurrent.Mgr.Donnee.GetDecouvertes() as IEnumerable<Decouverte>;
        [DataMember]
        public Utilisateur User { get; set; } = GetTheCurrent.Mgr.Donnee.User;
        [DataMember]
        public IEnumerable<Musique> LesMusiques { get; set; } = GetTheCurrent.Mgr.Donnee.LesMusiques;
    }
}
