using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace AstronoSound.Attributs
{
    public class Artiste:IEquatable<Artiste>
    {
        //Attributs
        private string nomArtiste;


        //Accesseurs
        public string NomArtiste { get { return nomArtiste; } set { nomArtiste = value; } }

        //Constructeurs
        public Artiste()
        {
            nomArtiste = "";
        }
        public Artiste(string nomArtiste)
        {
            this.nomArtiste = nomArtiste;
        }

        //Redéfinitions
        public override string ToString()
        {
            return NomArtiste;
        }
        //IComparable
        public bool Equals(/*[AllowNull]*/ Artiste other)
        {
            return other.NomArtiste.Equals(nomArtiste);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(obj, this)) return true;
            if (GetType() != obj.GetType()) return false;
            return Equals(obj as Artiste);
        }
    }
}
