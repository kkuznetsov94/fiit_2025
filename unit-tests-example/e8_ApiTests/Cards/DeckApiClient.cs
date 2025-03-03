using System.Text.Json;
using e8_ApiTests.Cards.Models;
using RestSharp;

namespace e8_ApiTests.Cards;

public class DeckApiClient
{
    private readonly RestClient _client;

    public DeckApiClient()
    {
        _client = new RestClient("https://deckofcardsapi.com/");
    }

    public HttpResult<Deck?> GetDeck(bool shuffled = false, int? count = null)
    {
        var request = shuffled
            ? new RestRequest("api/deck/new/shuffle")
            : new RestRequest("api/deck/new");

        if (count is not null)
        {
            request.AddParameter("deck_count", count.Value);
        }

        var result = _client.Get(request);

        return result.Content != null
            ? new HttpResult<Deck?>(result.StatusCode, JsonSerializer.Deserialize<Deck>(result.Content!))
            : new HttpResult<Deck?>(result.StatusCode, null);
    }
}