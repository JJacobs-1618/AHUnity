using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigator : MonoBehaviour
{
    [SerializeField] protected string investigatorName;
    [SerializeField] protected string profession;
    [SerializeField] protected string home;
    [SerializeField] protected List<Item> fixedPossessions;
    [SerializeField] protected Dictionary<int, string> randomPossessions;
    [SerializeField] protected string abilityName;
    [SerializeField] protected string abilityText;
    [SerializeField] protected string theStorySoFar;
    [SerializeField] protected InvestigatorStats stats;
    [SerializeField] public Inventory inventory;
    [SerializeField] public InvestigatorController controller;
    [SerializeField] protected PlayerUIController uiController;
    [SerializeField] public GameObject playerUI;

    // Phase Switches
    [SerializeField] public bool performedUpkeep;
    [SerializeField] public bool performedMovement;
    [SerializeField] public bool hasArkhamEnc;
    [SerializeField] public bool performedArkhamEnc;
    [SerializeField] public bool hasOtherWorldEnc;
    [SerializeField] public bool performedOtherWorldEnc;

    private void Start()
    {
        uiController = playerUI.GetComponent<PlayerUIController>();
        playerUI.SetActive(false);
    }

    private void Update()
    {
        
    }

    public void SetCurrentLocation(GameTile location)
    {
        controller.currentLocation = location;
    }
    public string GetName()
    {
        return investigatorName;
    }
    public string GetProfession()
    {
        return profession;
    }
    public string GetHome()
    {
        return home;
    }    
    public InvestigatorStats GetStats() { return stats; }
    public Inventory GetInventory() { return inventory; }

    public void ShowUI()
    {
        playerUI.SetActive(true);
    }
    public void HideUI()
    {
        playerUI.SetActive(false);
    }


    public void PlayerTurn()
    {
        switch (PhaseManager.instance.GetCurrentGamePhase())
        {
            case GamePhase.GameSetup:
                break;
            case GamePhase.Upkeep:
                break;
            case GamePhase.Movement:
                MovementPhase();
                break;
            case GamePhase.Combat:
                break;
            case GamePhase.ArkhamEncounter:
                break;
            case GamePhase.OtherWorldEncounter:
                break;
            case GamePhase.Mythos:
                break;
            case GamePhase.Any:
                break;
            case GamePhase.Paused:
                break;
        }
    }

    private void MovementPhase()
    {
        // Show UI
        ShowUI();
        uiController.showMovement();
        // Show locations in Range
        List<GameTile> tilesInRange = GameBoard.instance.GetLocationsInRange(controller.currentLocation, stats.speed);
        foreach(GameTile tile in tilesInRange)
        {
            tile.ShowUI();
        }
        // Let move
        controller.Move(tilesInRange);
    }
}
