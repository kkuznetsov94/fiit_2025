using System.Net;
using Dadata;
using e8_ApiTests.Cards;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace e8_ApiTests;

public class Tests
{
    private readonly DeckApiClient _client = new();
    private readonly SuggestClientAsync _dadataClient = new(Secrets.GetSecret("secrets.txt"));

    [Test]
    public void GetDeck_ContainAllFields()
    {
        // Act
        var result = _client.GetDeck();

        // Assert
        using (new AssertionScope())
        {
            var deck = result.Result;
            deck.Should().NotBeNull();
            deck.Success.Should().Be(true);
            deck.Shuffled.Should().Be(false);
            deck.DeckId.Should().NotBeNullOrEmpty();
            deck.CardsCount.Should().Be(52);
        }
    }

    [TestCase(1, 52)]
    [TestCase(2, 104)]
    public void GetDeck_CorrectCardsInResult(int deckCount, int cardsCount)
    {
        // Act
        var result = _client.GetDeck(true, deckCount);

        // Assert
        result.Result!.CardsCount.Should().Be(cardsCount);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void GetDeck_CorrectShuffledStatus(bool shuffled)
    {
        // Act
        var result = _client.GetDeck(shuffled, 1);

        // Assert
        result.Result!.Shuffled.Should().Be(shuffled);
    }

    [Test]
    public void GetDeck_CorrectStatusCode()
    {
        // Act
        var result = _client.GetDeck();

        // Assert
        result.Status.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public void Dadata_GetCompanyInfo_ByInn()
    {
        // Act
        var response = _dadataClient.FindParty("7707083893");

        // Assert
        var company = response.Result.suggestions[0];
        company.data.inn.Should().Be("7707083893");
        company.value.Should().Be("ПАО СБЕРБАНК");
    }
}