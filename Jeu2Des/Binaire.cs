using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Jeu2Des
{
    
    public class Binaire : Classement // Hérite de la classe Classement
    {
        //  CONSTRUCTEUR        
        public Binaire() { }

        // METHODES
        
        // Redéfinition de la méthode Sauvegarde de la classe mère : Classement (Abstract)
        public override void Sauvegarde()
        {
            Stream fichierBin = File.Create("SauveBin.txt");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fichierBin, ListeEntrees);
            fichierBin.Close();
        }

        // Redéfinition de la méthode Restaure de la classe mère : Classement (Abstract)
        public override void Restaure()
        {
            if (File.Exists("SauveBin.txt"))
            {
                Stream fichierBin2 = File.OpenRead("SauveBin.txt");
                BinaryFormatter serializer = new BinaryFormatter();
                Object obj = serializer.Deserialize(fichierBin2);

                // Console.WriteLine(obj);
                List<Entree> playerBin = (List<Entree>)obj;

                foreach (Entree afficheBin in playerBin)
                {
                    Console.WriteLine(afficheBin);
                }
                fichierBin2.Close();
            }
        }
    }
}
