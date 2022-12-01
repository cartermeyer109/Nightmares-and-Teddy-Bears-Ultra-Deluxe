using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooGremlinDefaultScript : MonoBehaviour
{
    //Hello
    //Fields
    Animator enemyAnimator;
    private int enemyHealth;
    GameObject player;

    private GameObject dieSoundObject;
    private GameObject hurtSoundObject;

    private AudioSource dieSound;
    private AudioSource hurtSound;

    Rigidbody2D myPhysics;

    float fallForce;
    float speed;

    //To be used in updating (flipping code)
    public bool facingLeft;
    public bool hasFlipped = false;
    public bool dynamicFlipping = false;

    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 4;

        //If you dont have the tag "Player" on the player object then you will need to change this to work
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnimator = GetComponent<Animator>();

        myPhysics = GetComponent<Rigidbody2D>();

        speed = 3.5f;
        fallForce = 0f;

        dieSoundObject = this.gameObject.transform.GetChild(2).gameObject;
        //GameObject.Find("DieSound");
        hurtSoundObject = this.gameObject.transform.GetChild(1).gameObject;
        //GameObject.Find("HurtSound");

        dieSound = dieSoundObject.GetComponent<AudioSource>();
        hurtSound = hurtSoundObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {// This entire update function is kinda complicated but it effectively makes it
     //so that the enemy is ALWAYS facing in the direction of the player
        if (player != null)
        {
            if (enemyAnimator.GetBool("hasAwoken"))
            {
                //FLIPS SPRITE CODE
                //Checks if player is on the right of the enemy
                if ((player.transform.position.x > this.transform.position.x))
                {
                    facingLeft = false;
                }
                //Else if player is on the left side of the enemy
                else
                {
                    facingLeft = true;
                }

                //If player is on the right of the enemy (facingLeft == true) and the enemy has not flipped yet.
                if (facingLeft && !hasFlipped)
                {
                    //Flip enemy to the right
                    this.transform.localScale *= new Vector2(-1, 1);
                    //Recognize that the enemy has flipped
                    hasFlipped = true;
                }

                //If the player has fliped to the right (meaning they are currently facing right) and the player is on the left side of the enemy
                if (hasFlipped && !facingLeft)
                {
                    //Flip enemy to the left
                    this.transform.localScale *= new Vector2(-1, 1);
                    //Recognize the enemy is now facing their default direction
                    hasFlipped = false;
                }

               

                //Beginner Gremlin Movement Code
                if (Mathf.Abs(player.transform.position.x - this.transform.position.x) < 8 && Mathf.Abs(player.transform.position.y - this.transform.position.y) < 3)
                {
                    if (Mathf.Abs(player.transform.position.x - this.transform.position.x) > 1)
                    {
                        enemyAnimator.SetBool("canWalk", true);
                    }
                    else
                    {
                        enemyAnimator.SetBool("canWalk", false);
                    }

                    if (enemyAnimator.GetBool("isWalking"))
                    {
                        if (!facingLeft)
                        {
                            fallForce = myPhysics.velocity.y;
                            myPhysics.velocity = new Vector2(speed, fallForce);
                        }
                        else if (facingLeft)
                        {
                            fallForce = myPhysics.velocity.y;
                            myPhysics.velocity = new Vector2(-1 * speed, fallForce);

                        }
                    }
                }
                else
                {
                    enemyAnimator.SetBool("canWalk", false);
                }
            }

            //Allows Gremlin to come out of puddle
            if (Mathf.Abs(player.transform.position.x - this.transform.position.x) <= 6)
            {
                enemyAnimator.SetBool("inRange", true);
            }


        }
    }


    public void OnCollisionEnter2D(Collision2D thingHit)
    {
        
        if (thingHit.gameObject.CompareTag("Void"))
        {
            Destroy(this.gameObject);
        }

    }

    public void takeDamage()
    { //To be called in other scripts when something hits this enemy

        if (enemyHealth > 0)
        {
             hurtSound.Play();
            //Debug.Log("Enemy health before hit: " + enemyHealth);
            //Lowers enemy health
            enemyHealth--;

            //Plays damage taking animation
            enemyAnimator.SetBool("dmgTaken", true);
            //Debug.Log("Enemy health after hit: " + enemyHealth);
        }

        //Kills enemy if they have no health

        if (enemyHealth <= 0)
        {
            dieSound.Play();
            enemyAnimator.SetBool("healthIsZero", true);
        }
    }
}
