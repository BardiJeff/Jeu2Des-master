using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Jeu2Des
{
    public class JSON : Classement // Hérite de la classe Classement
    {
        //  CONSTRUCTEUR

        //public JSON() { }

        // METHODES

        // Redéfinition de la méthode Sauvegarde de la classe mère : Classement (Abstract)
        public override void Sauvegarde()
        {
            Stream fichierJSON = File.Create("SauveJSON.json");

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(ListeEntrees.GetType());
            serializer.WriteObject(fichierJSON, ListeEntrees);
            fichierJSON.Close();

        }

        // Redéfinition de la méthode Restaure de la classe mère : Classement (Abstract)
        public override void Restaure()
        {
            if (File.Exists("SauveJSON.json"))
            {
                Stream fichierJSON2 = File.OpenRead("SauveJSON.json");
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Entree>));
                List<Entree> RecupFichierJson = (List<Entree>)serializer.ReadObject(fichierJSON2);

                foreach (var RecupJson in RecupFichierJson)
                {
                    Console.Out.WriteLine(RecupJson);
                    AjouterEntree(RecupJson.Nom, RecupJson.Score);
                }
                fichierJSON2.Close();
            }
        }
    }
}
