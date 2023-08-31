using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeckSO", menuName = "Scriptables/GameBoard/Deck")]
public class DeckSO : ScriptableObject
{
    public List<CardSO> cards;
}
