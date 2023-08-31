using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MythosCardSO", menuName = "Scriptables/GameBoard/Mythos")]
public class MythosCardSO : CardSO
{
    public MythosSubtype subtype;

    public LocationTileSO gateAppears;
    public LocationTileSO clueAppears;
    public DimensionSymbolType dimensionSymbol;
    [TextArea(5, 10)]
    public string mythosAbilityText;

    public MythosCardSO()
    {
        cardName = "Card Name Here";
        flavorText = "Flavor Text Here. Clear this field if none exists OR make up your own?";
        subtype = MythosSubtype.MythosSubtype;
        gateAppears = null;
        clueAppears = null;
        dimensionSymbol = DimensionSymbolType.DimensionSymbol;
        mythosAbilityText = "Ability Text Here";
    }
}
