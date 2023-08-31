using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSO : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public ItemType itemType;
    public int msrp;
    public int requiredHands;
    public bool isExhausted;

    public ItemSO()
    {
        itemName = "Unset";
        itemDescription = "Unset";
        itemType = ItemType.ItemType;
        msrp = 0;
        requiredHands = 0;
        isExhausted = false;
    }


    public abstract void Use();
    public virtual void OnUpkeep()
    {
        isExhausted = false;
    }
    public void Exhaust() { isExhausted = true; }
}

public enum ItemType
{
    Common,
    Unique,
    Spell,
    DeputyRevolver,
    PatrolWagon,
    ItemType
}