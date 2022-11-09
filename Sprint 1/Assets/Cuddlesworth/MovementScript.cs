using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovementScript : MonoBehaviour
{
    public int playerHealth;

    Vector3 moveRight, moveLeft;
    public Vector2 jumpForce;
    Rigidbody2D myPhysics;

    float fallForce;
    public float speed;
    bool facingRight;
    bool hasFlipped;
    int courage;
    int fear;

    bool collideActive;

    Animator protagAnimator;
    public GameObject theProjectileHolder;
    private GameObject currentProjectile;
    public Transform spawnSpot;

    private GameObject meleeSoundObject;
    private GameObject jumpSoundObject;

    private AudioSource meleeSound;
    private AudioSource jumpSound;


    void Start()
    {
        //Debug.Log("Starting...");
        playerHealth = 99;
        courage = 0;
        fear = 0;

        facingRight = true;
        hasFlipped = false;

        moveRight = new Vector3(1, 0, 0);
        moveLeft = new Vector3(-1, 0, 0);

        myPhysics = GetComponent<Rigidbody2D>();
        protagAnimator = GetComponent<Animator>();

        speed = 3.5f;
        fallForce = 0f;
        //jumpForce = new Vector2(0, 28); //(0,22);

        meleeSoundObject = GameObject.Find("MeleeSound");
        jumpSoundObject = GameObject.Find("JumpSound");

        meleeSound = meleeSoundObject.GetComponent<AudioSource>();
        jumpSound = jumpSoundObject.GetComponent<AudioSource>();

    }

    void Update()
    {
        if (this != null && !protagAnimator.GetBool("cutsceneIdle"))
        {
            if ((Input.GetKey(KeyCode.D) /*|| Input.GetKey(KeyCode.RightArrow)*/) ^ (Input.GetKey(KeyCode.A) /*|| Input.GetKey(KeyCode.LeftArrow)*/))
            {
                if (Input.GetKey(KeyCode.D) /*|| Input.GetKey(KeyCode.RightArrow)*/)
                {
                    fallForce = myPhysics.velocity.y;
                    myPhysics.velocity = new Vector2(speed, fallForce);
                    facingRight = true;
                    protagAnimator.SetBool("ADPressed", true);
                }
                if (Input.GetKey(KeyCode.A) /*|| Input.GetKey(KeyCode.LeftArrow)*/)
                {
                    fallForce = myPhysics.velocity.y;
                    myPhysics.velocity = new Vector2(-1 * speed, fallForce);
                    facingRight = false;
                    protagAnimator.SetBool("ADPressed", true);
                }
            }
            else
            {
                protagAnimator.SetBool("ADPressed", false);
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

            //Could create a canJump Boolean that would allow for jumping in mid air if you havent used a jump yet.
            if ((Input.GetKeyDown(KeyCode.W) /*|| Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)*/) && protagAnimator.GetBool("GroundTapped"))
            {
                protagAnimator.SetBool("WPressed", true);
                myPhysics.AddForce(jumpForce, ForceMode2D.Impulse);
                protagAnimator.SetBool("GroundTapped", false);

                /*if (myPhysics.velocity.y < 10) //code to allow small jumps; needs fixing
                {
                    myPhysics.AddForce(jumpForce, ForceMode2D.Impulse);
                }*/
                //uncomment below when we have a jump sound that makes sense.
                //jumpSound.Play();
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                //Debug.Log("Attack");
                protagAnimator.SetBool("JPressed", true);
                meleeSound.Play();
            }
            else
            {
                protagAnimator.SetBool("JPressed", false);
            }
            if (Input.GetKey(KeyCode.K))
            {
                //do stuff (light/courage magic)
            }
            if (Input.GetKey(KeyCode.L))
            {
                //fear mode
            }

            if (myPhysics.velocity.y < -0.5)
            {
                protagAnimator.SetBool("GoingDown", true);
            }
            else
            {
                protagAnimator.SetBool("GoingDown", false);
            }
        }
        else
        {

        }
    }

    public void OnCollisionEnter2D(Collision2D thingProtagHit)
    {
        Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);

        if (thingProtagHit.gameObject.CompareTag("ground")) //TODO: also check that you are colliding with the TOP of the ground tile...
        {
            //Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            protagAnimator.SetBool("GroundTapped", true);
        }



        if (thingProtagHit.gameObject.CompareTag("Void"))
        {
            Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }

    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    public void OnCollisionExit2D(Collision2D thingProtagHit)
    {
        Debug.Log("Cuddlesworth stopped touching " + thingProtagHit.gameObject.name);

        if (thingProtagHit.gameObject.CompareTag("ground")) //TODO: also check that you are colliding with the TOP of the ground tile...
        {
            //Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            protagAnimator.SetBool("GroundTapped", false);
        }

    }


=======
=======
>>>>>>> 01d996071b81e9e0fa533b94848c64dd0e156c92
=======
>>>>>>> 01d996071b81e9e0fa533b94848c64dd0e156c92
=======
>>>>>>> 01d996071b81e9e0fa533b94848c64dd0e156c92
    //experiment to make protag not wall(and celing) jump
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ground")){
            canJump = true;
            protagAnimator.Play("Cuddlesworth_land");
            //Debug.Log("grass");
        }
    }

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 01d996071b81e9e0fa533b94848c64dd0e156c92
=======
>>>>>>> 01d996071b81e9e0fa533b94848c64dd0e156c92
=======
>>>>>>> 01d996071b81e9e0fa533b94848c64dd0e156c92
=======
>>>>>>> 01d996071b81e9e0fa533b94848c64dd0e156c92
    public void takeDamage()
    { //To be called in other scripts when something hits this enemy


        Debug.Log("Player health before hit: " + playerHealth);

        //Lowers enemy health
        playerHealth--;

        //Plays damage taking animation
        protagAnimator.SetBool("TookDamage", true);
        Debug.Log("Player health after hit: " + playerHealth);

        //Kills enemy if they have no health
        if (playerHealth <= 0)
        {
            Destroy(this.gameObject);

        }
    }
}