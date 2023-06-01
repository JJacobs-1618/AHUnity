using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArkhamEncounterUIController : MonoBehaviour
{
    public PlayerUIController controller;
    public TextMeshProUGUI encounterText;

    public void SetEncounterText(string text)
    {
        encounterText.text = text;
    }
    public void Continue()
    {
        controller.hideArkEnc();
        controller.GetInvestigator().performedArkhamEnc = true;
        PhaseManager.instance.UpdateGamePhase(GamePhase.ArkhamEncounter);
    }
}
