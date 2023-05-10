using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Ability : MonoBehaviour
{
    [SerializeField] public string abilityName;
    [SerializeField] public string abilityDescription;
    [SerializeField] public GamePhase phaseType;

    protected virtual void Execute()
    {
        
    }
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
