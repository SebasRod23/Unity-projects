using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        animator.GetComponent<PlayerMovement>().enabled = false;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BoxCollider2D>().isTrigger = true;
        animator.GetComponent<SpriteRenderer>().enabled = false;
    }
}
