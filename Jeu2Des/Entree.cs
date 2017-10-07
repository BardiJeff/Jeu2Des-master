using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeu2Des;

namespace Jeu2Des
{
    [Serializable]
    public class Entree : IComparable
    {

        // Suite à l'implémentation de l'Interface " IComparable" - Pour la comparaison des scores pour l'affichage du " TopN "
        public int CompareTo(object obj)
        {
            Entree autre = obj as Entree;
            if (autre != null)
            {
                return this.Score.CompareTo(autre.Score);
            }
            else
            {
                throw new ArgumentException("L'objet n'est pas un score !"); // Génère une EXCEPTION
            }
        }
        
        // ///////////////////////////////////////////////////     ZONE PROPERTY
        // Déclaration des propriétés - utilisées tout au long de la partie par les autres classes
        // Déclaration en écriture condensée
        public string Nom { get; set; }
        
        public int Score { get; set; }

        // ////////////////////////////////////////////////////    ZONE CONSTRUCTEUR

        // Déclaration du constructeur par défaut avec paramètres en "Dur"
        public Entree()
        {
            this.Nom = "Stephan";
            this.Score = 100;
        }

        // Déclaration d'un constructeur avec paramètres
        // Récupération du nom et du score du joueur
        public Entree(string nom, int score)
        {
            this.Nom = nom;
            this.Score = score;
        }

        // ////////////////////////////////////////////////////  ZONE METHODES

        // Redéfinition de la méthode ToString
        public override string ToString()
        {
            return "Le joueur : " + Nom + " a obtenu le score " + Score;
        }
    }
}
