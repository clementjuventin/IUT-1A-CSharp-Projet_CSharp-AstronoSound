using AstronoSound;
using AstronoSound.Attributs;
using AstronoSound.ListesDeMusiques;
using Modele;
using Modele.AstronoSound.Utils;
using StubTest;
using System;
using System.Collections.Generic;

namespace AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Persistance.ChargerDonnee("dataProjet");

            StubTest.DonneeBrutte.CreerUtilisateur();
            StubTest.DonneeBrutte.CreerDesPlaylist();

            Persistance.SauvegarderDonee("dataProjet");
            */
            TestsUnitaires tu = new TestsUnitaires();
            Console.WriteLine(tu.InitialisationDuManager());
        }
    }
}
