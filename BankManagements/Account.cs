using System;
using System.Collections.Generic;
using System.IO;

namespace BankManagements{
    
    public class Account{
        
        // variables

        private string firstName;
        private string lastName;

        protected string accountType;

        protected double solde;
        private double depot;
        private double retrait;
        private double diff;
        // Propiétés

        public string AccountType{
            get{
                return this.accountType;
            }
        }

        public double Solde{
            get{
                return this.solde;
            }
        }

        public double Depot{
            get{
                return this.depot;
            }set{
                this.depot = value;
            }
        }

        public double Retrait{
            get{
                return this.retrait;
            }set{
                this.retrait = value;
            }
        }

        public double Diff{
            get{
                return this.diff;
            }set{
                this.diff = value;
            }
        }

        //Constructeur Compte génral
        public Account(){

            firstName = "Vincent";
            lastName = "MICHEL";
        }
        // Affichage du menu 
        public void AfficherMenu(){

            Console.WriteLine("Veuillez sélectionner une option ci-dessous");
            Console.WriteLine("[I] Afficher les informations sur le titulaire du compte");
            Console.WriteLine("[CS] Compte courant - Consulter le solde");
            Console.WriteLine("[CD] Compte courant - Déposer des fonds");
            Console.WriteLine("[CR] Compte courant - Retirer des fonds");
            Console.WriteLine("[ES] Compte épargne - Consulter le solde");
            Console.WriteLine("[ED] Compte épargne - Déposer des fonds");
            Console.WriteLine("[ER] Compte épargne - Retirer des fonds");
            Console.WriteLine("[X] Quitter");
            
        }
        // Affichage du titulaire du compte 
        public string AccountInfo(){

            string accountInfo = ("Le propriétaire est : " + firstName + " " + lastName);
            return accountInfo;
        }

        // Solde avant depot ou retrait

        // public void SoldeGeneral(){
        //     solde = solde;
        // }
        
        // Depot
        
        public void SoldeDepot(double montant){
            depot = montant;
            solde = solde + depot;
        }

        // Retrait

        public void SoldeRetrait(double montant){
            retrait = montant;
            solde = solde - retrait;
            // diff = retrait - solde;
    
            // if(solde < 0){
            //     Console.WriteLine(Math.Abs(diff));
            // }else{
            //     Console.WriteLine(solde);
            // }
        }

        public void SoldeInfZero(double montant){
            diff = montant - solde;
        }

        public void SoldeRetraitZero(double montant){
            diff = montant;
            solde = solde - retrait + diff;
        }

        public void WriteResume(IList<string> transactions, string fileName){
            using(StreamWriter resume = new StreamWriter(fileName + ".txt", true)){
                foreach (string transaction in transactions)
                {
                    resume.WriteLine(transaction);
                }
            }
        }
    }
}