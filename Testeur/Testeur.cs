using System;
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

            Console.WriteLine("Veuillez saisir votre prénom");
            string prenom = Console.ReadLine();

            Console.WriteLine("Bonjour " + prenom + " , Veuillez appuyez sur une touche pour passer à l'étape suivante \n" );
            Console.ReadKey();


            //  SAUVEGARDE - choix de la méthode
            Console.WriteLine("Veuillez choisir une méthode de sauvegarde");
            Console.WriteLine("\n Tapez 1 : Sauvegarde Binaire\n Tapez 2 : Sauvegarde XML\n Tapez 3 : Sauvegarde JSON ");
            int choixUser =  Convert.ToInt32(Console.ReadLine()); ////////// TESTER LA VALEUR ////////////////////
            
            MonJeu.ChoixSauve(choixUser);

            Console.WriteLine("\n --------------- INITIAL --------------- \n");

            //Jouons quelques parties ....
            MonJeu.JouerPartie();                   //1ere partie avec un joueur par défaut
            MonJeu.JouerPartie();                   //2eme partie avec un joueur par défaut
            MonJeu.JouerPartie("David");            //3eme partie
            MonJeu.JouerPartie("David");            //Encore une partie  
            MonJeu.JouerPartie("Sarah");            //Encore une partie 
            MonJeu.JouerPartie("Lucie");            //Encore une partie
            MonJeu.JouerPartie();                   //Encore une partie 
            MonJeu.JouerPartie(prenom);

            //Console.WriteLine("\n -------------------------------------- \n");

            //MonJeu.VoirClassement();

            //Console.WriteLine("\n -------------- CLASSEMENT --------------- \n");

            //MonJeu.VoirClassement();            

            Console.WriteLine("\n -------------- TOP N ------------------- \n");
            Console.WriteLine("\n Etes vous présent dans le score final ?? \n\n");
            MonJeu.ClassementJoueurTop();

            //MonJeu.Quitter();

            Console.ReadKey();            
        }
    }
}
