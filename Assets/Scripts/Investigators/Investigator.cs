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
    [SerializeField] protected InvestigatorStats stats;
    [SerializeField] public Inventory inventory;
    [SerializeField] public InvestigatorController controller;

    // Phase Switches
    [SerializeField] public bool performedUpkeep;
    [SerializeField] public bool performedMovement;
    [SerializeField] public bool hasArkhamEnc;
    [SerializeField] public bool performedArkhamEnc;
    [SerializeField] public bool hasOtherWorldEnc;
    [SerializeField] public bool performedOtherWorldEnc;

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
    public InvestigatorStats GetStats() { return stats; }
}
