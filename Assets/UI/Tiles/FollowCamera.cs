using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform camera;
    void Start()
    {
        if (camera == null) camera = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.LookAt(camera);
    }
}
