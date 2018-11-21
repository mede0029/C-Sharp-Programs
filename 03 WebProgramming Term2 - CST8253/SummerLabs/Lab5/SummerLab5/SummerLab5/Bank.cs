using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SummerLab5.Entities;

namespace SummerLab5.Entities
{
    class Bank
    {
        static void Main(string[] args)
        {
            List<Customer> accounts = new List<Customer>();
            List<Transaction> TransactionHistory = new List<Transaction>();
            int selection = 0;
            int selection2 = 0;
            string selectionSt = "";
            double selectAccount = 0;
            double depAmount = 0.0;
            double transferFrom = 0.0;

        Console.WriteLine("Welcome to Algonquin Bank!!!");
            bool answer = true;
            while (answer)
            {
                Console.WriteLine("\nEnter customer name: ");
                string name = Console.ReadLine();
                if (name == "")
                {
                    answer = false;
                    break;
                }
                Console.WriteLine($"Enter {name}'s initial deposit amount: ");
                string initialDepositSt = Console.ReadLine();
                //if initialDepositSt IS a number, and it's less than an int size, and it's positive:
                double num;
                if ((double.TryParse(initialDepositSt, out num)) && (double.Parse(initialDepositSt) < int.MaxValue) && (double.Parse(initialDepositSt) >= 0))
                {
                    double initialDeposit = double.Parse(initialDepositSt);
                    Customer newCustomer = new Customer(name);
                    newCustomer.Checking.Balance = 0.0;
                    Transaction amount1 = new Transaction(initialDeposit, TransactionType.DEPOSIT);
                    newCustomer.Saving.Deposit(amount1);
                    accounts.Add(newCustomer);
                }
                else
                {
                    Console.WriteLine("This is not a valid number. Please try again.");
                    continue;
                }
            }

            Console.WriteLine("\nSelect one of the following customers: ");
            int N = accounts.Count;
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"\n{i+1} - Customer {accounts[i].Name}, initial deposit ${accounts[i].Saving.Balance} - current status {accounts[i].Status}");
            }
            bool selecCustomer = true;
            while (selecCustomer)
            {                
                Console.WriteLine($"\nEnter your selection: 1 to {N}:");
                selectionSt = Console.ReadLine();
                //if selectionSt IS a number, and it's less than number of clients on menu, and it's positive:
                double num;
                if ((double.TryParse(selectionSt, out num)) && (double.Parse(selectionSt) <= N) && (double.Parse(selectionSt) > 0))
                {
                    selection = int.Parse(selectionSt);
                    selection--;
                    Console.WriteLine($"\nWelcome {accounts[selection].Name}! You are currently our {accounts[selection].Status} customer.");
                    selecCustomer = false;
                    break;
                }
                else
                {
                    Console.WriteLine($"This is not a valid selection.");
                    continue;
                }
            }                      


            //Transactions menu:
            bool continueSwitch = true;
            while (continueSwitch)
            {                 
                Console.WriteLine("\nSelect one of our following activities:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Transfer");
                Console.WriteLine("4. Balance Inquiry");
                Console.WriteLine("5. Account Activity Enquiry");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your selection: 1 - 6: ");
                selectionSt = Console.ReadLine();
                //if selection2St IS a number, and it's less than number of clients on menu, and it's positive:
                double num;
                if ((double.TryParse(selectionSt, out num)) && (double.Parse(selectionSt) <=6) && (double.Parse(selectionSt) >= 0) && (double.Parse(selectionSt) != 6))
                {
                    selection2 = int.Parse(selectionSt);                    
            
                    
                    //Operations:
                    if (selection2 == 1)//Deposit
                    {
                        bool deposit = true;
                        while (deposit)
                        {
                            Console.WriteLine("\nSelect: 1 - Checking Account; 2 - Savings Account: ");
                            string selectAccountSt = Console.ReadLine();
                            //if selectAccountSt IS a number, and it's between 1 and 2:
                            if ((double.TryParse(selectAccountSt, out num)) && (double.Parse(selectAccountSt) <= 2) && (double.Parse(selectAccountSt) >= 1))
                            {
                                selectAccount = double.Parse(selectAccountSt);
                                Console.WriteLine("Type the deposit amount: ");
                                string depAmountSt = Console.ReadLine();
                                //if depAmount IS a number, and it's less than an int size, and it's positive:                            
                                if ((double.TryParse(depAmountSt, out num)) && (double.Parse(depAmountSt) < int.MaxValue) && (double.Parse(depAmountSt) >= 0))
                                {
                                    depAmount = double.Parse(depAmountSt);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("This is not a valid entry. Please try again.");
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("This is not a valid entry. Please try again.");
                                continue;
                            }
                        }
                        if (selectAccount == 1)
                        {
                            Transaction depAmount1 = new Transaction(depAmount, TransactionType.DEPOSIT);
                            accounts[selection].Checking.Deposit(depAmount1);
                            Console.WriteLine($"\nDeposit complete. Current balance of checking account: ${accounts[selection].Checking.Balance}.");
                        }
                        if (selectAccount == 2)
                        {
                            Transaction depAmount1 = new Transaction(depAmount, TransactionType.DEPOSIT);
                            accounts[selection].Saving.Deposit(depAmount1);
                            Console.WriteLine($"\nDeposit complete. Current balance of savings account: ${accounts[selection].Saving.Balance}.");
                        }
                        continue;
                    }


                    else if (selection2 == 2) //Withdraw
                    {
                        Console.WriteLine("\nSelect: 1 - Checking Account; 2 - Savings Account: ");
                        string selectAccountSt = Console.ReadLine();
                        //if selectAccountSt IS a number, and it's between 1 and 2:
                        if ((double.TryParse(selectAccountSt, out num)) && (double.Parse(selectAccountSt) <= 2) && (double.Parse(selectAccountSt) >= 1))
                        {
                            selectAccount = double.Parse(selectAccountSt);
                            Console.WriteLine("Type the withdraw amount: ");
                            string depAmountSt = Console.ReadLine();
                            //if depAmountSt IS a number, and it's less than an int size, and it's positive:                            
                            if ((double.TryParse(depAmountSt, out num)) && (double.Parse(depAmountSt) < int.MaxValue) && (double.Parse(depAmountSt) >= 0))
                            {
                                depAmount = double.Parse(depAmountSt);
                            }
                            else
                            {
                                Console.WriteLine("\nThis is not a valid entry. Please try again.");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThis is not a valid entry. Please try again.");
                            continue;
                        }                        
                        if (selectAccount == 1)
                        {
                            Transaction depAmount1 = new Transaction(depAmount, TransactionType.WITHDRAW);
                            TransactionResult tResult = accounts[selection].Checking.Withdraw(depAmount1);
                            if (tResult == TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT)
                            {
                                Console.WriteLine("\nSorry, withdraw was not completed. Exceeds maximum withdraw amount. Please try again.");
                            }
                            if (tResult == TransactionResult.INSUFFICIENT_FUND)
                            {
                                Console.WriteLine("\nSorry, withdraw was not completed. Not sufficient funds. Please try again.");
                            }
                            if (tResult == TransactionResult.SUCCESS)
                            {
                                Console.WriteLine($"\nWithdraw complete. Current balance of checking account: ${accounts[selection].Checking.Balance}.");
                            }
                        }
                        if (selectAccount == 2)
                        {
                            Transaction depAmount1 = new Transaction(depAmount, TransactionType.WITHDRAW);
                            TransactionResult tResult = accounts[selection].Saving.Withdraw(depAmount1);
                            if (tResult == TransactionResult.INSUFFICIENT_FUND)
                            {
                                Console.WriteLine("\nSorry, withdraw was not completed. Not sufficient funds. Please try again.");
                            }
                            if (tResult == TransactionResult.SUCCESS)
                            {
                                Console.WriteLine($"\nWithdraw complete. Current balance of savings account: ${accounts[selection].Saving.Balance}.");
                            }
                        }
                        continue;
                    }


                    else if (selection2 == 3) //Transfer
                    {
                        Console.WriteLine("\nSelect transfer FROM: 1 - Checking Account; 2 - Savings Account: ");
                        string transferFromSt = Console.ReadLine();
                        //if transferFromSt IS a number, and it's between 1 and 2:
                        if ((double.TryParse(transferFromSt, out num)) && (double.Parse(transferFromSt) <= 2) && (double.Parse(transferFromSt) >= 1))
                        {
                            transferFrom = double.Parse(transferFromSt);
                        }
                        else
                        {
                            Console.WriteLine("\nThis is not a valid entry. Please try again.");
                            continue;
                        }                                                   
                        if (transferFrom == 1) //transfer from checking to savings
                        {
                            Console.WriteLine("Type the transfer amount to savings account: ");
                            string depAmountSt = Console.ReadLine();
                            //if depAmountSt IS a number, and it's less than an int size, and it's positive: 
                            if ((double.TryParse(depAmountSt, out num)) && (double.Parse(depAmountSt) < int.MaxValue) && (double.Parse(depAmountSt) >= 0))
                            {
                                depAmount = double.Parse(depAmountSt);
                            }
                            else
                            {
                                Console.WriteLine("\nThis is not a valid entry. Please try again.");
                                continue;
                            }                                
                            Transaction depAmount1 = new Transaction(depAmount, TransactionType.TRANSFER_OUT);
                            TransactionResult tResult = accounts[selection].Checking.TransferOut(depAmount1);
                            if (tResult == TransactionResult.INSUFFICIENT_FUND)
                            {
                                Console.WriteLine("\nSorry, transfer was not completed. Not sufficient funds on checking account. Please try again.");
                            }
                            if (tResult == TransactionResult.SUCCESS)
                            {
                                depAmount1 = new Transaction(depAmount, TransactionType.TRANSFER_IN);
                                accounts[selection].Saving.TransferIn(depAmount1);
                                Console.WriteLine($"\nTransfer complete. Current balance of checking account: ${accounts[selection].Checking.Balance} and current balance of savings account: ${accounts[selection].Saving.Balance}.");
                            }
                        }
                        if (transferFrom == 2) //transfer from savings to checking
                        {
                            Console.WriteLine("Type the transfer amount to checking account: ");
                            string depAmountSt = Console.ReadLine();
                            //if depAmountSt IS a number, and it's less than an int size, and it's positive: 
                            if ((double.TryParse(depAmountSt, out num)) && (double.Parse(depAmountSt) < int.MaxValue) && (double.Parse(depAmountSt) >= 0))
                            {
                                depAmount = double.Parse(depAmountSt);
                            }                                
                            Transaction depAmount1 = new Transaction(depAmount, TransactionType.TRANSFER_OUT);
                            TransactionResult tResult = accounts[selection].Saving.TransferOut(depAmount1);
                            if (tResult == TransactionResult.INSUFFICIENT_FUND)
                            {
                                Console.WriteLine("\nSorry, transfer was not completed. Not sufficient funds on savings account. Please try again.");
                            }
                            if (tResult == TransactionResult.SUCCESS)
                            {
                                depAmount1 = new Transaction(depAmount, TransactionType.TRANSFER_IN);
                                accounts[selection].Checking.TransferIn(depAmount1);
                                Console.WriteLine($"\nTransfer complete. Current balance of checking account: ${accounts[selection].Checking.Balance} and current balance of savings account: ${accounts[selection].Saving.Balance}.");
                            }
                        }
                        continue;
                    }


                    else if (selection2 == 4) //Balance inquiry
                    {
                        Console.WriteLine($"\nThe current balance of the checking account is {accounts[selection].Checking.Balance}.");
                        Console.WriteLine($"And the current balance of the savings account is {accounts[selection].Saving.Balance}.");
                        continue;
                    }


                    else if (selection2 == 5) //Account activity inquiry
                    {
                        Console.WriteLine("\nSelect: 1 - Checking Account; 2 - Savings Account: ");
                        string selectAccountSt = Console.ReadLine();
                        //if selectAccontSt IS a number, and it's between 1 and 2:
                        if ((double.TryParse(selectAccountSt, out num)) && (double.Parse(selectAccountSt) <= 2) && (double.Parse(selectAccountSt) >= 1))
                        {
                            selectAccount = double.Parse(selectAccountSt);
                        }
                        else
                        {
                            Console.WriteLine("\nThis is not a valid entry. Please try again.");
                            continue;
                        }                            

                        if (selectAccount == 1)
                        {
                            Console.WriteLine("\nCHECKING ACCOUNT HISTORY:");
                            Console.WriteLine("AMOUNT \t\tDATE \t\t\tACTIVITY");
                            Console.WriteLine("------ \t\t----- \t\t\t---------");
                            N = accounts[selection].Checking.TransactionHistory.Count;
                            for (int i = 0; i < N; i++)
                            {
                                Console.WriteLine($"{accounts[selection].Checking.TransactionHistory[i].Amount}\t\t{accounts[selection].Checking.TransactionHistory[i].TransactionDate}\t{accounts[selection].Checking.TransactionHistory[i].Type}");
                            }
                        }
                        if (selectAccount == 2)
                        {
                            Console.WriteLine("\nSAVINGS ACCOUNT HISTORY:");
                            Console.WriteLine("AMOUNT \t\tDATE \t\t\tACTIVITY");
                            Console.WriteLine("------ \t\t----- \t\t\t---------");
                            N = accounts[selection].Saving.TransactionHistory.Count;
                            for (int i = 0; i < N; i++)
                            {
                                Console.WriteLine($"{accounts[selection].Saving.TransactionHistory[i].Amount}\t\t{accounts[selection].Saving.TransactionHistory[i].TransactionDate}\t{accounts[selection].Saving.TransactionHistory[i].Type}");
                            }
                        }
                        continue;
                    }
                }
                else if (selectionSt == "6")
                {
                    continueSwitch = false;
                    break;
                }
                else
                {
                    Console.WriteLine("\nThis is not a valid entry. Please try again.");
                    continue;   
                }            
            }     
            Console.WriteLine("\nPress any key to finish...");
            Console.ReadLine();
        }
    }
}
