using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmill : MonoBehaviour
{   
    private float propellerRotation = -15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * propellerRotation * Time.deltaTime);
    }
}