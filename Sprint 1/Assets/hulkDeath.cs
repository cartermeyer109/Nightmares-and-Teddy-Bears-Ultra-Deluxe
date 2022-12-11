using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hulkDeath : StateMachineBehaviour
{
    public ParticleSystem particleBurst;
    public GameObject particleBurstObject;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        particleBurstObject = GameObject.Find("HulkParticleSystem");
        particleBurst = particleBurstObject.GetComponent<ParticleSystem>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //-0.7
        particleBurst.transform.position = new Vector2(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y - 1.7f);
        particleBurst.Play();
        Destroy(animator.gameObject);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
