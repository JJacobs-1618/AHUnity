using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Deck : MonoBehaviour
{
    public DeckSO data;

    public abstract CardSO DrawCard();
}
