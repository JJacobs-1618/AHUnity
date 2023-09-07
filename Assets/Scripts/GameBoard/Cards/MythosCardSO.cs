using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mythos Data", menuName = "Arkham/Gameboard/Cards/Mythos")]
public class MythosCardSO : CardSO
{
    public MythosSubtype subtype;
    [TextArea(5, 10)]
    public string mythosAbilityText;
    public LocationTileSO gateAppears;
    public LocationTileSO clueAppears;
    public List<DimensionSymbolType> blackMovers;
    public List<DimensionSymbolType> whiteMovers;
    // public AbilitySO Ability;

    public MythosCardSO()
    {
        cardName = "Card Name Here";
        mythosAbilityText = "Ability Text Here";
        subtype = MythosSubtype.MythosSubtype;
        gateAppears = null;
        clueAppears = null;
        blackMovers = new();
        whiteMovers = new();
        // Ability = null;
    }

    public LocationTileSO GateAppears
    {
        get => gateAppears;
    }
}
