using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InvestigatorController : MonoBehaviour, InputActions.IPlayerActions
{
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
}
