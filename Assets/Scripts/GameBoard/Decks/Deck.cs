using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Deck : ScriptableObject
{
    public Card objectBase;
    public DeckSO deckData;
    private List<CardSO> deck;
    private List<CardSO> discard;


    public void Init()
    {
        deck = new();        
        discard = new();

        deck.AddRange(deckData.cards);
    }

    public Card DrawCard()
    {
        Card retCard = Instantiate(objectBase);
        retCard.data = deck[UnityEngine.Random.Range(0, deck.Count - 1)];
        DiscardCard(retCard.data);

        return retCard;
    }

    public void RemoveCard(CardSO card)
    {
        if (discard.Contains(card)) discard.Remove(card);
    }

    public void DiscardCard(CardSO card)
    {
        discard.Add(card);
        deck.Remove(card);
    }

    public void ShuffleDeck()
    {
        deck.AddRange(discard);
        discard.Clear();
    }

    public void TheStoryContinues()
    {
        Debug.Log("The Story Continues... Reshuffling Mythos Deck.");
        ShuffleDeck();
    }
}
