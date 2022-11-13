using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowImp : MonoBehaviour
{
    //Fields
    Animator enemyAnimator;
    private int enemyHealth;
    GameObject player;

    //private GameObject dieSoundObject;
    //private GameObject hurtSoundObject;

    //private AudioSource dieSound;
    //private AudioSource hurtSound;
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

        speed = 1f;
        fallForce = 0f;

        //dieSoundObject = GameObject.Find("DieSound");
        //hurtSoundObject = GameObject.Find("HurtSound");

        //dieSound = dieSoundObject.GetComponent<AudioSource>();
        //hurtSound = hurtSoundObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {// This entire update function is kinda complicated but it effectively makes it
     //so that the enemy is ALWAYS facing in the direction of the player

        if (player != null)
        {
            //FLIPS SPRITE CODE
            //Checks if player is on the right of the enemy
            if ((player.transform.position.x >= this.transform.position.x))
            {
                facingLeft = false;
            }
            //Else if player is on the left side of the enemy
            else
            {
                facingLeft = true;
            }

            //If player is on the right of the enemy (facingLeft == true) and the enemy has not flipped yet.
            if (facingLeft && hasFlipped)
            {
                //Flip enemy to the right
                this.transform.localScale *= new Vector2(-1, 1);
                //Recognize that the enemy has flipped
                hasFlipped = false;
            }

            //If the player has fliped to the right (meaning they are currently facing right) and the player is on the left side of the enemy
            if (!hasFlipped && !facingLeft)
            {
                //Flip enemy to the left
                this.transform.localScale *= new Vector2(-1, 1);
                //Recognize the enemy is now facing their default direction
                hasFlipped = true;
            }

            //ShadowImp Pomvement
            //There is no dealing with animator booleans because there is no different between idle and wa;lomg
            if (Mathf.Abs(player.transform.position.x - this.transform.position.x) <= 8)
            {
                if (!facingLeft && player.transform.position.x - this.transform.position.x > 4.5 )
                {
                    fallForce = myPhysics.velocity.y;
                    myPhysics.velocity = new Vector2(speed, fallForce);
                }
                else if (facingLeft && player.transform.position.x - this.transform.position.x < -4.5)
                {
                    fallForce = myPhysics.velocity.y;
                    myPhysics.velocity = new Vector2(-1 * speed, fallForce);

                }
                else
                {
                    fallForce = myPhysics.velocity.y;
                    myPhysics.velocity = new Vector2(0, fallForce);
                }
            }
        }
    }

    public void takeDamage()
    { //To be called in other scripts when something hits this enemy

        if (enemyHealth > 0)
        {
            //Debug.Log("Enemy health before hit: " + enemyHealth);

            //Lowers enemy health
            enemyHealth--;

            //Plays damage taking animation
            enemyAnimator.SetBool("DmgTaken", true);
            //hurtSound.Play();
            //Debug.Log("Enemy health after hit: " + enemyHealth);
        }

        //Kills enemy if they have no health

        if (enemyHealth <= 0)
        {
            enemyAnimator.SetBool("HealthIsZero", true);
            //dieSound.Play();
        }
    }
}
