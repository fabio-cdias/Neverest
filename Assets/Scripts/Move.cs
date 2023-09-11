using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController player_controller;
    public float h_axis;
    public float v_axis;
    public Vector3 direction;
    public Transform cam;
    public float turnsmooth;
  

    public GameObject maincam;
    public Vector3 cam_forward;
    public Vector3 cam_right;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

        // Get the input from user.
        // Getting the H axis(A D or arrow left right)
        // Getting the V axis(W S or arrow up down)
        h_axis = Input.GetAxis("Horizontal");
        v_axis = Input.GetAxis("Vertical");
        
        // cam_forward = maincam.transform.forward;
        // cam_right = maincam.transform.right;

        // cam_forward.y= 0;
        // cam_right.y = 0;

        // cam_forward = cam_forward.normalized;
        // cam_right = cam_right.normalized;

        // Vector3 forwardToCam = h_axis * cam_forward;
        // Vector3 rightToCam = v_axis * cam_right;

        // Vector3 playerRelativeCam = forwardToCam + rightToCam;
        
        // this.transform.Translate(playerRelativeCam*Time.deltaTime);

        
        
        Vector3 direction = new Vector3(h_axis,0,v_axis).normalized;
        transform.Translate(direction*Time.deltaTime*5,Space.World);
        Quaternion rotateto = Quaternion.LookRotation(maincam.transform.position,Vector3.up);
        transform.rotation= Quaternion.RotateTowards(transform.rotation,rotateto,8);
        Debug.DrawRay(transform.position,direction*30,Color.red,2);
        // Debug.DrawRay(transform.position,direction*15,Color.green,2);



        // Creates a 3D Vector based on the user input, x and z directions
        
        // transform.Translate(direction);
        // if (direction != Vector3.zero){
        //     transform.forward = direction;
        //     direction = transform.position;
        // }
        // angle = Mathf.Atan2(direction.x,direction.z);
        // transform.localRotation = Quaternion.LookRotation,Vector3.up);










      
        // Checks if the the user input vector isn´t zero, otherwise the rotation
        // values get reseted
        
        // transform.forward += direction;
        // if (direction.magnitude >= 0.1f){
        //     // Creates a quaternion rotation facing forward to where player are moving
        //     float dir_angle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //     float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,dir_angle,ref turnsmooth,0.1f);
        //     // Quaternion rotate = Quaternion.LookRotation(direction, Vector3.up);

        //     // Actually rotate the player based on the previous quaternion rotation
        //     transform.localRotation = Quaternion.Euler(0f,angle,0f);
        //     Vector3 move_direction = Quaternion.Euler(0f,dir_angle,0f)* Vector3.forward;
        //     player_controller.Move(move_direction * 5 * Time.deltaTime);
        // }
        
        // Moves the player altering the transform position, get its current position
        // and sum with the direction the user wants the player to move.
        // transform.position += direction * 10 *Time.deltaTime;
        // transform.Translate( * 4 * Time.deltaTime);

    }
}
