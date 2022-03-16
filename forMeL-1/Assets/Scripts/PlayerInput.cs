using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Acceleration { get; private set; }
    public float Turning { get; private set; }

    private void Update()
    {
        Acceleration = Input.GetAxis("Vertical");
        Turning = Input.GetAxis("Horizontal");
    }
}
