using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{     
    public GameObject follow;
    public Vector3 offset = new Vector3(4,7,-20);
    public Vector3 newpos;
    // Start is called before the first frame update
    void Start()
    {
        

    }
    
    
    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {   
        
        // transform.LookAt(follow.transform.position);
        transform.rotation = Quaternion.LookRotation(follow.transform.position-transform.position);
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
    }
}
