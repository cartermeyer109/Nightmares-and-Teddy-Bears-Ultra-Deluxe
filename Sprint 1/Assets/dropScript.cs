using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropScript : MonoBehaviour
{
    GameObject player;
    MovementScript playerScript;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.gameObject.GetComponent<MovementScript>();

        animator = GetComponent<Animator>();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player") && !animator.GetBool("HitGround"))
        {
            playerScript.takeDamage();
        }
        //Debug.Log("Collision Detected with" + other.name);
        animator.SetBool("HitGround", true);
    }

    public void DestroyDrop()
    {
        Destroy(animator.gameObject);
    }


}
