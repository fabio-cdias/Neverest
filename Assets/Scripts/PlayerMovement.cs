using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        bool w_press = Input.GetKey("w");
        bool isJogging = anim.GetBool("isJogging");
        Debug.Log(isJogging);
        if (w_press && !isJogging){
            anim.SetBool("isJogging",true);
        }
        if (!w_press && isJogging){
            anim.SetBool("isJogging",false);
        }
    }
}
