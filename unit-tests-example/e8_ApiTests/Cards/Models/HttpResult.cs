using System.Net;

namespace e8_ApiTests.Cards.Models;

public class HttpResult<T>
{
    public HttpResult(HttpStatusCode status, T result)
    {
        Status = status;
        Result = result;
    }

    public HttpStatusCode Status { get; }

    public T Result { get; }
}