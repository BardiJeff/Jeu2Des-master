﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Jeu2Des;


namespace Testeur
{
    class Testeur
    {
        
        public static void Main(string[] args)
        {
                       
            //Le jeu est crée (avec ses 2 des et son classement)
            Jeu MonJeu = new Jeu();

            Console.WriteLine("\n --------------- INITIAL --------------- \n");

            //Jouons quelques parties ....
            MonJeu.JouerPartie();                   //1ere partie avec un joueur par défaut
            MonJeu.JouerPartie();                   //2eme partie avec un joueur par défaut
            MonJeu.JouerPartie("David");            //3eme partie
            MonJeu.JouerPartie("David");            //Encore une partie  
            MonJeu.JouerPartie("Sarah");            //Encore une partie 
            MonJeu.JouerPartie("Lucie");            //Encore une partie
            MonJeu.JouerPartie();                   //Encore une partie 
            MonJeu.JouerPartie("Jeff");

            //Console.WriteLine("\n ---------------------------- \n");

            //MonJeu.VoirClassement();

            Console.WriteLine("\n ------------ CLASSEMENT ---------------- \n");

            MonJeu.ClassementJoueurs2();

            Console.WriteLine("\n -------------- TOP N ------------------- \n");
            MonJeu.ClassementJoueurTop();

            
            // ---------------------------Serializer Binaire  -------------------");
            // Sauvegarde
            MonJeu.SauvegardeBin();
            Console.WriteLine("\n -------------- Restauration BINAIRE ----- \n");
            // Restauration
            MonJeu.RestaureBin();

            // ---------------------------Serializer XML  -------------------");
            // Sauvegarde
            MonJeu.SauvegardeXml();
            Console.WriteLine("\n -------------- Restauration XML ---------- \n");
            // Restauration
            MonJeu.RestaureXml();

            // ---------------------------Serializer JSON  -------------------");
            // Sauvegarde
            MonJeu.SauvegardeJson();
            Console.WriteLine("\n -------------- Restauration JSON ---------- \n");
            // Restauration
            MonJeu.RestaureJson();


            Console.ReadKey();            
        }
    }
}
