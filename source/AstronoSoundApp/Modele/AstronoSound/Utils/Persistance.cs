using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace Modele.AstronoSound.Utils
{
    public static class Persistance
    {
        public static DataPersistance ChargerDonnee(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            DataPersistance data;
            var serialiser = new DataContractSerializer(typeof(DataPersistance));
            using (Stream s = File.OpenRead(path))
            {
                data = serialiser.ReadObject(s) as DataPersistance;
            }
            return data;
        }
        public static void SauvegarderDonee(string path)
        {
            DataPersistance data = new DataPersistance();
            var settings = new XmlWriterSettings() { Indent = true };
            var serialiser = new DataContractSerializer(typeof(DataPersistance));
            using (TextWriter s = File.CreateText(path))
            {
                using (XmlWriter writer = XmlWriter.Create(s, settings))
                {
                    serialiser.WriteObject(writer, data);
                }
            }
        }
    }
}
