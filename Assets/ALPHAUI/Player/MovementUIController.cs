using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MovementUIController : MonoBehaviour
{
    /*
    [SerializeField] PlayerUIController uiController;
    [SerializeField] InvestigatorStats stats;
    [SerializeField] Investigator investigator;
    [SerializeField] TextMeshProUGUI movementPointText;

    private void Start()
    {
        if (uiController == null)
        {
            if ((uiController = GetComponentInParent<PlayerUIController>()) == null)
            {
                Debug.LogError("Error Setting ParentUIController in Movement UI. Suggestion to set manually in editor.");
            }
        }
        if (investigator == null && uiController != null) investigator = uiController.GetInvestigator();
        if (stats == null && investigator != null) stats = investigator.GetStats();
        TextMeshProUGUI[] tmps = GetComponentsInChildren<TextMeshProUGUI>(true);
    }
    public void UpdateMovementPointText()
    {
        movementPointText.text = stats.GetSpeed().ToString(); // Add other movement modifiers, too
    }
    public void Continue()
    {
        investigator._investigatorController.CancelSelection();
        investigator._investigatorController.hasMoved = true;
        investigator.performedMovement = true;
        uiController.hideMovement();
        investigator.HideUI();
        PhaseManager.instance.UpdateGamePhase(GamePhase.Movement);
    }
    */
}
