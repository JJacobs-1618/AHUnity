using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] string itemName;
    [SerializeField] DamageType damageType;
    [SerializeField] string itemDescription;
    [SerializeField] ItemType itemType;
    [SerializeField] int msrp;
    [SerializeField] int requiredHands;
    [SerializeField] bool isExhausted;

    public Item()
    {
        itemName = "Unset";
        damageType = DamageType.None;
        itemDescription = "Unset";
        itemType = ItemType.Common;
        msrp = 0;
        requiredHands = 0;
        isExhausted = false;
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

public enum DamageType
{
    Physical,
    Magical,
    None
}