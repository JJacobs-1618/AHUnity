using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{   
    [Header("Parent Investigator Reference")]
    [SerializeField] Investigator investigator;
    [Header("Sub-UI References")]
    [SerializeField] GameObject playerDetailsUI;
    [SerializeField] GameObject statSliderUI;
    [SerializeField] GameObject upkeepUI;
    [SerializeField] GameObject movementUI;
    [SerializeField] GameObject arkhamEncUI;
    [SerializeField] GameObject otherWorldEncUI;
    [SerializeField] GameObject mythosUI;

    // Controller References
    PlayerDetailsUIController playerDetailsUIController;
    StatSliderUIController statSliderUIController;
    UpkeepUIController upkeepUIController;
    

    private void Start()
    {
        playerDetailsUI.SetActive(true);
        playerDetailsUIController = playerDetailsUI.GetComponent<PlayerDetailsUIController>();
        statSliderUI.SetActive(false);
        statSliderUIController = statSliderUI.GetComponent<StatSliderUIController>();
        upkeepUI.SetActive(false);
        upkeepUIController = upkeepUI.GetComponent<UpkeepUIController>();
        movementUI.SetActive(false);
        arkhamEncUI.SetActive(false);
        otherWorldEncUI.SetActive(false);
        mythosUI.SetActive(false);
    }

    public Investigator GetInvestigator() { return investigator; }
    internal void InvestigatorSetup()
    {
        statSliderUI.SetActive(true);
        statSliderUIController.InitialSetup();
    }

    public void showUpkeep() 
    {
        statSliderUI.SetActive(true);
        statSliderUI.GetComponent<StatSliderUIController>().StartUpkeep();
        upkeepUI.SetActive(true);
    }
    public void hideUpkeep() 
    {
        statSliderUIController.CloseSliders();
        upkeepUI.SetActive(false); 
    }
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
