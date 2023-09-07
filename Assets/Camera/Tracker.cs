using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Tracker : MonoBehaviour, InputActions.ICameraActions
{
    private InputActions controls;
    // Reference to the Main Camera
    [SerializeField] private Camera mainCamera;
    // Tracker Y Offset. This makes the camera a bit more "chest-centered" on most targets
    // May be worth investigating setting the offset based on the currently selected character (an enemy, even)
    private Vector3 trackerPositionOffset = new Vector3(0.0f, 1.75f, 0.0f);
    private Vector3 trackerRotationOffset = new Vector3(-60.0f, 0.0f, 0.0f);
    // Place the Camera 15 units above the tracker
    //private Vector3 cameraPositionOffset = new Vector3(0.0f, 15.0f, 0.0f);
    //private Vector3 cameraRotationOffset = new Vector3(90.0f, 0.0f, 0.0f);
    
    // Camera Movement Settings
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float zoomSpeed = 5.0f;
    //[SerializeField] private float hRotSpeed = 75.0f;
    //[SerializeField] private float vRotSpeed = 75.0f;
    private Vector2 movement;
    //private Vector3 motion;
    // Prevents rotation if the Right Mouse Button is not currently pressed.
    private bool canRotate = false;

    public float minZoomDistance = 15.0f;
    public float maxZoomDistance = 90.0f;
    //private Vector2 mouseDelta;

    [SerializeField] private GameObject currentActiveEntity; // TODO: access the selected character

    public float deltaYaw;
    public float deltaPitch;
    //private readonly float minRotClamp = -85.0f;
    //private readonly float maxRotClamp = -0.5f;

    // Camera test
    [SerializeField] CinemachineFreeLook vc;
    [Header("References")]
    [SerializeField] Transform orientation;
    [SerializeField] Transform tracker;
    [SerializeField] Transform trackerObj;
    // Rigidbody to move CameraTracker
    private Rigidbody rb;

    public void OnEnable()
    {
        canRotate = false;
        if (controls == null)
        {
            controls = new InputActions();
            controls.Camera.SetCallbacks(this);
        }
        controls.Camera.Enable();
    }
    public void OnDisable()
    {
        controls.Camera.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;

        

        this.transform.localEulerAngles = trackerRotationOffset;
        this.transform.position = currentActiveEntity.transform.position + trackerPositionOffset;
        vc = GameObject.FindGameObjectWithTag("TrackerCam").GetComponent<CinemachineFreeLook>();
        vc.m_YAxis.m_MaxSpeed = 0;
        vc.m_XAxis.m_MaxSpeed = 0;

        this.transform.position = currentActiveEntity.transform.position + trackerPositionOffset;
        this.transform.parent = currentActiveEntity.transform;
    }
    public void SetParent(GameObject focus)
    {
        currentActiveEntity = focus;
        vc.m_YAxis.m_MaxSpeed = 0;
        vc.m_XAxis.m_MaxSpeed = 0;
        this.transform.position = currentActiveEntity.transform.position + trackerPositionOffset;
        this.transform.parent = currentActiveEntity.transform;
    }
    public void OnMoveCamera(InputAction.CallbackContext context)
    {
        this.transform.parent = null;
        movement = context.ReadValue<Vector2>();
        Vector3 viewDir = mainCamera.transform.position - new Vector3(this.transform.position.x, mainCamera.transform.position.y, this.transform.position.z);
        orientation.forward = viewDir.normalized;
        Vector3 inputDir = orientation.forward * -movement.y + orientation.right * -movement.x;
        rb.velocity = inputDir.normalized * moveSpeed;
    }
    
    public void OnRotateCamera(InputAction.CallbackContext context)
    {
        if (context.performed) {
            canRotate = true;
            vc.m_YAxis.m_MaxSpeed = 2;
            vc.m_XAxis.m_MaxSpeed = 300;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (context.canceled) {
            canRotate = false;
            vc.m_YAxis.m_MaxSpeed = 0;
            vc.m_XAxis.m_MaxSpeed = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }


    // Snap Camera back to currently selected character.
    public void OnSnapToCurrentSelectedCharacter(InputAction.CallbackContext context)
    {
        this.transform.position = currentActiveEntity.transform.position + trackerPositionOffset;
        this.transform.parent = currentActiveEntity.transform;
    }
    // Zooms camera in and out from location
    public void OnZoom(InputAction.CallbackContext context)
    {
        //float fov = mainCamera.fieldOfView;
        float fov = vc.m_Lens.FieldOfView;
        fov += context.action.ReadValue<float>() * zoomSpeed * Time.deltaTime;
        fov = Mathf.Clamp(fov, minZoomDistance, maxZoomDistance);
        vc.m_Lens.FieldOfView = fov;
        //mainCamera.fieldOfView = fov;
    }

    public void OnRotateView(InputAction.CallbackContext context)
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 viewDir = mainCamera.transform.position - new Vector3(this.transform.position.x, mainCamera.transform.position.y, this.transform.position.z);
        orientation.forward = viewDir.normalized;
        Vector3 inputDir = orientation.forward * -movement.y + orientation.right * -movement.x;
        rb.velocity = inputDir.normalized * moveSpeed;
    }

    public void OnDeltaCamera(InputAction.CallbackContext context)
    {
        if (canRotate)
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); /*Would prefer to use the correct thing...*/
            Vector3 viewDir = mainCamera.transform.position - new Vector3(this.transform.position.x, mainCamera.transform.position.y, this.transform.position.z);
            orientation.forward = viewDir.normalized;
            Vector3 inputDir = orientation.forward * -movement.y + orientation.right * -movement.x;
            rb.velocity = inputDir.normalized * moveSpeed;
        }
    }
}