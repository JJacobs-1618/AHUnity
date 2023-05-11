using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<Common> commonItems;
    [SerializeField] List<Unique> uniqueItems;
    [SerializeField] List<Spell> spells;

    public void AddToInventory(Item item)
    {

    }
}
