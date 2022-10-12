using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementScript : MonoBehaviour
{
    public int playerHealth;

    Vector3 moveRight, moveLeft;
    Vector2 jumpForce;
    Rigidbody2D myPhysics;

    float fallForce;
    float speed;
    bool canJump;
    bool facingRight;
    bool hasFlipped;

    Animator protagAnimator;
    public GameObject theProjectileHolder;
    private GameObject currentProjectile;
    public Transform spawnSpot;

    void Start()
    {
        Debug.Log("Starting...");
        playerHealth = 99;

        canJump = false;
        facingRight = true;
        hasFlipped = false;

        moveRight = new Vector3(1, 0, 0);
        moveLeft = new Vector3(-1, 0, 0);

        myPhysics = GetComponent<Rigidbody2D>();
        protagAnimator = GetComponent<Animator>();

        speed = 2.5f;
        fallForce = 0f;
        jumpForce = new Vector2(0, 28); //(0,22);
    }

    void Update()
    {
        if (this != null)
        {
            if ((Input.GetKey(KeyCode.D) /*|| Input.GetKey(KeyCode.RightArrow)*/) ^ (Input.GetKey(KeyCode.A) /*|| Input.GetKey(KeyCode.LeftArrow)*/))
            {
                if (Input.GetKey(KeyCode.D) /*|| Input.GetKey(KeyCode.RightArrow)*/)
                {
                    fallForce = myPhysics.velocity.y;
                    myPhysics.velocity = new Vector2(speed, fallForce);
                    facingRight = true;
                    protagAnimator.Play("Cuddlesworth_run");
                }
                if (Input.GetKey(KeyCode.A) /*|| Input.GetKey(KeyCode.LeftArrow)*/)
                {
                    fallForce = myPhysics.velocity.y;
                    myPhysics.velocity = new Vector2(-1 * speed, fallForce);
                    facingRight = false;
                    protagAnimator.Play("Cuddlesworth_run");
                }
            }

            if (!facingRight && !hasFlipped)
            {
                this.transform.localScale *= new Vector2(-1, 1);
                hasFlipped = true;
     
            }
            if (hasFlipped & facingRight)
            {
                this.transform.localScale *= new Vector2(-1, 1);
                hasFlipped = false;
            }

            if ((Input.GetKey(KeyCode.W) /*|| Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)*/) && canJump)
            {
                myPhysics.AddForce(jumpForce, ForceMode2D.Impulse);
                //if (myPhysics.velocity.y < 10) //code to allow small jumps; needs fixing
                //{
                //    myPhysics.AddForce(jumpForce, ForceMode2D.Impulse);
                //}
                protagAnimator.Play("Cuddlesworth_jump");
                canJump = false;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                //Debug.Log("Attack");
                protagAnimator.Play("protag_attack_anim");
            }
            if (Input.GetKey(KeyCode.K))
            {
                //do stuff
            }
            if (Input.GetKey(KeyCode.L))
            {

            }
            if (facingRight)
            {

            }
            else
            {

            }
        }
    }

    public void OnCollisionEnter2D(Collision2D thingProtagHit)
    {
        if (thingProtagHit.gameObject.CompareTag("ground")) //TODO: also check that you are colliding with the TOP of the ground tile...
        {
            //Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            protagAnimator.Play("Cuddlesworth_land");
            canJump = true;
        }
        //ALSO TODO: make canJump false if protag is not touching anything!

        /*if (thingProtagHit.gameObject.CompareTag("killbox")) 
        {
            Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            Destroy(this.gameObject);
        }*/

        if (thingProtagHit.gameObject.CompareTag("Void"))
        {
            Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            Destroy(this.gameObject);
        }

    }

    public void takeDamage()
    { //To be called in other scripts when something hits this enemy


        Debug.Log("Player health before hit: " + playerHealth);

        //Lowers enemy health
        playerHealth--;

        //Plays damage taking animation
        protagAnimator.Play("Cuddlesworth_DmgTaken");
        Debug.Log("Player health after hit: " + playerHealth);

        //Kills enemy if they have no health
        if (playerHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}