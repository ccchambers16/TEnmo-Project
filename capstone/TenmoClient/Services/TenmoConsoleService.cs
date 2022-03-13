using System;
using System.Collections.Generic;
using TenmoClient.Models;
using TenmoClient.Services; 

namespace TenmoClient.Services
{
    public class TenmoConsoleService : ConsoleService
    {
        private TenmoApiService tenmoApiService;

        // private readonly AuthenticatedApiService authenticatedApiService;
        




        /************************************************************
            Print methods
        ************************************************************/
        public void PrintLoginMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Welcome to TEnmo!");
            Console.WriteLine("1: Login");
            Console.WriteLine("2: Register");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }

        public void PrintMainMenu(string username)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine($"Hello, {username}!");
            Console.WriteLine("1: View your current balance");
            Console.WriteLine("2: Send TE bucks");
            Console.WriteLine("3: View your pending requests");
            Console.WriteLine("4: View your past transfers"); 
            Console.WriteLine("5: Request TE bucks");
            Console.WriteLine("6: Log out");
            Console.WriteLine("0: Exit");
            Console.WriteLine("---------");
        }
        public LoginUser PromptForLogin()
        {
            string username = PromptForString("User name");
            if (String.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            string password = PromptForHiddenString("Password");

            LoginUser loginUser = new LoginUser
            {
                Username = username,
                Password = password
            };
            return loginUser;
        }

        //PrintCurrentBalance [1]
        public void PrintCurrentBalance(Account account, int userId)
        {
            
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Your current acount balance is: {account.Balance}.");
        }

        //PrintPastTransfers [2]
        public void PrintAllTransfers(List<Transfer> transfers)
        {
            Console.WriteLine("Here are the details of all past transfers:");
            foreach (Transfer transfer in transfers)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine(" Id: " + transfer.TransferId);
                Console.WriteLine(" From: " + AccountIdToUserName(transfer.FromAccountId));
                Console.WriteLine(" To: " + AccountIdToUserName(transfer.ToAccountId));
                Console.WriteLine(" Type: " + TransferTypeIdToName(transfer.TransferTypeId));
                Console.WriteLine(" Status: " + TransferStatusIdToName(transfer.TransferStatusId));
                Console.WriteLine(" Amount: $" + transfer.TransferAmount);
            }
        }

        //PrintPendingTransfers [3] ... basically ALL transfers the way we set it up
        public Transfer PrintPendingTransfers()
        {
            return null;
        }

        //PrintSendTransfer [4]
        public void PrintTransfer(int transferId)
        {
            Transfer transfer = tenmoApiService.GetTransfer(transferId);

            Console.WriteLine($"Here are the details for transfer Id: {transferId}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + transfer.TransferId);
            Console.WriteLine(" From: " + AccountIdToUserName(transfer.FromAccountId));
            Console.WriteLine(" To: " + AccountIdToUserName(transfer.ToAccountId));
            Console.WriteLine(" Type: " + TransferTypeIdToName(transfer.TransferTypeId));
            Console.WriteLine(" Status: " + TransferStatusIdToName(transfer.TransferStatusId));
            Console.WriteLine(" Amount: $" + transfer.TransferAmount);

        }

        public void PrintListOfUserIdAndUsername()
        {
            List<Account> accounts = tenmoApiService.GetAllAccounts();
            Console.WriteLine("   Id | Username");
            Console.WriteLine("---------------------");
            foreach (Account account in accounts)
            { Console.WriteLine($" {account.UserId} | {account.Username}"); }
        }

        public string TransferTypeIdToName(int id)
        {
            string message = null;

            if (id == 1)
            {
                message = "Request";
            }
            else if (id == 2)
            {
                message = "Send";
            }
            return message;
        }

        public string TransferStatusIdToName(int id)
        {
            string message = null;

            if (id == 1)
            {
                message = "Pending";
            }
            else if (id == 2)
            {
                message = "Approved";
            }
            else if (id == 3)
            {
                message = "Rejected";
            }
            return message;
        }

        public string AccountIdToUserName(int id)
        {
            Account account = null;
            string userName = null;
            account = tenmoApiService.GetAccount(id);
            userName = account.Username;
            return userName;
        }

        
    }    
}
