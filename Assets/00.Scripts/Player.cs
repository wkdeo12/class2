using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 3f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        rb.MovePosition(rb.position+Vector3.right*h*speed*Time.deltaTime);
    }
}
