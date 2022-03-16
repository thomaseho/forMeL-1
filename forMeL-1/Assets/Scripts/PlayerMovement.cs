using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    
    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    
    private void Awake()
    {
        _rigidbody = GetComponentInChildren<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void LateUpdate()
    {
        MoveVehicle();   
    }

    private void MoveVehicle()
    {
        Vector3 forward = transform.forward;
        forward.z *= _playerInput.Acceleration;
        _rigidbody.velocity = forward * speed * Time.deltaTime;
    }
}
