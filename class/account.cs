using System;

namespace DIO.Bank
{
	public class account
	{
		private Typeaccount Typeaccount { get; set; }
		private double Balance { get; set; }
		private double Credit { get; set; }
		private string Name { get; set; }

		public account(Typeaccount typeaccount, double balance, double credit, string name)
		{
			this.Typeaccount = typeaccount;
			this.Balance = balance;
			this.Credit = credit;
			this.Name = name;
		}

		public bool Withdraw(double valueWithdraw)
		{
         
            if (this.Balance - valueWithdraw < (this.Credit *-1)){
                Console.WriteLine("The balance is not enough!");
                return false;
            }
            this.Balance -= valueWithdraw;

            Console.WriteLine("Current account balance of {0} is {1}", this.Name, this.Balance);

            return true;
		}

		public void Deposit(double valueDeposit)
		{
			this.Balance += valueDeposit;

            Console.WriteLine("Current account balance of {0} is {1}", this.Name, this.Balance);
		}

		public void Transfer(double valueTransfer, account accountDestiny)
		{
			if (this.Withdraw(valueTransfer)){
                accountDestiny.Deposit(valueTransfer);
            }
		}

        public override string ToString()
		{
            string back = "";
            back += "Typeaccount " + this.Typeaccount + " | ";
            back += "Name " + this.Name + " | ";
            back += "Balance " + this.Balance + " | ";
            back += "Credit " + this.Credit;
			return back;
		}
	}
}