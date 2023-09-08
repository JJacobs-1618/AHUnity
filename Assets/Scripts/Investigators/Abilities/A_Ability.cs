using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class A_Ability : ScriptableObject
{
    public string abilityName;
    public string abilityDescription;
    public GamePhase phaseType;
    

    public abstract void Execute(GameObject self);
}

public enum AbilityPhase
{
    Any,
    Upkeep,
    Movement,
    ArkhamEncounter,
    OtherWorldEncounter,
    Mythos
}
