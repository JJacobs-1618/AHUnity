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

    public void Move()
    {
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
            yield return new WaitForSeconds(.25f);
        }
    }

    private IEnumerator PlayerMovement()
    {
        selection = null;
        yield return StartCoroutine(WaitForSelection());

        if (selection == null) { Debug.Log("UGH"); }
        else
        {
            Debug.Log(selection.name);
            this.transform.position = selection.transform.position;
        }
        hasMoved = true;
        PhaseManager.instance.UpdateGamePhase(GamePhase.Movement);
        yield return null;
    }

    public void OnSelect(InputAction.CallbackContext context)
    {
        int layerMask = 1 << 8;
        RaycastHit hit;
        Vector3 mousePos = Mouse.current.position.ReadValue();
        if(Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out hit, Mathf.Infinity, layerMask))
        {
            selection = hit.collider.gameObject;
        }
    }

    public void OnUnselect(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
