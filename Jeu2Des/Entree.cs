using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeu2Des;

namespace Jeu2Des
{
    public class Entree 
    {
        // ///////////////////////////////////////////////////ZONE PROPERTY
        public string Nom { get; set; }
        
        public int Score { get; set; }
        
        // ////////////////////////////////////////////////////ZONE CONSTRUCTEUR

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
