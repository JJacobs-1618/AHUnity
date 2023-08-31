using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InvestigatorSO", menuName = "Arkham/Investigator Data")]
public class InvestigatorSO : ScriptableObject
{
    [Header("Investigator Information", order = 0)]
    public string investigatorName;
    [TextArea(5,20)]
    public string investigatorStory;
    public string home;
    [Header("Investigator Stats", order = 1)]
    public int maxSanity;
    public int currentSanity;
    public int maxStamina;
    public int currentStamina;
    [Header("Investigator Inventory Setup", order = 2)]
    public InventorySO inventory;
    // public List<ItemSO> fixedPossessions;
    public int[] randomPossessions;
    //[Header("Investigator Abilit(y/ies)", order = 3)]
    //public AbilitySO ability;
    [Header("Investigator Skill Slider", order = 4)]
    public int focus;
    public int speed;
    public int sneak;
    public int fight;
    public int will;
    public int lore;
    public int luck;
    [Header("Investigator Phase Information")]
    public bool hasPerformedUpkeep;
    public bool hasPerformedMovement;
    public bool hasPerformedArkhamEncounter;
    public bool hasPerformedOtherWorldEncounter;

    [Header("Investigator Placement Offset", order = 5)]
    public Vector3 placementOffset = new(0, 1, 0); // TODO: investigator controls? Idunno...
    
    public InvestigatorSO()
    {
        investigatorName = "Name Unset";
        investigatorStory = "Type Story So Far here";
        home = "Home Unset";

        maxSanity = currentSanity = 0;
        maxStamina = currentStamina = 0;

        // fixedPossesions = new List<ItemSO>();
        randomPossessions = new int[4]; // Each one indicates number of Common, Unique, Spell, Skill cards to draw.

        focus = 0;
        speed = 0;
        sneak = 0;
        fight = 0;
        will  = 0;
        lore  = 0;
        luck  = 0;
    }
}
