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

       // public static IRestClient client = null;
      //  private static ApiUser user = new ApiUser();

      

        public List<Account> GetAllAccounts()
        {
            RestRequest request = new RestRequest("users");
            IRestResponse<List<Account>> response = client.Get<List<Account>>(request);
            CheckForError(response);
            return response.Data;

        }


      //  public decimal GetBalanceForUser(int userId)
       // {
          //  RestRequest requestOne = new RestRequest($"");
           // IRestResponse
       // }

    }
}
