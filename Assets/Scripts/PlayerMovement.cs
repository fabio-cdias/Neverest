using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        bool w_press = Input.GetKey(KeyCode.W);
        bool shift_press = Input.GetKey(KeyCode.LeftShift);
        bool isRunning = anim.GetBool("isRunning");
        bool isSprinting = anim.GetBool("isSprinting");
        Debug.Log(isRunning);
        Debug.Log(isSprinting);

        if (w_press && !isRunning){
            anim.SetBool("isRunning",true);
            if (shift_press && !isSprinting){
                anim.SetBool("isSprinting",true);
            }
        }
        if (!w_press && isRunning){
            anim.SetBool("isRunning",false);
            if  (!shift_press && isSprinting){
                anim.SetBool("isSprinting",false);
            }
        }
    }
}
