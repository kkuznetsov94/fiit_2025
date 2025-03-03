using RestSharp;

namespace Kontur.BigLibrary.Tests.Core.ApiClients;

public abstract class ApiClientBase
{
    protected RestClient client;

    protected ApiClientBase()
    {
        client = new RestClient("http://localhost:5000/");
    }
}