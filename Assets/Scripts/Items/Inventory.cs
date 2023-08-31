using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] int totalCash;
    [SerializeField] int clueToken;
    

    public void UpdateCash(int delta)
    {
        totalCash += delta;
    }
    public void AddToInventory(ItemSO item)
    {

    }
}
