using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
// [ExecuteAlways]
public class PlayerMovement : MonoBehaviour
{

    // [SerializeField] CharacterController characterController;
    // [SerializeField] UserInput input;
    // [SerializeField] private Vector2 mouseDirection;
    // [SerializeField] private Vector2 inputDirection;
    // [SerializeField] private Vector3 velocity;
    // [SerializeField] public Vector2 horizontalVelocity = Vector2.zero;
    // [SerializeField] private float verticalVelocity = 0.0f;
    // [SerializeField] private bool isMovement;
    // [SerializeField] private bool isFloored;
    // [SerializeField] private float rayDistance = 0.1f; // Raycast length to check if player is grounded.
    // [SerializeField] private float jumpTime = 1;
    // [SerializeField] private float jumpTimeCounter;
    // [SerializeField] private float jumpHeight = 0.3f;
    // [SerializeField] private bool isJumping;
    // [SerializeField] private float gravity = 9.81f;
    // [SerializeField] private float gravityMultiplier = 3.0f;
    // [SerializeField] private float acceleration = 0.0f;
    // [SerializeField] private float deceleration = 0.0f;
    // [SerializeField] private float maxVelocity = 5.0f;
    // [SerializeField] private CollisionFlags move;
    // private Camera mainCamera;



    // void onCollision(CollisionFlags gameObject){
    //     // This prevents the spring snap effect, when the player is forcing against a wall.
    //     // The if statement does a bitwise check
    //     if ((gameObject & CollisionFlags.Sides) !=0){
   
    //         horizontalVelocity.x = -1 * (horizontalVelocity.x / 4);
    //         horizontalVelocity.y = -1 * (horizontalVelocity.y / 4);
    //         acceleration = 0.0f;
    //     }
    // }
    // void onAcceleration(){
    //     deceleration = 0.0f;
    //     acceleration += jerkAcceleration * 0.5f * Time.deltaTime;
    //     horizontalVelocity.x += inputDirection.x * acceleration * 0.5f * Time.deltaTime;
    //     horizontalVelocity.y += inputDirection.y * acceleration * 0.5f * Time.deltaTime;
    //     horizontalVelocity = Vector2.ClampMagnitude(horizontalVelocity,maxVelocity);
    // }
    // void onDeceleration(){
    //     if (horizontalVelocity.magnitude >0.1f){
    //         acceleration = 0.0f;
    //         deceleration += jerkDeceleration * 0.5f * Time.deltaTime;
    //         horizontalVelocity.x -= horizontalVelocity.normalized.x * deceleration * 0.5f * Time.deltaTime;
    //         horizontalVelocity.y -= horizontalVelocity.normalized.y * deceleration * 0.5f * Time.deltaTime;
    //     }
    //     else{
    //         acceleration = 0.0f;
    //         deceleration = 0.0f;
    //         horizontalVelocity = Vector2.zero;
    //     }
    // }
    // void onGravity(){
    //     isFloored = Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),rayDistance);
    //     if (!isFloored)
    //     {
    //         verticalVelocity -= gravity *gravityMultiplier* Time.deltaTime;
    //     }
    //     else if (velocity.y < 0.0f || characterController.isGrounded)
    //     {
    //         verticalVelocity = 0.0f;
    //     }
    // }
    // void onJump(){
    //     if (input.jumpKey() && isFloored)
    //     {
    //         jumpTimeCounter = jumpTime;
    //         isJumping = true;
    //         verticalVelocity = jumpHeight * gravity * gravityMultiplier;
    //     if (input.jumpKey() && isJumping){
    //         if (jumpTimeCounter > 0)
    //         {
    //             jumpTimeCounter -= Time.deltaTime;
    //             verticalVelocity = jumpHeight * gravity * gravityMultiplier;
    //         }
    //         else
    //         {
    //             isJumping = false;
    //         }

    //     }
    //     }  
    // }    
    // void onMovement(){
    //     mouseDirection = input.mouseAxis();
    //     inputDirection = input.inputDirection();
        
    //     bool isMovement = inputDirection.magnitude > 0.0;

    //     onGravity();

    //     if (isMovement){
    //         onAcceleration();
    //     }
    //     else{
    //         onDeceleration();
    //     }

    //     velocity = new Vector3(horizontalVelocity.x,verticalVelocity,horizontalVelocity.y);
    //     move = characterController.Move(velocity*Time.deltaTime);
    //     onCollision(move);
    // }



    // void Update()
    // {   

    //     onJump();
    //     onMovement();
    // }
}




    // void LateUpdate(){
    //     if (isFloored){
    //         Debug.DrawLine(transform.position,new Vector3(transform.position.x,transform.position.y-rayDistance,transform.position.z),Color.cyan);

    //     }
    //     else
    //     {
    //         Debug.DrawLine(transform.position,new Vector3(transform.position.x,transform.position.y-rayDistance,transform.position.z),Color.red);

    //     }
    //     Debug.DrawLine(transform.position,new Vector3(transform.position.x,transform.position.y,transform.position.z+4),Color.blue);
    // }
    
