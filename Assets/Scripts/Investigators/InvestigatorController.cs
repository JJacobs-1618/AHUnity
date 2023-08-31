using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InvestigatorController : MonoBehaviour
{
    public Camera mainCamera;

    private PhaseManager pm;
    private GameBoard gb;

    private InputActions controls;
    // Movement Phase Related information. 
    // Probably best to move this to the InvestigatorSO, but that's a TODO
    private int movementPoints;
    private int availablePoints;
    private GameTile currentTile;

    private Investigator investigator;

    private Dictionary<NeighborhoodTile, int> reachableTiles;

    public int MovementPoints
    {
        get => movementPoints;
        set => movementPoints = value;
    }

    public GameTile CurrentTile
    {
        get => currentTile;
        set => currentTile = value;
    }
    private void Awake()
    {
        controls = new();
        reachableTiles = new();
    }

    private void OnEnable()
    {
        controls.Player.Select.performed += OnSelect;
        controls.Player.Enable();
    }

    private void Start()
    {
        pm = PhaseManager.instance;
        gb = GameBoard.instance;
        mainCamera = GameManager.instance.mainCamera;
    }

    public void InitMovementPhase()
    {
        // Are you In Arkham, an Outer World? LITAS?!
        availablePoints = movementPoints;
        reachableTiles.Clear();
        gb.GetReachableTiles((NeighborhoodTile)CurrentTile, MovementPoints, 0, ref reachableTiles); // Plus other movement bonuses
        foreach (GameTile gt in reachableTiles.Keys)
        {
            gt.DisplayMovementIcon(reachableTiles.GetValueOrDefault((NeighborhoodTile)gt));
        }
    }

    private void OnSelect(InputAction.CallbackContext obj)
    {
        Vector2 mousePos = Mouse.current.position.value;
        if (!Physics.Raycast(mainCamera.ScreenPointToRay(new(mousePos.x, mousePos.y)), out RaycastHit hit, 1000)) return;
        GameObject hitObj = hit.collider.gameObject;
        // Switch on CurrentGamePhase

        switch (pm.GetCurrentGamePhase())
        {
            case GamePhase.GameSetup:
                break;
            case GamePhase.InvestigatorSetup:
                break;
            case GamePhase.InitialMythos:
                break;
            case GamePhase.Upkeep:
                break;
            case GamePhase.Movement:
                MoveInvestigator(hitObj);
                break;
            case GamePhase.Combat:
                break;
            case GamePhase.ArkhamEncounter:
                break;
            case GamePhase.OtherWorldEncounter:
                break;
            case GamePhase.Mythos:
                break;
            case GamePhase.NextRound:
                break;
            case GamePhase.Any:
                break;
            case GamePhase.Paused:
                break;
        }
    }

    private void MoveInvestigator(GameObject hitObj)
    {
        if (reachableTiles.Count == 0) return;
        NeighborhoodTile nt = hitObj.GetComponent<NeighborhoodTile>();
        if (!reachableTiles.TryGetValue(nt, out int value)) return;

        if (nt == (NeighborhoodTile)CurrentTile)
        {
            EndTurn();
            return;
        }
        availablePoints = movementPoints;

        this.transform.position = hitObj.transform.position + new Vector3(0, 1, 0);
        investigator.CurrentTile = nt;

        availablePoints -= value;
        if (availablePoints == 0) EndTurn();
    }

    private void EndTurn()
    {
        switch (pm.GetCurrentGamePhase())
        {
            case GamePhase.GameSetup:
                break;
            case GamePhase.InvestigatorSetup:
                break;
            case GamePhase.InitialMythos:
                break;
            case GamePhase.Upkeep:
                break;
            case GamePhase.Movement:
                Debug.Log("Ending Movement Turn");
                foreach (GameTile gt in reachableTiles.Keys)
                {
                    gt.DisplayMovementIcon(0);
                }
                reachableTiles.Clear();
                investigator.data.hasPerformedMovement = true;
                pm.UpdateGamePhase(GamePhase.Movement);
                break;
            case GamePhase.Combat:
                break;
            case GamePhase.ArkhamEncounter:
                break;
            case GamePhase.OtherWorldEncounter:
                break;
            case GamePhase.Mythos:
                break;
            case GamePhase.NextRound:
                break;
            case GamePhase.Any:
                break;
            case GamePhase.Paused:
                break;
        }       
    }

    private void OnDisable()
    {
        controls.Player.Select.performed -= OnSelect;
        controls.Player.Disable();
    }

    public void SetInvestigator(Investigator i)
    {
        investigator = i;
    }

}
    /*
    InputActions controls;
    [SerializeField] public bool hasMoved;
    [SerializeField] GameObject selection;
    [SerializeField] PlayerUIController uiController;
    List<GameTile> inRange;
    [SerializeField] public GameTile currentLocation;

    private void Start()
    {
        inRange = new List<GameTile>();
    }
    private void OnEnable()
    {
        if (controls == null)
        {
            controls = new InputActions();
            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    public void Upkeep()
    {
        StartCoroutine(PlayerUpkeep());
    }

    public void Move(List<GameTile> tiles)
    {
        inRange = tiles;
        StartCoroutine(PlayerMovement());
    }
    IEnumerator WaitForSelection()
    {
        bool selected = false;
        while (!selected)
        {
            if (selection != null)
            {
                selected = true;
                yield return null;
            }
            if (hasMoved == true)
                yield break;
            yield return new WaitForSeconds(.1f);
        }
    }

    private IEnumerator PlayerUpkeep()
    {

        yield return null;
    }

    private IEnumerator PlayerMovement()
    {
        uiController.showMovement();
        selection = null;
        yield return StartCoroutine(WaitForSelection());

        if (selection == null) { Debug.Log("UGH"); }
        else
        {
            Debug.Log(selection.name);
            this.transform.position = selection.transform.position;
            currentLocation = selection.GetComponent<GameTile>();
            if (currentLocation == null) Debug.LogError("Error setting Current Location in Controller");
            foreach(GameTile tile in inRange)
            {
               // tile.HideUI();
            }
        }
        yield return null;
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        switch (PhaseManager.instance.GetCurrentGamePhase())
        {
            case GamePhase.GameSetup:
                break;
            case GamePhase.Upkeep:
                break;
            case GamePhase.Movement:
                MovementSelection();
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

    private void MovementSelection()
    {
        int layerMask = 1 << 8;
        RaycastHit hit;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out hit, Mathf.Infinity, layerMask))
        {
            selection = hit.collider.gameObject;
            if (!inRange.Contains(selection.GetComponent<GameTile>()))
                selection = null;
        }
    }

    public void OnUnselect(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
    public void CancelSelection()
    {
        StopAllCoroutines();
    }
    public void SetCurrentLocation(GameTile location)
    {
        currentLocation = location;
    }

    public void ResetMovement()
    {

    }
    */
