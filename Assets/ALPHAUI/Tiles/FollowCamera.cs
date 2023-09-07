using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform m_Camera;
    void Start()
    {
        if (m_Camera == null) m_Camera = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.LookAt(m_Camera);
    }
}
