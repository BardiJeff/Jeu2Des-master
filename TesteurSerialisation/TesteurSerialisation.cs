using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeu2Des;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TesteurSerialisation
{
    //[DataContract]
    class Program
    {        
        static void Main(string[] args)
        {            

            List<Entree> NewListe = new List<Entree>();

            NewListe.Add(new Entree("Mathieu", 50));
            NewListe.Add(new Entree("Jeff", 100));
            NewListe.Add(new Entree("Stephan", 50));
            NewListe.Add(new Entree("Mathieu", 50));
            NewListe.Add(new Entree("Ghislaine", 70));


            //// ///////////////////////////////////////////////////////  BINAIRE  //////////
            //// SAUVEGARDE
            //Stream fichierBin = File.Create("SauveBin.txt");
            //BinaryFormatter serializer = new BinaryFormatter();
            //serializer.Serialize(fichierBin, NewListe);
            //fichierBin.Close();

            //// RESTAURATION
            //Stream fichierBin2 = File.OpenRead("SauveBin.txt");
            //BinaryFormatter serializer2 = new BinaryFormatter();
            //Object obj = serializer2.Deserialize(fichierBin2);

            //Console.WriteLine(obj);
            //Entree playerBin = (Entree)obj;
            //playerBin.Nom.ToUpper();
            //playerBin.Score.ToString();

            //// ///////////////////////////////////////////////////////  XML  //////////
            //// SAUVEGARDE
            //Stream fichierXML = File.Create("SauveXML.xml");
            //XmlSerializer serializer3 = new XmlSerializer(NewListe.GetType());
            //serializer3.Serialize(fichierXML, NewListe);
            //fichierXML.Close();


            // /////////////////////////////////////////////////////// JSON /////////////
            //Stream fichierJSON = File.Create("SauveJSON.json");
            //DataContractJsonSerializer serializer  new DataContractJsonSerializer(NewListe.GetType());
            //serializer.writeObject(fichierJSON, NewListe);
            //fichierJSON.Close();
        }
    }
}
