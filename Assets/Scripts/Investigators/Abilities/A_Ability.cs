using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class A_Ability : ScriptableObject
{
    [SerializeField] public string abilityName;
    [SerializeField] public string abilityDescription;
    [SerializeField] public GamePhase phaseType;

    public abstract void Execute();
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
