using RestSharp;
using System.Collections.Generic;
using TenmoClient.Models;

namespace TenmoClient.Services
{
    public class TenmoApiService : AuthenticatedApiService
    {
        public readonly string ApiUrl;

        public TenmoApiService(string apiUrl) : base(apiUrl) { }

        // Add methods to call api here...
        public Account GetAccount(int id)
        {
            
            RestRequest request = new RestRequest($"accounts/{id}");
            IRestResponse<Account> response = client.Get<Account>(request);

            CheckForError(response);
            return response.Data;

        }
       

        public List<Account> GetAllAccounts()
        {
            RestRequest request = new RestRequest("accounts");
            IRestResponse<List<Account>> response = client.Get<List<Account>>(request);
            CheckForError(response);
            return response.Data;

        }

        public Transfer GetTransfer(int transferId)
        {
            RestRequest request = new RestRequest($"transfers/{transferId}");
            IRestResponse<Transfer> response = client.Get<Transfer>(request);
            CheckForError(response);
            return response.Data;
        }

        public List<Transfer> GetAllTransfers(int accountId = 0)
        {
            string url;
            if (accountId != 0)
            {
                url = $"transfers/{accountId}";
            }
            else
            {
                url = "transfers";
            }

            RestRequest request = new RestRequest(url);
            IRestResponse<List<Transfer>> response = client.Get<List<Transfer>>(request);

            CheckForError(response);
            return response.Data;
        }

        public Transfer AddTransfer(Transfer newTransfer)
        {
            RestRequest request = new RestRequest("transfers");
            request.AddJsonBody(newTransfer);
            IRestResponse<Transfer> response = client.Post<Transfer>(request);

            CheckForError(response);
            return response.Data;
        }

    }
}
