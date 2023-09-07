using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUIController : MonoBehaviour
{
    public TextMeshProUGUI mythosNameText;
    public TextMeshProUGUI subtypeText;
    public TextMeshProUGUI abilityText;
    public TextMeshProUGUI clueAppearsText;
    public Image gateImg;
    public TextMeshProUGUI gateAppearsText;
    public Image whiteMovers;
    public Image blackMovers;

    public void Init(CardSO data)
    {
        MythosCardSO mythosData = (MythosCardSO)data;
        mythosNameText.text = mythosData.cardName;
        subtypeText.text = mythosData.subtype.ToString();
        abilityText.text = mythosData.mythosAbilityText;
        clueAppearsText.text = $"<b>Clue Appears At:</b>\n{mythosData.clueAppears.gameTileName})";

        gateAppearsText.text = mythosData.gateAppears.gameTileName;
    }
}
