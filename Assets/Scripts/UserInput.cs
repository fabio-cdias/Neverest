using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public KeyCode jump = KeyCode.Space;
    public KeyCode run = KeyCode.LeftShift;

    public Vector3 Direction(){
        return new Vector2 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }
    public Vector2 mouseAxis(){
        return new Vector2 (Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"));
    }
    public bool jumpKey(){
        return Input.GetKey(jump);        
    }

    
    public bool runKey(){
        return Input.GetKey(run);
    }
}
