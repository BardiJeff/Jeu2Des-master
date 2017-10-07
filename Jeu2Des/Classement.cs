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
    public abstract class Classement
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

        // ///////////////////////////////////// SAUVEGARDE ET RESTAURATION

        public abstract void Sauvegarde();

        public abstract void Restaure();
                
    }
}
