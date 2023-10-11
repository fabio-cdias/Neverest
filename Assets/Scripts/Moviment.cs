using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    private Vector3 playerInputs;
    private CharacterController characterController;
    private float walkSpeed = 2.0f;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float RunSpeed;
    private float sprintSpeed = 5.33f;
    [Tooltip("The height the player can jump")]
    [SerializeField] private float JumpHeight = 1.2f;
    private float gravity = -9.81f;
    private float verticalSpeed;
    private Transform myCamera;
    private bool grounded;
    public bool isSprinting = false;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask cenarioMask;
    private Animator animator;

    // StaminaController
    [HideInInspector] public Stamina _staminaController;
    void Awake()
    {
        _staminaController = GetComponent<Stamina>();
        characterController = GetComponent<CharacterController>();
        // erro de null reference ao instanciar a camera
        // eh referente a tag da camera não estar em mainCamera
        //https://stackoverflow.com/questions/52242441/camera-main-null-reference-exception
        myCamera = Camera.main.transform;
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetRunSpeed(float speed)
    {
        RunSpeed = speed;
    }

    public void PlayerJump()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Move();

    }

    void Move()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, myCamera.eulerAngles.y, transform.eulerAngles.z);
        
        playerInputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        playerInputs = transform.TransformDirection(playerInputs);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            
        }
        else
        {
            isSprinting = false;
            _staminaController.weAreSprinting = false;
            animator.SetBool("sprinting", false);
            
        }        
        
        if(isSprinting && characterController.velocity.sqrMagnitude > 0)
        {
            if(_staminaController.playerStamina > 0)
            {
                _staminaController.weAreSprinting = true;
                _staminaController.Sprinting();
                animator.SetBool("sprinting", true);
            }
            else
            {
                _staminaController.weAreSprinting = false;
                animator.SetBool("sprinting", false);
                isSprinting = false;
            }
        }
        if(isSprinting)
        {
            speed = RunSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        characterController.Move(playerInputs * Time.deltaTime * speed);
        grounded = Physics.CheckSphere(groundCheck.position, 0.3f, cenarioMask);

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            verticalSpeed = Mathf.Sqrt(JumpHeight * -2.0f * gravity);
        }
        if(grounded && verticalSpeed < 0)
        {
            verticalSpeed = -1.0f;
        }
        verticalSpeed += gravity * Time.deltaTime;
        characterController.Move(new Vector3(0, verticalSpeed, 0) * Time.deltaTime);



        if(playerInputs != Vector3.zero)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }
}
