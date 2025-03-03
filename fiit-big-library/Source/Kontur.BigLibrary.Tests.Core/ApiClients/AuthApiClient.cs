using RestSharp;

namespace Kontur.BigLibrary.Tests.Core.ApiClients;

public class AuthApiClient : ApiClientBase
{
    public RestResponse RegisterUser(string login, string password)
    {
        var request = new RestRequest("api/account/register", Method.Post);
        request.AddJsonBody(new { Email = login, Password = password });
        var response = client.ExecutePost(request);
        return response;
    }
    
    public RestResponse LoginUser(string login, string password)
    {
        var request = new RestRequest("api/account/login", Method.Post);
        request.AddJsonBody(new { Email = login, Password = password });
        var response = client.ExecutePost(request);
        return response;
    }
}