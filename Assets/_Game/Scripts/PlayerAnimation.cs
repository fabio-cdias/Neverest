using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private Movement player;
    private float directionX;
    private float directionY;
    private int velocityHashX;
    private int velocityHashY;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Movement>();
        animator = GetComponent<Animator>();
        velocityHashX = Animator.StringToHash("velocityX");
        velocityHashY = Animator.StringToHash("velocityY");
    }

    // Update is called once per frame
    void Update()
    {   
        animator.SetFloat(velocityHashX,player.velocity.x);
        animator.SetFloat(velocityHashY,player.velocity.z);
        
        
        // // Forward  - Backwards
        // if (directionX == 0){
        //     if (directionY > 0){}
        //     else if (directionY < 0){}
        // }
        // // Left - Right
        // else if (directionY == 0){
        //     if (directionY > 0){}
        //     else if (directionY < 0){}
        // }

        // // Forward - Right
        // else if (directionY > 0 && directionX > 0){}
        // // Backward - Left
        // else if (directionY < 0 && directionX < 0){}

        // // Forward Left
        // else if (directionY > 0 && directionX < 0){}

        // // Backward Right
        // else if (directionY < 0 && directionX >0){}
        
        // // fleft = player.
        // // Converts the hash name to the player horizontal velocity
        // // to ajust the animation based on velocity
    }
}
