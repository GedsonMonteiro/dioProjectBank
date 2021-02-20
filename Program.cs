using System;
using System.Collections.Generic;

namespace DIO.Bank
{
	class Program
	{
		static List<account> accountList = new List<account>();
		static void Main(string[] args)
		{
			string userOptionGain = userOptionGain();

			while (userOptionGain.ToUpper() != "X")
			{
				switch (userOptionGain)
				{
					case "1":
						accountListing();
						break;
					case "2":
						accountInsert();
						break;
					case "3":
						Transfer();
						break;
					case "4":
						Withdraw();
						break;
					case "5":
						Deposit();
						break;
                    case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				userOptionGain = userOptionGainGain();
			}
			
			Console.WriteLine("Thank you for using our services.");
			Console.ReadLine();
		}

		private static void Deposit()
		{
			Console.Write("Enter account number: ");
			int accountIndex = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valueDeposit = double.Parse(Console.ReadLine());

            accountList[accountIndex].Depositar(valueDeposit);
		}

		private static void Withdraw()
		{
			Console.Write("Enter account number: ");
			int accountIndex = int.Parse(Console.ReadLine());

			Console.Write("Enter the amount to be withdrawn: ");
			double valueWithdrawn = double.Parse(Console.ReadLine());

            accountList[accountIndex].Withdrawn(valueWithdrawn);
		}

		private static void Transfer()
		{
			Console.Write("Enter origin account number: ");
			int accountIndexOrigin = int.Parse(Console.ReadLine());

            Console.Write("Enter destiny account number: ");
			int accountIndexDestiny = int.Parse(Console.ReadLine());

			Console.Write("Enter transfer account number: ");
			double valueTransfer = double.Parse(Console.ReadLine());

            accountList[accountIndexOrigin].Transfer(valueTransfer, accountList[accountIndexDestiny]);
		}

		private static void accountInsert()
		{
			Console.WriteLine("Insert new account");

			Console.Write("Enter 1 for Legal Person or 2 for Natural Person: ");
			int enterAccountType = int.Parse(Console.ReadLine());

			Console.Write("Enter Customer Name: ");
			string enterName = Console.ReadLine();

			Console.Write("Enter the opening balance: ");
			double enterBalance = double.Parse(Console.ReadLine());

			Console.Write("Enter credit value: ");
			double enterCredit = double.Parse(Console.ReadLine());

			account newAccount = new account(typeaccount: (Typeaccount)enterAccountType,
										balance: enterBalance,
										credit: enterCredit,
										name: enterName);

			accountList.Add(newAccount);
		}

		private static void listAccount()
		{
			Console.WriteLine("Account list");

			if (accountList.Count == 0)
			{
				Console.WriteLine("No account registered.");
				return;
			}

			for (int i = 0; i < accountList.Count; i++)
			{
				accountList account = accountList[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(account);
			}
		}

		private static string userOptionGain()
		{
			Console.WriteLine();
			Console.WriteLine("We are at your service!");
			Console.WriteLine("Enter the desired option:");

			Console.WriteLine("1- List accounts");
			Console.WriteLine("2- Insert new account");
			Console.WriteLine("3- Transfer");
			Console.WriteLine("4- Withdraw");
			Console.WriteLine("5- Deposit");
            Console.WriteLine("C- Clear screen");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string userOption = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return userOption;
		}
	}
}
