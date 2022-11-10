using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float walkForce = 10f;
    [SerializeField] float jumpForce = 10f;
    
    Vector2 axisValues;
    Rigidbody2D myRigidBody2D;

    private void Awake() 
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate() 
    {
        Move();
    }

    private void Move()
    {
        if (axisValues.sqrMagnitude < 0.01) { return; }

        // add force já tem ou não uma multiplicação como deltatime, isso varia conforme o modo
        //var scaledSpeed = speed * Time.fixedDeltaTime;
        var newPosition = new Vector2(axisValues.x * walkForce, 0f);
        
        myRigidBody2D.AddForce(newPosition);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        axisValues = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Jump();
        }
    }

    private void Jump()
    {
        print("Pulei");
        myRigidBody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //myRigidBody2D.velocity = (new Vector2(0, jumpForce));
    }
}
