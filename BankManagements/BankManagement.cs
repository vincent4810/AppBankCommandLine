using System;
using System.Collections.Generic;

namespace BankManagements{

    class BankManagement{

        static void Main(string[] args){
            
            Account account = new Account();
            CurrentAccount currentAccount = new CurrentAccount(2500);
            SaveAccount saveAccount = new SaveAccount();
            
            IList<string> resumeCurrentAccount = new List<string>();
            IList<string> resumeSaveAccount = new List<string>();

            resumeCurrentAccount.Add(currentAccount.AccountType);
            resumeCurrentAccount.Add(currentAccount.AccountInfo());

            resumeSaveAccount.Add(saveAccount.AccountType);
            resumeSaveAccount.Add(saveAccount.AccountInfo());


            string userChoice = "";

            do{
                string depotCurrentAccount = ($"Depot de : {currentAccount.Depot} à {DateTime.Now.ToString()} solde actuel : {currentAccount.Solde}");

                string retraitCurrentAccount = ($"Retrait de : {currentAccount.Retrait} à {DateTime.Now.ToString()} Solde actuel : {currentAccount.Solde}");

                string depotSaveAccount = ($"Depot de : {saveAccount.Depot} à {DateTime.Now.ToString()} solde compte courant : {currentAccount.Solde} et solde compte épargne {saveAccount.Solde}");

                string retraitSaveAccount = ($"Retrait de : {saveAccount.Retrait} à {DateTime.Now.ToString()} solde compte courant : {currentAccount.Solde} et solde compte épargne {saveAccount.Solde}");

                if(currentAccount.Depot > 0){
                   resumeCurrentAccount.Add(depotCurrentAccount);
                   
                   currentAccount.Depot = 0;
                }

                if(currentAccount.Retrait < currentAccount.Solde && currentAccount.Retrait != 0){
                    resumeCurrentAccount.Add(retraitCurrentAccount);

                    currentAccount.Retrait = 0;
                }

                if(saveAccount.Depot < currentAccount.Solde && saveAccount.Depot != 0){
                    resumeSaveAccount.Add(depotSaveAccount);

                    saveAccount.Depot = 0;
                }

                // if(saveAccount.Retrait < saveAccount.Solde && saveAccount.Retrait != 0){
                //     resumeSaveAccount.Add(retraitSaveAccount);
                
                //     saveAccount.Retrait = 0;
                // }



            Console.WriteLine("Appuyez sur Entrée pour afficher le menu.");
            Console.ReadLine();
            account.AfficherMenu();
            
            userChoice = Console.ReadLine();

                switch(userChoice.ToUpper()){
                // Affichage titulaire compte
                    case "I":
                        Console.Clear();

                        Console.WriteLine(account.AccountInfo());                        
                        
                        break;
                
                // Affichage solde compte courant
                
                    case "CS":
                        Console.Clear();
                        
                        Console.WriteLine("Le solde du compte courant est de : " + currentAccount.Solde + " €");
                        
                        break;
                
                // Depot argent compte courant
                
                    case "CD":
                        Console.Clear();

                        Console.WriteLine("Quel montant souhaitez- vous déposez sur le compte courant : ");

                        currentAccount.Depot = double.Parse(Console.ReadLine());

                        currentAccount.SoldeDepot(currentAccount.Depot);

                        Console.WriteLine("Vous avez déposé " + currentAccount.Depot + " € et votre nouveau solde courant est de " + currentAccount.Solde );
                        
                        break;
                
                // Retrait argent compte courant        
                
                    case "CR":
                        Console.Clear();

                        Console.WriteLine("Quel montant souhaitez-vous retirer de votre compte courant: ");
                        
                        currentAccount.Retrait = double.Parse(Console.ReadLine());
                        
                        if(currentAccount.Retrait > currentAccount.Solde){
                            currentAccount.SoldeInfZero(currentAccount.Retrait);
                            
                            Console.WriteLine("Votre retrait est plus important que votre solde courant de " + currentAccount.Diff + " € ");
                            
                            Console.WriteLine("Le retrait maximum est de "+ currentAccount.Solde +" €");

                            currentAccount.SoldeRetraitZero(currentAccount.Diff);
                            
                            Console.WriteLine("le nouveau solde courant est de " + currentAccount.Solde + " €");

                        }else{

                            currentAccount.SoldeRetrait(currentAccount.Retrait);
                            
                            Console.WriteLine("Vous avez retiré " + currentAccount.Retrait + " € et votre nouveau solde courant est de " + currentAccount.Solde );

                        }
                            // resumeCurrentAccount.Add(retraitCurrentAccount);
                        break;
                // Affichage solde compte Epargne
                    case "ES":
                        Console.Clear();

                        Console.WriteLine("Le solde du compte épargne est de : " + saveAccount.Solde + " €");
                        
                        break;
                // Depot argent compte Epargne
                    case "ED":
                        Console.Clear();
                        
                        Console.WriteLine("Quel montant souhaitez- vous déposez sur le compte épargne : ");
                        
                        saveAccount.Depot = double.Parse(Console.ReadLine());
                        
                        if(saveAccount.Depot > currentAccount.Solde){
                            
                            currentAccount.SoldeInfZero(saveAccount.Depot);

                            Console.WriteLine("Votre dépot sur le compte épargne est supérieur à votre solde du compte courant de " + currentAccount.Diff + " €");

                            saveAccount.SoldeDepot(currentAccount.Solde);
                            currentAccount.SoldeRetrait(currentAccount.Solde);
                            Console.WriteLine("Votre solde d'épargne est de " + saveAccount.Solde + " € et votre solde courant de " + currentAccount.Solde + " €");

                        }else{

                            currentAccount.SoldeRetrait(saveAccount.Depot);
                            
                            saveAccount.SoldeDepot(saveAccount.Depot);
                            
                            Console.WriteLine("Vous avez retirer " + saveAccount.Depot +" € de votre compte courant pour la tranférer sur l'épargne. Votre nouveau solde courant est de : " + currentAccount.Solde + " €");
                            
                            Console.WriteLine("Votre solde d'épargne est de : " + saveAccount.Solde + " €");
                            
                        }

                        // resumeSaveAccount.Add(depotSaveAccount);
                        
                        break;
                // Retrait argent compte Epargne
                    case "ER":
                        Console.Clear();
                        
                        Console.WriteLine("Quel montant souhaitez vous retirer du compte épargne : ");
                        
                        saveAccount.Retrait = double.Parse(Console.ReadLine());
                        
                        if(saveAccount.Retrait > saveAccount.Solde){
                            saveAccount.SoldeInfZero(saveAccount.Retrait);

                            Console.WriteLine("Votre retrait est plus important que votre solde epargne de " + saveAccount.Diff + " €");

                            Console.WriteLine("Le retrait maximim est de " + saveAccount.Solde + " €");

                            currentAccount.SoldeDepot(saveAccount.Solde);

                            saveAccount.SoldeRetraitZero(saveAccount.Diff);
                            
                            Console.WriteLine("le nouveau solde épargne est de " + saveAccount.Solde + " €");

                        }else{

                            saveAccount.SoldeRetrait(saveAccount.Retrait);
                            
                            currentAccount.SoldeDepot(saveAccount.Retrait);
                            
                            Console.WriteLine("Vous avez retirez " + saveAccount.Retrait + " € du compte épargne pour la transférer sur le compte courant. Votre nouveau solde d'épargne est de : " + saveAccount.Solde + " €" );
                            
                            Console.WriteLine("Votre solde courant est de de : " + currentAccount.Solde + " €");                        
                        }

                            resumeSaveAccount.Add(retraitSaveAccount);

                        
                        break;
                // Quitter
                    case "X":
                        Console.Clear();

                        account.WriteResume(resumeCurrentAccount, "compteCourant");

                        account.WriteResume(resumeSaveAccount, "compteEpargne");

                        Console.WriteLine("Merci et à bientôt");
                        Environment.Exit(0);
                        
                        break;
                    // default:
                    //     Console.WriteLine("Votre entrée n'est pas valide");
                    //     break;
                }
            }while(userChoice.ToUpper() != "X");
            
        }
    }
}