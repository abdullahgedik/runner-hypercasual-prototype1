using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject upperPart;


    [Header("Settings")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float sidewaySpeed;

    // Player position between -3.460153f to 3.460153f
    private bool isCrouching = false;

    void Start()
    {
        
    }

    void Update()
    {
        Move();

        Jump();

        Crouch();
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(groundCheck.position, Vector3.down, 0.25f, layerMask);
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 3 && IsGrounded() && MathF.Abs(rb.velocity.x) < 0.25f && !isCrouching)
        {
            rb.velocity = new Vector3(sidewaySpeed, rb.velocity.y, rb.velocity.z);
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -3 && IsGrounded() && MathF.Abs(rb.velocity.x) < 0.25f && !isCrouching)
        {
            rb.velocity = new Vector3(-sidewaySpeed, rb.velocity.y, rb.velocity.z);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded() && MathF.Abs(rb.velocity.x) < 0.25f && !isCrouching)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.S) && IsGrounded() && MathF.Abs(rb.velocity.x) < 0.25f && !isCrouching)
        {
            StartCoroutine(CrouchTimer());
        }
    }

    IEnumerator CrouchTimer()
    {
        isCrouching = true;
        upperPart.gameObject.SetActive(false);

        yield return new WaitForSeconds(.8f);

        upperPart.gameObject.SetActive(true);
        isCrouching = false;
    }
}
