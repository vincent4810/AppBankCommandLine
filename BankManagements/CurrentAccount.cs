namespace BankManagements
{
    
    class CurrentAccount : Account{

        public CurrentAccount(double solde){
            
            this.solde = solde;
            accountType = "Compte courant";
        }
    }
}