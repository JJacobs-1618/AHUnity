using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardSO : ScriptableObject
{
    public string cardName;
    [Tooltip("This is the italicized text on the card. May not apply to each one.")]
    public string flavorText;
}
