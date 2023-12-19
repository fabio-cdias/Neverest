using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boatmove : MonoBehaviour
{   
    public float direction = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < -2.25f)
        {
            direction = 1f;
        }
  
        if (transform.position.x > 11.11f){
            direction = -1f;
        }
        transform.position += new Vector3(direction,0,0)* 0.5f *Time.deltaTime;
    }
}
