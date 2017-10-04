using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace Jeu2Des
{
    public class Classement 
    {
        // ////////////////////////////////////////DECLARATION DU TABLEAU (LISTE)        
        private List<Entree> _ListeEntrees;

        // /////////////////////////////////  ESSAI

        public List<Entree> ListeEntrees
        {
            get { return _ListeEntrees; }            
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
            ListeEntrees.Add(new Entree(nom, score));
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
            //foreach (KeyValuePair<int, string> scoreNom in entrees)
            //{                
                
            //    // Console.WriteLine("Résultat : ", scoreNom);
            //}
        } 
    }
}
