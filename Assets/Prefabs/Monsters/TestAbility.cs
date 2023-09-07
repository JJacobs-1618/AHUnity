using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ABI_HoundOfTindalos", menuName = "Arkham/Monsters/Abilities/HoT")]
public class TestAbility : A_Ability    
{    
    public override void Execute()
    {
        Debug.Log("Hound of Tindalos moves");
        foreach (Investigator i in GameManager.instance.CurrentInvestigators)
        {
            i.UpdateStamina(-1);
        }
    }
}
