using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
[ExecuteAlways]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] CharacterController characterController;
    [SerializeField] UserInput input;
    [SerializeField] private Vector2 mouseDirection;
    [SerializeField] private Vector3 inputDirection;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private Vector2 horizontalVelocity = Vector2.zero;
    [SerializeField] private float verticalVelocity = 0.0f;
    [SerializeField] private bool isMovement;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float rayDistance = 0.6f; // Raycast length to check if player is grounded.
    [SerializeField] private float gravity = 9.81f;
    [SerializeField] private float gravityMultiplier = 5.0f;
    [SerializeField] private float acceleration = 0.0f;
    [SerializeField] private float deceleration = 0.0f;
    [SerializeField] private float jerkAcceleration = 50.0f;
    [SerializeField] private float jerkDeceleration = 25.0f;
    [SerializeField] private float maxVelocity = 5.0f;
    [SerializeField] private CollisionFlags move;

    void onCollision(CollisionFlags gameObject){

        // This prevents the spring snap effect, when the player is forcing against a wall.
        // The if statement does a bitwise check
        if ((move & CollisionFlags.Sides) !=0){
            verticalVelocity = 0.0f;
            
        }
    }
    
    void onMovement(){
        inputDirection = input.Direction();
        mouseDirection = input.mouseAxis();
        
        bool isMovement = inputDirection.magnitude > 0.0;

        onGravity();
        if (isMovement)
        {
            deceleration = 0.0f;
            acceleration += jerkAcceleration * 0.5f * Time.deltaTime;
            horizontalVelocity.x += inputDirection.x * acceleration * 0.5f * Time.deltaTime;
            horizontalVelocity.y += inputDirection.y * acceleration * 0.5f * Time.deltaTime;

            horizontalVelocity = Vector2.ClampMagnitude(horizontalVelocity,maxVelocity);
        }
        else
        {
            if (horizontalVelocity.magnitude >0.1f){
                acceleration = 0.0f;
                deceleration += jerkDeceleration * 0.5f * Time.deltaTime;
                horizontalVelocity.x -= horizontalVelocity.normalized.x * deceleration * 0.5f * Time.deltaTime;
                horizontalVelocity.y -= horizontalVelocity.normalized.y * deceleration * 0.5f * Time.deltaTime;

            }
            else{
                acceleration = 0.0f;
                deceleration = 0.0f;
                horizontalVelocity = Vector2.zero;
            }
        }
        velocity = new Vector3(horizontalVelocity.x,verticalVelocity,horizontalVelocity.y);
        move = characterController.Move(velocity*Time.deltaTime);
        onCollision(move);
    }

    void onGravity(){

        isGrounded = Physics.Raycast(new Vector3(transform.position.x,transform.position.y,transform.position.z),Vector3.down,rayDistance);
        if (!isGrounded)
        {
            verticalVelocity -= gravity *gravityMultiplier* Time.deltaTime;
        }
        else if (velocity.y < 0.0f)
        {
            verticalVelocity = 0.0f;
        }

    }
    void Update()
    {   
        // Debug.Log(mouseDirection);
        onMovement();
    }
    void LateUpdate(){
        Debug.DrawLine(transform.position,new Vector3(transform.position.x,transform.position.y-rayDistance,transform.position.z),Color.red);
    }
    
}
