using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooGremlinScript : MonoBehaviour
{//GooGremlinScript right now just contains a take damage function to lower health,
 // and a flipper in the update function to slip the sprite and hitbox depending on the players location

    //Hello
    //Fields
    Animator enemyAnimator;
    private int enemyHealth;
    GameObject player;
    float attackedTime = 0f;


    //To be used in updating (flipping code)
    public bool facingRight;
    public bool hasFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 4;

        //If you dont have the tag "Player" on the player object then you will need to change this to work
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {// This entire update function is kinda complicated but it effectively makes it
     //so that the enemy is ALWAYS facing in the direction of the player

        if (player != null)
        {

            //Checks if player is on the right of the enemy
            if ((player.transform.position.x > this.transform.position.x))
            {
                facingRight = true;
            }
            //Else if player is on the left side of the enemy
            else
            {
                facingRight = false;
            }

            //If player is on the right of the enemy (facingRight == true) and the enemy has not flipped yet.
            if (facingRight && !hasFlipped)
            {
                //Flip enemy to the right
                this.transform.localScale *= new Vector2(-1, 1);
                //Recognize that the enemy has flipped
                hasFlipped = true;
            }

            //If the player has fliped to the right (meaning they are currently facing right) and the player is on the left side of the enemy
            if (hasFlipped && !facingRight)
            {
                //Flip enemy to the left
                this.transform.localScale *= new Vector2(-1, 1);
                //Recognize the enemy is now facing their default direction
                hasFlipped = false;
            }
        }
    }

    public void takeDamage()
    { //To be called in other scripts when something hits this enemy

        if (enemyHealth > 0)
        {
            Debug.Log("Enemy health before hit: " + enemyHealth);

            //Lowers enemy health
            enemyHealth--;

            //Plays damage taking animation
            enemyAnimator.Play("Goo-Gremlin-DmgTakenAnimation");
            Debug.Log("Enemy health after hit: " + enemyHealth);
        }

        //Kills enemy if they have no health

        if (enemyHealth <= 0)
        {
            enemyAnimator.SetBool("healthIsZero", true);
        }
    }
}