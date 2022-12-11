using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDeath : StateMachineBehaviour
{
    public ParticleSystem particleBurst1;
    public ParticleSystem particleBurst2;
    public ParticleSystem particleBurst3;
    public ParticleSystem particleBurst4;
    public ParticleSystem particleBurst5;
    public GameObject particleBurstObject1;
    public GameObject particleBurstObject2;
    public GameObject particleBurstObject3;
    public GameObject particleBurstObject4;
    public GameObject particleBurstObject5;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        particleBurstObject1 = GameObject.Find("GremlinParticleSystem1");
        particleBurstObject2 = GameObject.Find("GremlinParticleSystem2");
        particleBurstObject3 = GameObject.Find("GremlinParticleSystem3");
        particleBurstObject4 = GameObject.Find("GremlinParticleSystem4");
        particleBurstObject5 = GameObject.Find("GremlinParticleSystem5");
        particleBurst1 = particleBurstObject1.GetComponent<ParticleSystem>();
        particleBurst2 = particleBurstObject2.GetComponent<ParticleSystem>();
        particleBurst3 = particleBurstObject3.GetComponent<ParticleSystem>();
        particleBurst4 = particleBurstObject4.GetComponent<ParticleSystem>();
        particleBurst5 = particleBurstObject5.GetComponent<ParticleSystem>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!particleBurst1.isPlaying)
        {
            particleBurst1.transform.position = new Vector2(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y - 0.7f);
            particleBurst1.Play();
        }
        else if (!particleBurst2.isPlaying)
        {
            particleBurst2.transform.position = new Vector2(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y - 0.7f);
            particleBurst2.Play();
        }
        else if (!particleBurst3.isPlaying)
        {
            particleBurst3.transform.position = new Vector2(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y - 0.7f);
            particleBurst3.Play();
        }
        else if (!particleBurst4.isPlaying)
        {
            particleBurst4.transform.position = new Vector2(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y - 0.7f);
            particleBurst4.Play();
        }
        else if (!particleBurst5.isPlaying)
        {
            particleBurst5.transform.position = new Vector2(animator.gameObject.transform.position.x, animator.gameObject.transform.position.y - 0.7f);
            particleBurst5.Play();
        }

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
