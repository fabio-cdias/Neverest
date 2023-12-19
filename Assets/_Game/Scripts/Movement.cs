using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    public Vector3 direction;
    public CharacterController characterController;
    public Vector2 turn;
    public Vector2 input;
    float sensitivity = 3.0f;
    public Vector3 velocity;
    public float acceleration = .8f;
    public float deceleration = 0.001f;
    public float maxVelocity = 4f;
    public bool isGrounded;
    public bool isFloored;
    public float gravity = 9.8f;
    public float gravityMultiplier = 3f;
    [SerializeField] private float rayDistance = 0.1f; // Raycast length to check if player is grounded.



    [SerializeField] private float jumpHeight = 0.4f;
    [SerializeField] private bool isJumping;

    public KeyCode jump = KeyCode.Space;
    public KeyCode run = KeyCode.LeftShift;







    private Camera mainCamera;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    void onGravity(){
        isFloored = Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),rayDistance);
        if (!isFloored)
        {
            velocity.y -= gravity * gravityMultiplier* Time.deltaTime;
        }
        else if (velocity.y < 0.0f || characterController.isGrounded)
        {
            velocity.y = -gravityMultiplier * 0.5f * Time.deltaTime;        }
    }

    bool isMoving(){
        return input.magnitude != 0f;
    }
    
    public bool jumpKey(){
        return Input.GetKeyDown(jump);        
    }

    public bool runKey(){
        return Input.GetKey(run);
    }

    void onJump(){if (jumpKey() && isFloored){velocity.y += jumpHeight * gravity * gravityMultiplier;}}   

    void onAcceleration(){
        if (!isMoving()){
            if (velocity.magnitude < maxVelocity){
                velocity.x += acceleration * .5f * Time.deltaTime;
                velocity.y += acceleration * .5f * Time.deltaTime;
            }
        }
    }
    void onDeceleration(){
        if (isMoving()){
            if (velocity.magnitude > 0){
                velocity.x -= acceleration * .5f * Time.deltaTime;
                velocity.y -= acceleration * .5f * Time.deltaTime;
            }
        } 
    }
    void onRun(){
        if (runKey()){
            if (maxVelocity < 10){
                maxVelocity+= 0.1f;
            }
        }
        else{
            if (maxVelocity > 4){
                maxVelocity -= 0.1f;

            }
        }
    }
    void onMove(){
 
        // This is the local forward vector of the player, in the global world.
        Vector3 localforward = transform.forward;
        Vector3 localright = transform.right;

        
        // Rotate the player locally, based on the mouse x input rotating in the Y axis.
        transform.localRotation = Quaternion.Euler(0,turn.x,0);

        direction = input.x * localright + localforward * input.y;
        direction.Normalize();
        velocity = new Vector3(direction.x*maxVelocity,velocity.y,direction.z*maxVelocity);

        characterController.Move(velocity*Time.deltaTime);
    }




    void Update()
    {
        input = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        onRun();
        onGravity();
        onAcceleration();
        onDeceleration();
        onJump();
        onMove();
       

    }















    // void onMove(){
        
    //     turn.x += Input.GetAxis("Mouse X") * sensitivity;
    //     turn.y += Input.GetAxis("Mouse Y") * sensitivity;

    //     // This is the local forward vector of the player, in the global world.
    //     Vector3 localforward = transform.forward;
    //     Vector3 localright = transform.right;

    //     // Rotate the player locally, based on the mouse x input rotating in the Y axis.
    //     transform.localRotation = Quaternion.Euler(0,turn.x,0);

    //     direction = Input.GetAxis("Horizontal")*localright + localforward * Input.GetAxis("Vertical");
    //     direction.Normalize();

    //     // Calculate acceleration
    //     float targetSpeed = maxVelocity * direction.magnitude;
    //     currentVelocity = Mathf.Lerp(currentVelocity, targetSpeed, Time.deltaTime * acceleration);

    //     // Calculate movement direction with acceleration
    //     direction = direction * currentVelocity;

    //     // Apply deceleration if no input
    //     if (direction.magnitude < 0.1f)
    //     {
    //         currentVelocity = Mathf.Lerp(currentVelocity, 0f, Time.deltaTime * deceleration);
    //     }

    //     characterController.Move(direction*Time.deltaTime);
    // }

    // void Update()
    // {
    //     onMove();

    // }


}
   

