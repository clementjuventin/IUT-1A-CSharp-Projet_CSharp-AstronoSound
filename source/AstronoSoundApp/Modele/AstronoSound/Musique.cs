using AstronoSound;
using AstronoSound.Attributs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AstronoSound
{
	[DataContract]
	public class Musique: IEquatable<Musique>
	{
		//Attributs
		[DataMember]
		private string titre;           //Titre de la musique
		[DataMember]
		private List<Artiste> lesArtistes;      //Artiste auteur de la musique
		[DataMember]
		private Genre? genre;           //Genre musicale de la musique
		[DataMember]
		private Url? url;				//Url de la musique

		public string LesArtistesToString
		{
			get
			{
				return String.Join(", ", LesArtistes);
			}
		} //Retourne la liste des artistes avec linq


		//Constructeur
		public Musique(string titre, List<Artiste> lesArtistes, Genre? genre, Url? url)
		{
			this.lesArtistes = new List<Artiste>();
			this.titre = titre;
			this.lesArtistes = lesArtistes;
			this.genre = genre;
			this.url = url;
		}
		public Musique(Musique m)
		{
			this.lesArtistes = new List<Artiste>();
			this.titre = m.Titre;
			this.lesArtistes = m.LesArtistes;
			this.genre = m.Genre;
			this.url = m.Url;
		}
		public  Musique(string titre, List<Artiste> lesArtistes, Url? url)
		{
			this.lesArtistes = new List<Artiste>();
			this.titre = titre;
			this.lesArtistes = lesArtistes;
			this.url = url;
		}
		public Musique() 
		{
			this.lesArtistes = new List<Artiste>();
			this.titre = "";
			this.genre = null;
			this.url = null;
		}

		//Accesseurs
		public string Titre { get { return titre; } set { titre = value; } }
		public Genre? Genre { get { return genre; } set { genre = value; } }
		public Url? Url { get { return url; } set { url = value; } }
		public List<Artiste> LesArtistes { get { return lesArtistes; } set { lesArtistes = value; } }


		//Redéfinitions
		public override string ToString()
		{
			string message = $"\nTitre: {Titre},\nArtiste: ";
			foreach(Artiste artiste in lesArtistes)
			{
				message += $"{artiste} ";
			}			
			message += $"\nGenre: {genre?.ToString()},\nUrl: {url?.Adresse}\n";
			return message;
		}

		/// <summary>
		/// La méthode Equals le la classe Musique se base sur:
		/// 1- Un titre identique
		/// 2- Une liste d'Artiste qui comporte les mêmes artistes (peu importe leur place dans la liste)
		/// </summary>
		/// <example>
		/// <code>
		/// Musique mus1 = new Musique("Musique1", new List<Artiste>() { new Artiste("A1"), new Artiste("A2") }, "21 jun", new Url("test"));
		///	Musique mus2 = new Musique("Musique1", new List<Artiste>() { new Artiste("A2"), new Artiste("A1") }, "24 jun", new Url("test"));
		///	Console.WriteLine(mus1.Equals(mus2) ? "true" : "false");
		/// </code>
		/// Sortie: true
		/// </example>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(/*[AllowNull]*/ Musique other)
		{
			bool isEqual = other.Titre.Equals(titre);
			isEqual = isEqual && other.LesArtistes.Count==lesArtistes.Count;

			if (isEqual == false) { return isEqual; }

			foreach (Artiste a in LesArtistes)
			{
				if (!other.LesArtistes.Contains(a))
				{
					return false;
				}
			}
			return true;
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, null)) return false;
			if (ReferenceEquals(obj, this)) return true;
			if(GetType() != obj.GetType()) return false;
			return Equals(obj as Musique); 
		}
	}
}
