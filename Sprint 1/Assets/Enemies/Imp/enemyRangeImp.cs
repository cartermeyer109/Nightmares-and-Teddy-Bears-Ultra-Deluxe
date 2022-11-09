using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRangeImp : MonoBehaviour
{//This script attacks only if the the player is in a certain range

    //Fields
    GameObject player;
    Animator enemyAnimator;
    float attackTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //If you dont have the tag "Player" on the player object then you will need to change this to work
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Makes sure a "player" exists
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            //This checks distance between the this enemy and the player
            //I have it set to 2 difference x, and 3 difference y. But I don't know the
            //dimensions of the player we're using or if we are going to scale them.
            //(My GooGremlin is currently set to a scale of 5)
            if (Mathf.Abs(player.transform.position.x - this.transform.position.x) <= 5.5 &&
                Mathf.Abs(player.transform.position.y - this.transform.position.y) <= 5.5)
            {
                //This basically checks that at least 2 second has passed between attacks
                //so the enemy doesn't attack constatnly. I chose one second because thats
                //how long one loop of the idle animation is
                if ((Time.time - attackTime) > 2)
                {
                    enemyAnimator.SetBool("attacked", true);
                    attackTime = Time.time;
                }
            }
        }
    }
}