using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigator : MonoBehaviour
{
    [SerializeField] protected string investigatorName;
    [SerializeField] protected string profession;
    [SerializeField] protected string home;
    [SerializeField] protected List<Item> fixedPossessions;
    [SerializeField] protected Dictionary<int, string> randomPossessions;
    [SerializeField] protected string abilityName;
    [SerializeField] protected string abilityText;
    [SerializeField] protected string theStorySoFar;
    [SerializeField] public InvestigatorStats stats;
    [SerializeField] public Inventory inventory;
    [SerializeField] public InvestigatorController controller;

    private void Update()
    {
        
    }

    public string GetName()
    {
        return investigatorName;
    }
    public string GetProfession()
    {
        return profession;
    }
    public string GetHome()
    {
        return home;
    }    
}
