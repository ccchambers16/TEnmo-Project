using System;
using System.Collections.Generic;
using TenmoClient.Models;
using TenmoClient.Services;


namespace TenmoClient
{
    public class TenmoApp
    {
        private readonly TenmoApiService tenmoApiService;
        private readonly TenmoConsoleService console2 = new TenmoConsoleService();


        public TenmoApp(string apiUrl)
        {
            tenmoApiService = new TenmoApiService(apiUrl);

        }

        public void Run()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                // The menu changes depending on whether the user is logged in or not
                if (tenmoApiService.IsLoggedIn)
                {
                    keepGoing = RunAuthenticated();
                }
                else // User is not yet logged in
                {
                    keepGoing = RunUnauthenticated();
                }
            }
        }

        private bool RunUnauthenticated()
        {
            console2.PrintLoginMenu();
            int menuSelection = console2.PromptForInteger("Please choose an option", 0, 2, 1);
            while (true)
            {
                if (menuSelection == 0)
                {
                    return false;   // Exit the main menu loop
                }

                if (menuSelection == 1)
                {
                    // Log in
                    Login();
                    return true;    // Keep the main menu loop going
                }

                if (menuSelection == 2)
                {
                    // Register a new user
                    Register();
                    return true;    // Keep the main menu loop going
                }
                console2.PrintError("Invalid selection. Please choose an option.");
                console2.Pause();
            }
        }

        private bool RunAuthenticated()
        {
            console2.PrintMainMenu(tenmoApiService.Username);
            int menuSelection = console2.PromptForInteger("Please choose an option", 0, 6);
            if (menuSelection == 0)
            {
                // Exit the loop
                return false;
            }

            if (menuSelection == 1)
            {
                ShowAccount();
                // View your current balance
            }

            if (menuSelection == 2)
            {
                ShowTransfer();
                // View your past transfers
            }

            if (menuSelection == 3)
            {
                ShowAllTransfers();
                // View your pending requests
            }

            if (menuSelection == 4)
            {
                ShowSendTransfers();
                // Send TE bucks
            }

            if (menuSelection == 5)
            {
                RequestTeBucks();
            }

            if (menuSelection == 6)
            {
                // Log out
                tenmoApiService.Logout();
                console2.PrintSuccess("You are now logged out");
            }

            return true;    // Keep the main menu loop going
        }

        private void Login()
        {
            LoginUser loginUser = console2.PromptForLogin();
            if (loginUser == null)
            {
                return;
            }

            try
            {
                ApiUser user = tenmoApiService.Login(loginUser);
                if (user == null)
                {
                    console2.PrintError("Login failed.");
                }
                else
                {
                    console2.PrintSuccess("You are now logged in");
                }
            }
            catch (Exception)
            {
                console2.PrintError("Login failed.");
            }
            console2.Pause();
        }

        private void Register()
        {
            LoginUser registerUser = console2.PromptForLogin();
            if (registerUser == null)
            {
                return;
            }
            try
            {
                bool isRegistered = tenmoApiService.Register(registerUser);
                if (isRegistered)
                {
                    console2.PrintSuccess("Registration was successful. Please log in.");
                }
                else
                {
                    console2.PrintError("Registration was unsuccessful.");
                }
            }
            catch (Exception)
            {
                console2.PrintError("Registration was unsuccessful.");
            }
            console2.Pause();
        }


        private void ShowAccount()
        {
            Console.WriteLine($"Welcome to your account.");
            Console.WriteLine($"Your account id is:  {tenmoApiService.UserId}.");
            console2.PrintCurrentBalance(tenmoApiService.UserId);
            Console.WriteLine($"----------------------------------------------");
            console2.Pause();
        }

        private void ShowTransfer()
        {
            Transfer transfer = null;
            transfer.FromAccountId = console2.UserIdToAccountId(tenmoApiService.UserId);

            Console.WriteLine($"Please follow the directions below to complete a transfer of Tenmo buck$.");
            Console.WriteLine("Select a user to send money to:");
            console2.PrintListOfUserIdAndUsername();

            string message = "Enter userId of receipient of transfer: ";
            int ToUserId = console2.PromptForInteger(message, 1000, int.MaxValue);
            transfer.ToAccountId = console2.UserIdToAccountId(ToUserId);

            string messageAmount = "Enter the amount of money you would like to send:";
            decimal defaultValue = 0;
            decimal transferAmount = console2.PromptForDecimal(messageAmount, defaultValue);

            if (transferAmount > 0)
            {
                transfer.TransferAmount = transferAmount;
            }

            Transfer completedTransfer = tenmoApiService.AddTransfer(transfer);

            Console.WriteLine("Transfer completed!");
            console2.PrintTransfer(completedTransfer.TransferId);
            Console.WriteLine($"----------------------------------------------");
            console2.Pause();
        }

        private void ShowAllTransfers()
        {
            string message = "This feature is coming soon, stay tuned!";
            console2.PrintError(message);
            console2.Pause();
        }
        private void RequestTeBucks()
        {
            string message = "This feature is coming soon, stay tuned!";
            console2.PrintError(message);
            console2.Pause();
        } 
        private void ShowSendTransfers()
        {
            Console.WriteLine("Check out all the money you've sent to your Tenmo buddies.");

            int accountId= console2.UserIdToAccountId(tenmoApiService.UserId);
            List<Transfer> transfers = tenmoApiService.GetAllTransfers(accountId);
            console2.PrintAllTransfers(transfers);
            console2.Pause(); 
        }


        
    }
}
