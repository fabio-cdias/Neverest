using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public float h_axis;
    public float v_axis;
    public Vector3 facefwd;
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

        // Creates a 3D Vector based on the user input, x and z directions
        Vector3 facefwd = new Vector3(h_axis,0,v_axis);
        

        Debug.DrawRay(transform.position,facefwd*30,Color.red);
        Debug.DrawRay(transform.position,facefwd*15,Color.green,2);

        // Moves the player altering the transform position, get its current position
        // and sum with the direction the user wants the player to move.
        transform.position = transform.position + facefwd * 10 *Time.deltaTime;
        // transform.Translate( * 4 * Time.deltaTime);

        // Checks if the the user input vector isn´t zero, otherwise the rotation
        // values get reseted
        if (facefwd != Vector3.zero)
        {
        // Creates a quaternion rotation facing forward to where player are moving
        Quaternion rotate = Quaternion.LookRotation(facefwd, Vector3.up);
        // Actually rotate the player based on the previous quaternion rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation,rotate,8);
        }


    }
}
