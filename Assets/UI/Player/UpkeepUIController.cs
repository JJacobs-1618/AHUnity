using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpkeepUIController : MonoBehaviour
{
    [SerializeField] PlayerUIController uiController;
    [SerializeField] Investigator investigator;
    [SerializeField] TextMeshProUGUI investigatorName;


    private void Start()
    {
        if (investigator == null) investigator = uiController.GetInvestigator();
        if (investigator != null) investigatorName.text = investigator.GetName() + " Upkeep";
    }

    public void Continue()
    {
        investigator.performedUpkeep = true;
        this.uiController.hideUpkeep();
        PhaseManager.instance.UpdateGamePhase(GamePhase.Upkeep);
    }
}
