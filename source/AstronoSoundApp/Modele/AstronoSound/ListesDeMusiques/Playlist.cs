using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using AstronoSound.Attributs;

namespace AstronoSound.ListesDeMusiques
{
	[DataContract]
	public abstract class Playlist: IEquatable<Playlist>, INotifyPropertyChanged
	{
		//Attributs
		[DataMember]
		private string titre;       //Titre de la playlist
		[DataMember]
		private string description; //Description de la playlist
		[DataMember]
		private string photo;       //Chemin de la miniature | peut être faudrait il faire une classe spéciale
		[DataMember]
		private int nombreVisions;  //Nombre de fois ou l'utilisateur a ouvert la playlist
		[DataMember]
		private Genre? genre;       //Genre musicale de la playlist
		[DataMember]
		protected ObservableCollection<Musique> lesMusiques;    //Liste des musiques contenues dans la playlist
		private string nombreDeMusique;
		public Musique selectedMusic;

		/// <summary>
		/// Implémentation de INotifyPropertyChanged
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		void OnPropertyChanged([CallerMemberName] string propertyName = "")
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		//Constructeur
		public Playlist(string titre, string description, string photo, Genre? genre)
		{
			this.titre = titre;
			this.description = description;
			this.photo = photo;
			this.genre = genre;
			nombreVisions = 0;
			lesMusiques = new ObservableCollection<Musique>();
			NombreDeMusique = NombreDeMusique;
		}
		public Playlist() { }


		//Accesseurs
		public string Titre { get { return titre; } set { titre = value; } }
		public string Description { get { return description; } set { description = value; } }
		public string Photo { get { return photo; } set { photo = value; } }
		public Genre? Genre { get { return genre; } set { genre = value; } }
		public int NombreVisions 
		{
			get
			{
				return nombreVisions;
			}
			set
			{
				nombreVisions = value;
				OnPropertyChanged();
			} 
		}
		public ObservableCollection<Musique> LesMusiques { get { return lesMusiques; } set { lesMusiques = value; } }
		public Musique SelectedMusic
		{
			get { return selectedMusic; }
			set
			{
				selectedMusic = value;
				OnPropertyChanged();
			}
		}
		public string NombreDeMusique
		{
			get
			{
				return LesMusiques.Count.ToString();
			}
			set
			{
				nombreDeMusique = value;
				OnPropertyChanged();
			}
		}


		//Méthodes
		/// <summary>
		/// Ajoute une musique dans la playlist.
		/// </summary>
		/// <param name="musique"></param>
		public void AjouterMusique(Musique musique)
		{
			lesMusiques.Add(musique);
		}
		/// <summary>
		/// Supprime une musique de la playlist
		/// </summary>
		/// <param name="musique"></param>
		public void SupprimerUneMusique(Musique musique)
		{
			lesMusiques.Remove(musique);
		}

		//Redéfinitions
		public override string ToString()
		{
			string message = $"\nTitre: {Titre},\nDescription: {Description},\nGenre: {genre},\nPhoto: {Photo}\n";
			if (lesMusiques.Count == 0)
			{
				message+="\nPlaylist vide.\n";
			}
			else
			{
				for (int i = lesMusiques.Count-1; i >= 0; i--)//Affichage de la plus récente à la plus vielle musique ajoutée.
				{
					message+=lesMusiques[i]+"\n";
				}
			}
			Console.Write("---------------------------------------------------\n");
			return message;
		}

		/// <summary>
		/// Implémente IEquatable<Playlist>
		/// Se base sur le titre de la playlist
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
		public bool Equals(/*[AllowNull]*/ Playlist other)
		{
			return other.Titre.Equals(titre);
		}
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(obj, null)) return false;
			if (ReferenceEquals(obj, this)) return true;
			if (GetType() != obj.GetType()) return false;
			return Equals(obj as Playlist);
		}
	}
}
