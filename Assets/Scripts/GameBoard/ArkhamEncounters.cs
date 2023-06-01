using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Arkham Encounter", menuName = "ScriptableObjects/ArkhamEncounters", order = 1)]
public class ArkhamEncounters : ScriptableObject
{
    // Not very necessary, but will allow in-editor changes to be a bit easier if you know which location is which. 
    public string locationOneName;
    public string locationTwoName;
    public string locationThreeName;

    public string[] locationOneEncs;
    public string[] locationTwoEncs;
    public string[] locationThreeEncs;
}
