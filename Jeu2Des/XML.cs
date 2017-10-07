using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Jeu2Des
{

    public class XML : Classement // Hérite de la classe Classement
    {
        //  CONSTRUCTEUR

        public XML() { }

        // METHODES

        // Redéfinition de la méthode Sauvegarde de la classe mère : Classement (Abstract)
        public override void Sauvegarde()
        {
            Stream fichierXML = File.Create("SauveXML.xml");
            XmlSerializer serializer2 = new XmlSerializer(ListeEntrees.GetType());
            serializer2.Serialize(fichierXML, ListeEntrees);
            fichierXML.Close();
        }

        // Redéfinition de la méthode Restaure de la classe mère : Classement (Abstract)
        public override void Restaure()
        {
            if (File.Exists("SauveXML.xml"))
            {
                Stream fichierXML2 = File.OpenRead("SauveXML.xml");
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Entree>));
                Object obj2 = serializer2.Deserialize(fichierXML2);

                // Console.WriteLine(obj2);
                foreach (Entree afficheXml in ((List<Entree>)obj2))
                {
                    Console.WriteLine(afficheXml);
                }
                fichierXML2.Close();
            }
        }

    }
}
