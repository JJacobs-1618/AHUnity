using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour, InputActions.ICameraActions
{
    [SerializeField] Camera main;

    // Start is called before the first frame update
    void Start()
    {
        if (main == null) main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDeltaCamera(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMoveCamera(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnRotateCamera(InputAction.CallbackContext context)
    {
        
    }
}
