using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] ItemType itemType;
    [SerializeField] int msrp;
    [SerializeField] int requiredHands;
    [SerializeField] GamePhase usablePhase;

    public Item()
    {
        itemName = "Unset";
        itemDescription = "Unset";
        itemType = ItemType.Common;
        msrp = 0;
        requiredHands = 0;
        usablePhase = GamePhase.Any;
    }
}

public enum ItemType
{
    Common,
    Unique,
    Spell,
    DeputyRevolver,
    PatrolWagon
}