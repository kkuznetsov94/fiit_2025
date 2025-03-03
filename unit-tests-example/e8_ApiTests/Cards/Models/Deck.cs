using System.Text.Json.Serialization;

namespace e8_ApiTests.Cards.Models;

public class Deck
{
    [JsonPropertyName("deck_id")] public string DeckId { get; set; }

    [JsonPropertyName("remaining")] public int CardsCount { get; set; }

    [JsonPropertyName("shuffled")] public bool Shuffled { get; set; }

    [JsonPropertyName("success")] public bool Success { get; set; }
}