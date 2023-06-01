using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigator : MonoBehaviour
{
    [Header("Investigator Info")]
    [SerializeField] protected string investigatorName;
    [SerializeField] protected string profession;
    [SerializeField] protected string home;
    [SerializeField] public Inventory inventory;
    [SerializeField] protected List<Item> fixedPossessions;
    [SerializeField] protected Dictionary<int, string> randomPossessions;
    [SerializeField] protected InvestigatorStats stats;
    [Header("Camera Info")]
    [SerializeField] Tracker cam;

    [Header("Investigator Ability")]
    [SerializeField] protected string abilityName;
    [SerializeField] protected string abilityText;

    [Header("Investigator Story")]
    [SerializeField] protected string theStorySoFar;

    [Header("Controllers")]
    [SerializeField] public InvestigatorController _investigatorController;
    [SerializeField] public GameObject playerUI;
    [SerializeField] protected PlayerUIController _uiController;

    [Header("Phase Switches")]
    [SerializeField] public bool performedSetup;
    [SerializeField] public bool performedUpkeep;
    [SerializeField] public bool performedMovement;
    [SerializeField] public bool hasArkhamEnc;
    [SerializeField] public bool performedArkhamEnc;
    [SerializeField] public bool hasOtherWorldEnc;
    [SerializeField] public bool performedOtherWorldEnc;

    private void Start()
    {
        if (cam == null) cam = GameObject.FindGameObjectWithTag("Tracker").GetComponent<Tracker>();
        if (_investigatorController == null)
        {
            if ((_investigatorController = GetComponent<InvestigatorController>()) == null)
                Debug.LogError("Investigator: Unable to set InvestigatorController on " + investigatorName);
        }
        if (_uiController == null)
        {
            if ((_uiController = GetComponent<PlayerUIController>()) == null)
                Debug.LogError("Investigator: Unable to set UIController on " + investigatorName);
        }

        _uiController.gameObject.SetActive(false);
    }

    public void SetCurrentLocation(GameTile location)
    {
        _investigatorController.currentLocation = location;
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
        cam.SetParent(this.gameObject);
        switch (PhaseManager.instance.GetCurrentGamePhase())
        {
            case GamePhase.GameSetup:
                break;
            case GamePhase.InvestigatorSetup:
                InvestigatorSetup();
                break;
            case GamePhase.Upkeep:
                UpkeepPhase();
                break;
            case GamePhase.Movement:
                MovementPhase();
                break;
            case GamePhase.Combat:
                break;
            case GamePhase.ArkhamEncounter:
                ArkhamEncounterPhase();
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

    public void EndTurn()
    {
        switch (PhaseManager.instance.GetCurrentGamePhase())
        {
            case GamePhase.GameSetup:
                CompleteGameSetup();
                break;
            case GamePhase.InvestigatorSetup:
                break;
            case GamePhase.Upkeep:
                break;
            case GamePhase.Movement:
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

    private void CompleteGameSetup()
    {
        performedSetup = true;
        HideUI();
        PhaseManager.instance.UpdateGamePhase(GamePhase.InvestigatorSetup);
    }

    private void ArkhamEncounterPhase()
    {
        ShowUI();
        _uiController.showArkEnc();
    }

    private void InvestigatorSetup()
    {
        // Show sliders and set, 0 focus necessary.
        ShowUI();
        _uiController.InvestigatorSetup();
    }

    private void UpkeepPhase()
    {
        ShowUI();
        _uiController.showUpkeep();
    }

    private void MovementPhase()
    {
        // Show UI
        ShowUI();
        _uiController.showMovement();
        // Show locations in Range
        List<GameTile> tilesInRange = GameBoard.instance.GetLocationsInRange(_investigatorController.currentLocation, stats.GetSpeed());
        foreach(GameTile tile in tilesInRange)
        {
            tile.ShowUI();
        }
        // Let move
        _investigatorController.Move(tilesInRange);
    }
}