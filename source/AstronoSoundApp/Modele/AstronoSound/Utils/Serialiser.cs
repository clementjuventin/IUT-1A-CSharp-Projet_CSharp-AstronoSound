using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Modele.AstronoSound.Utils
{
    public static class Serialiser<T> where T: class 
    {
        public static void SerialiserListe(List<T> liste, string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            StreamWriter writer = new StreamWriter(file, false);
            serializer.Serialize(writer, liste);
            writer.Close();
        }
        public static List<T> DeserialiserListe(string file)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            StreamReader reader = new StreamReader(file);
            List<T> liste = (List<T>)serializer.Deserialize(reader);
            reader.Close();
            return liste;
        }
    }
}
