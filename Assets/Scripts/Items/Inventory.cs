using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int totalCash;
    [SerializeField] List<Common> commonItems;
    [SerializeField] List<Unique> uniqueItems;
    [SerializeField] List<Spell> spells;

    public void UpdateCash(int delta)
    {
        totalCash += delta;
    }
    public void AddToInventory(Item item)
    {

    }
}
