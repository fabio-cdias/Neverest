using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkParakeet : MonoBehaviour
{   
    public float direction=1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x > 2.05f)
        {
            direction = -1f;
  
        }
  
        if (transform.position.x <-9.5f){
            direction = 1f;


        }
        transform.position += new Vector3(direction,0,0)* 1f *Time.deltaTime;
    }
}
