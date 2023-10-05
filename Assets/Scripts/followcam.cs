using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class followcam : MonoBehaviour
{     
    public float h_axis;
    public float v_axis;

    public Vector3 facefwd;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        h_axis = Input.GetAxis("Horizontal");
        v_axis = Input.GetAxis("Vertical");

        

        // Creates a 3D Vector based on the user input, x and z directions
        // facefwd = new Vector3(h_axis,0,v_axis);
        

        // Debug.DrawRay(transform.position,facefwd*30,Color.red);
        // Debug.DrawRay(transform.position,facefwd*15,Color.green,2);

        // Moves the player altering the transform position, get its current position
        // and sum with the direction the user wants the player to move.
        // transform.position += facefwd * 10 *Time.deltaTime;
        // transform.Translate( * 4 * Time.deltaTime);

        // Checks if the the user input vector isn´t zero, otherwise the rotation
        // values get reseted
        // if (facefwd != Vector3.zero)
        // {
        // // Creates a quaternion rotation facing forward to where player are moving
        // Quaternion rotate = Quaternion.LookRotation(facefwd, Vector3.up);
        // // Actually rotate the player based on the previous quaternion rotation
        // transform.rotation = Quaternion.RotateTowards(transform.rotation,rotate,8);
        // }
    }
    
    
    // LateUpdate is called once per frame after Update
    // void LateUpdate()
    // {   
        // transform.LookAt(follow.transform.position);
        // transform.rotation = Quaternion.LookRotation(follow.transform.localPosition-transform.position);
        //transform.position = follow.transform.localPosition + offset;
        // newpos = follow.transform.position - transform.position ;
        // transform.position = newpos;
        // transform.RotateAround(follow.transform.position-transform.position+offset,Vector3.up,20* Time.deltaTime);
        // transform.position = Vector3.Lerp(transform.position+offset,follow.transform.position,pos_lerp);
        // transform.rotation = Quaternion.Lerp(transform.rotation,follow.transform.rotation,rot_lerp);
        // transform.position = follow.transform.position + offset;
        // Quaternion lookat = Quaternion.LookRotation(transform.position-follow.transform.position,Vector3.up);
        // transform.rotation = lookat;
        // Debug.DrawRay(transform.position,transform.position-follow.transform.position*30,Color.red);
        // transform.RotateAround(Vector3.forward,Vector3.up,10 * Time.deltaTime);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation,follow.transform.rotation,4);
        // transform.LookAt(follow.transform.position,);
    // }
}