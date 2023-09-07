using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck Data", menuName = "Arkham/Gameboard/Deck/Deck Data")]
public class DeckSO : ScriptableObject
{
    public List<CardSO> cards;
}
