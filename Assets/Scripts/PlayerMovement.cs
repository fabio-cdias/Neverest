using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] CharacterController characterController;
    [SerializeField] UserInput input;
    [SerializeField] public Vector2 mouseDirection;
    [SerializeField] private Vector3 inputDirection;
    [SerializeField] private Vector3 currentDirection;
    [SerializeField] private Vector3 velocity = Vector3.zero;
    [SerializeField] private bool isMovement;
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float gravityMultiplier = 5.0f;
    [SerializeField] private float acceleration = 100.0f;
    [SerializeField] private float deceleration = 150.0f;
    [SerializeField] private float maxVelocity = 10.0f;



    void onMovement(){
        inputDirection = input.Direction();
        mouseDirection = input.mouseAxis();
        
        currentDirection= inputDirection;
        bool isMovement = inputDirection.magnitude > 0.0;
        
        onGravity();
        if (isMovement)
        {
            velocity.x += currentDirection.x * acceleration * 0.5f * Time.deltaTime;
            velocity.z += currentDirection.z * acceleration * 0.5f * Time.deltaTime;

            velocity = Vector3.ClampMagnitude(velocity,maxVelocity);
        }
        else
        {
            if (velocity.magnitude > 0.1f){
                velocity.x-= velocity.normalized.x * deceleration * 0.5f * Time.deltaTime;
                velocity.z -= velocity.normalized.z * deceleration * 0.5f * Time.deltaTime;

            }
            else{
                velocity.x = 0.0f;
                velocity.z = 0.0f;
            }
        }
        characterController.Move(velocity*Time.deltaTime);
    }

    void onGravity(){
        if (characterController.isGrounded && velocity.y < 0.0f){
            velocity.y = -0.01f;
        }
        else{ 
            velocity.y -= gravity *gravityMultiplier* Time.deltaTime;
        }
    }
    void Update()
    {   
        Debug.Log(mouseDirection);
        onMovement();
    }
}
