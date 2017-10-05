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

        // Comparaison des scores pour l'affichage du " TopN "
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
                // return 0; // Affiche un "ZERO" pour préciser  : N'est pas un objet
            }
        }
        
        // ///////////////////////////////////////////////////ZONE PROPERTY
        public string Nom { get; set; }
        
        public int Score { get; set; }

        // ////////////////////////////////////////////////////ZONE CONSTRUCTEUR

        public Entree()
        {
            this.Nom = "Stephan";
            this.Score = 100;
        }

        // Récupération du nom et du score du joueur
        public Entree(string nom, int score)
        {
            this.Nom = nom;
            this.Score = score;
        }

        public override string ToString()
        {
            return "Le joueur : " + Nom + " a obtenu le score " + Score;
        }
    }
}
