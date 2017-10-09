using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jeu2Des;
using System.Collections;

namespace Jeu2Des
{
    /// <summary>
    /// La classe Jeu décrit un jeu de Dés très simple. 
    /// Le jeu comprend 2 dés et un classement pour enregistrer les scores des joueur
    /// Quand un joueur fait une partie : il indique son nom puis il lance les 2 dés 10 fois de suite
    /// A chaque lancer, si le total des dés est égal à 7 ==> le joueur marque 10 points à son score
    /// Une fois la partie terminée le nom du joeur et son score sont enregistrés dans le classement 
    /// </summary>   
     public class Jeu 
    {       

        // Lien avec la classe " Joueur "  
        private Joueur _Joueur;


        private Classement sauvegarde; // Permet l'instanciation des classes Binaire, XML et JSONdans le " SWITCH "

        // Lien avec la classe " Binaire " - " XML " - " JSON "
        //private Binaire Binaire;
        //private XML  XML;
        //private JSON JSON;

        /// <summary>
        /// Représente le joueur courant (celui qui joue une partie)
        /// </summary>
        /// <returns>Le joueur de la partie ou null si aucune partie n'est démarrée</returns>        
        public Joueur Joueur
        {
            get{return _Joueur;}       
        }
    
        // Création (Instanciation) des Dés au nombre de deux (Tableau)
        private De[] _Des = new De[2];


        // ////////////////////// ZONE CONSTRUCTEUR

        /// <summary>
        /// Crée un jeu de 2 Dés avec un classement
        /// </summary> 
        public Jeu()
        {
            // A la création du jeu : (Instanciation) des classes  " Binaire " - " XML " - " JSON " déclarés en ligne 23 - 24 - 25           
            //Binaire = new Binaire();
            //XML = new XML();
            //JSON = new JSON();

            //A la création du jeu : les 2 dés sont crées 
            //On aurait pu créer les 2 Des juste au moment de jouer  
            _Des[0] = new De();
            _Des[1] = new De();
        }
        // /////////////////////////////////// ZONE METHODES


        public void ChoixSauve(int choix)
        {
            // Sélection du choix utilisateur pour le tupe de sauvegarde          
            int? test = choix;
            
                switch (choix)
                {
                    case 1:
                        sauvegarde = new Binaire();
                        break;

                    case 2:
                        sauvegarde = new XML();
                        break;

                    default:
                        sauvegarde = new JSON();
                        break;
                }   

            
            sauvegarde.Sauvegarde(); // Lancement de la méthode " Sauvegarde " pour la classe choisie
        } 

        /// <summary>
        /// Permet de faire une partie du jeu de dés en indiquant le nom du joueur
        /// </summary>
        /// <param name="nom">Le nom du joueur</param>
        public void JouerPartie(string nom)
        {
            //Le joueur est créé quand la partie démarre
            _Joueur = new Joueur(nom);            

            //On fait jouer le joueur en lui passant les 2 dés
            int resultat = _Joueur.Jouer(_Des);

            // Ajout des joueurs et scores pour chaque type de fichier
            sauvegarde.AjouterEntree(_Joueur.Nom, resultat);
        }

        /// <summary>
        /// Permet de faire une partie du jeu de dés
        /// Le nom du joueur n'est pas donnée en entrée : il sera généré exemple : Joueur 1, Joueur 2, ...  
        /// </summary>        
        public void JouerPartie()
        {
            //Le joueur est créé quand la partie démarre
            _Joueur = new Joueur();

            //Le joueur Joue et on récupère son score
            int resultat = _Joueur.Jouer(_Des);

            // Ajout des joueurs et scores pour chaque type de fichier
            sauvegarde.AjouterEntree(_Joueur.Nom, resultat);
        }

        // Accès à la méthode " ClassementJoueurs " de la classe " Classement " 
        public void VoirClassement()
        {
            sauvegarde.ClassementJoueurs();           
        }

        // Accès à la méthode " TopN " de la classe " Classement " 
        public void ClassementJoueurTop()
        {
            //Console.WriteLine(" Classement Top N ");
            sauvegarde.TopN();
        }

        // Méthode " QUITTER " qui sort du jeu et affiche la restauration dans le type de sauvegarde choisi

        public void Quitter()
        {
            Environment.Exit(0);
            sauvegarde.Restaure();
        }        
    }
}
