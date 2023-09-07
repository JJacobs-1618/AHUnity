using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gate Data", menuName = "Arkham/Gameboard/Gate")]
public class GateSO : ScriptableObject
{
    public string gateName;
    public int GateDifficulty;
    public DimensionSymbolType symbol;
}
