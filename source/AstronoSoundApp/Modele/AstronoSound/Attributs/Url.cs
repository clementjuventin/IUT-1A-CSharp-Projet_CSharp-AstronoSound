using System;
using System.Collections.Generic;
using System.Text;

namespace AstronoSound.Attributs
{
	public class Url
    {
		//Attributs
		private string adresse;		//Adresse http/https


		//Constructeur
		public Url()
		{
			adresse = "";
		}
		public Url(string url)
		{
			if (url.Contains("&list="))
			{
				url = url.Remove(url.LastIndexOf("&list="));
			}
			adresse = url;
		}

		//Accesseurs
		public string Adresse { get { return adresse; } set { adresse = value; } }

		//Redéfinitions
		public override string ToString()
		{
			return adresse;
		}
	}
}
