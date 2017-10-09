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
    
    [Serializable] // "Serializable" Décoration donnant accès à la possibilité de sauvegarder dans un fichier....    
    [DataContract] // "DataContract" Décoration spécifique à la sauvegarde de "JSON"
    public abstract class Classement // Classe ABSTRACT
    { 
        // Déclaration de la liste (LIST fortement typée)        
        private List<Entree> _ListeEntrees;        

        [DataMember]
        public List<Entree> ListeEntrees
        {
            get { return _ListeEntrees; } 
            //set { _ListeEntrees = value; }           
        }
        
        // ////////////////////////////////////////ZONE CONSTRUCTEUR
        // Constructeur par défaut dans lequel on instancie la LISTE
        public Classement()
        {                        
            // Instanciation de la liste
            _ListeEntrees = new List<Entree>();
        }

        // /////////////////////////////////////////ZONE METHODE

        // Méthode "AjouterEntree" permet l'ajout des joueurs et de leurs scores dans la LISTE
        public void AjouterEntree(string nom, int score)
        {
            _ListeEntrees.Add(new Entree(nom, score)); 
        }

        // Méthode "ClassementJoueurs" - Boucle permettant de dérouler le contenu de la LISTE
        public void ClassementJoueurs()
        {
          foreach (Entree E in ListeEntrees)
            {
                Console.WriteLine(E);
            }
        }

        // Méthode "TopN" Permettant de : 
        // - Comparer avec "SORT3 suite à l'implémentation de l'interface IComparable
        // - Inverser avec "Reverse" les éléments de la LISTE
        // - Afficher le contenu de la LISTE 
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

        // Méthodes permettant d'effectuer la Sauvegarde et la Restauration du résultat ( LISTE)
        // Méthodes "vides" dans une classe "Abstract
        public abstract void Sauvegarde();

        public abstract void Restaure();
                
    }
}
