using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Jeu2Des
{
    [Serializable]
    [DataContract] 
    public class Classement
    { 
        // ////////////////////////////////////////DECLARATION DU TABLEAU (LISTE)        
        private List<Entree> _ListeEntrees;

        // /////////////////////////////////  ESSAI

        [DataMember]
        public List<Entree> ListeEntrees
        {
            get { return _ListeEntrees; } 
            //set { _ListeEntrees = value; }           
        }

        // ////////////////////////////////


        // ////////////////////////////////////////ZONE CONSTRUCTEUR
        public Classement()
        {                        
            // Instanciation de la liste
            _ListeEntrees = new List<Entree>();
        }

        // /////////////////////////////////////////ZONE METHODE
        public void AjouterEntree(string nom, int score)
        {
            _ListeEntrees.Add(new Entree(nom, score)); ////////////////////
        }

        public void ClassementJoueurs()
        {
          foreach (Entree E in ListeEntrees)
            {
                Console.WriteLine(E);
            }
        }        

        public void TopN()
        {
            ListeEntrees.Sort();
            ListeEntrees.Reverse();
            foreach (Entree player in ListeEntrees)
            {
                Console.WriteLine(player);
            }
        }
        
        // ///////////////////////////////////// SAUVEGARDE ET RESTAURATION BINAIRE  

        public void SauvegardeBinaire()
        {
            Stream fichierBin = File.Create("SauveBin.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fichierBin, _ListeEntrees);
            fichierBin.Close();
        }

        public void RestaureBinaire()
        {
            if (File.Exists("SauveBin.txt"))
            {
                Stream fichierBin2 = File.OpenRead("SauveBin.txt");
                BinaryFormatter serializer = new BinaryFormatter();
                Object obj = serializer.Deserialize(fichierBin2);

                Console.WriteLine(obj);
                List<Entree> playerBin = (List<Entree>) obj;
                
                foreach (Entree afficheBin in playerBin)
                {
                    Console.WriteLine(afficheBin);
                }
                fichierBin2.Close();
            }            
        }

        // ///////////////////////////////////// SAUVEGARDE ET RESTAURATION XML 

        public void SauvegardeXML()
        {
            Stream fichierXML = File.Create("SauveXML.xml");
            XmlSerializer serializer2 = new XmlSerializer(_ListeEntrees.GetType());
            serializer2.Serialize(fichierXML, _ListeEntrees);
            fichierXML.Close();
        }

        public void RestaureXML()
        {
            if (File.Exists("SauveXML.xml"))
            {
                Stream fichierXML2 = File.OpenRead("SauveXML.xml");
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Entree>));
                Object obj2 = serializer2.Deserialize(fichierXML2);  

                Console.WriteLine(obj2);
                foreach (Entree afficheXml in ((List<Entree>)obj2))
                {
                    Console.WriteLine(afficheXml);
                }
                fichierXML2.Close();
            }
        }

        // ///////////////////////////////////// SAUVEGARDE ET RESTAURATION JSON

        public void SauvegardeJSON()
        {
            Stream fichierJSON = File.Create("SauveJSON.json");

            DataContractJsonSerializer serializer =  new DataContractJsonSerializer(_ListeEntrees.GetType());
            serializer.WriteObject(fichierJSON, _ListeEntrees);
            fichierJSON.Close();

        }

        public void RestaureJSON()
        {
            if (File.Exists("SauveJSON.json"))
            {
                Stream fichierJSON2 = File.OpenRead("SauveJSON.json");
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Entree>));
                List<Entree> RecupFichierJson = (List<Entree>)serializer.ReadObject(fichierJSON2);

                foreach (var RecupJson in RecupFichierJson)
                {
                    Console.Out.WriteLine(RecupJson);
                }
                fichierJSON2.Close();
            }
        }
    }
}
