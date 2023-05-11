using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] GameObject playerDetailsUI;
    [SerializeField] GameObject upkeepUI;
    [SerializeField] GameObject movementUI;
    [SerializeField] GameObject arkhamEncUI;
    [SerializeField] GameObject otherWorldEncUI;
    [SerializeField] GameObject mythosUI;
    [SerializeField] Investigator investigator;

    private void Start()
    {
        playerDetailsUI.SetActive(true);
        upkeepUI.SetActive(false);
        movementUI.SetActive(false);
        arkhamEncUI.SetActive(false);
        otherWorldEncUI.SetActive(false);
        mythosUI.SetActive(false);
    }

    public Investigator GetInvestigator() { return investigator; }
    public void showUpkeep() { upkeepUI.SetActive(true); }
    public void hideUpkeep() { upkeepUI.SetActive(false); }
    public void showMovement() 
    { 
        movementUI.SetActive(true);
        if(movementUI.activeSelf)
            movementUI.GetComponent<MovementUIController>().UpdateMovementPointText();
    }
    public void hideMovement() { movementUI.SetActive(false); }
    public void showArkEnc() { arkhamEncUI.SetActive(true); }
    public void hideArkEnc() { arkhamEncUI.SetActive(false); }
    public void showOWEnc() { otherWorldEncUI.SetActive(true); }
    public void hideOWEnc() { otherWorldEncUI.SetActive(false); }
    public void showMythos() { mythosUI.SetActive(true); }
    public void hideMythos() { mythosUI.SetActive(false); }
}
