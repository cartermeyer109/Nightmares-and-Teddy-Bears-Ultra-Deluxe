using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovementScript : MonoBehaviour
{

    Vector3 moveRight, moveLeft;

    //Stuff im using RN
    Rigidbody2D myPhysics;
    public float speed;
    private float moveInput;
    private bool isGrounded;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    GameObject startObject;


    float fallForce;
    bool canJump;
    bool facingRight;
    bool hasFlipped;

    //Player 
    Animator protagAnimator;

    //Stats
    public static int courage;
    public static int fear = 400;
    public int playerHealth;

    //Audio
    private GameObject meleeSoundObject;
    private GameObject jumpSoundObject;

    private AudioSource meleeSound;
    private AudioSource jumpSound;

    //INVENTORY
    private static int maxHealth = 6; 
    private static bool goldenNeedle = false;
    private static bool projAttack = false;
    private static bool gpAttack = false;



    void Start()
    {
        //jumpForce = 10;
        //jumpTime = 0.3f;

        //Debug.Log("Starting...");
        playerHealth = maxHealth;
        courage = 0;
        fear = 0;

        facingRight = true;
        hasFlipped = false;

        moveRight = new Vector3(1, 0, 0);
        moveLeft = new Vector3(-1, 0, 0);

        myPhysics = GetComponent<Rigidbody2D>();
        protagAnimator = GetComponent<Animator>();

        //speed = 3.75f;
        fallForce = 0f;
        //jumpForce = new Vector2(0, 28); //(0,22);

        startObject = GameObject.Find("StartObject");

        //audio
        meleeSoundObject = GameObject.Find("MeleeSound");
        jumpSoundObject = GameObject.Find("JumpSound");

        meleeSound = meleeSoundObject.GetComponent<AudioSource>();
        jumpSound = jumpSoundObject.GetComponent<AudioSource>();

        fear = 400;

    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        myPhysics.velocity = new Vector2(moveInput * speed, myPhysics.velocity.y);
    }
    void Update()
    {
        if (this != null && !protagAnimator.GetBool("cutsceneIdle"))
        {
            if(moveInput > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                protagAnimator.SetBool("ADPressed", true);
            }
            else if (moveInput < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                protagAnimator.SetBool("ADPressed", true);
            }
            else
            {
                protagAnimator.SetBool("ADPressed", false);
            }

            if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
            {
                protagAnimator.SetBool("WPressed", true);
                protagAnimator.SetBool("GroundTapped", false);
                isJumping = true;
                jumpTimeCounter = jumpTime;
                myPhysics.velocity = Vector2.up * jumpForce;
            }
            if (Input.GetKey(KeyCode.W) && isJumping == true)
            {
                if(jumpTimeCounter > 0)
                {
                    myPhysics.velocity = Vector2.up * jumpForce;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                isJumping = false;
            }     
            //***********************************************************************************
            //THE OLD MOVEMENT CODE
            /*if ((Input.GetKey(KeyCode.D) *//*|| Input.GetKey(KeyCode.RightArrow)*//*) ^ (Input.GetKey(KeyCode.A) *//*|| Input.GetKey(KeyCode.LeftArrow)*//*))
            {
                if (Input.GetKey(KeyCode.D) *//*|| Input.GetKey(KeyCode.RightArrow)*//*)
                {
                    fallForce = myPhysics.velocity.y;
                    myPhysics.velocity = new Vector2(speed, fallForce);
                    facingRight = true;
                    protagAnimator.SetBool("ADPressed", true);
                }
                if (Input.GetKey(KeyCode.A) *//*|| Input.GetKey(KeyCode.LeftArrow)*//*)
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

            if ((Input.GetKeyDown(KeyCode.W) *//*|| Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)*//*) && protagAnimator.GetBool("GroundTapped"))
            {
                protagAnimator.SetBool("WPressed", true);
                myPhysics.AddForce(jumpForce, ForceMode2D.Impulse);
                protagAnimator.SetBool("GroundTapped", false);

                *//*if (myPhysics.velocity.y < 10) //code to allow small jumps; needs fixing
                {
                    myPhysics.AddForce(jumpForce, ForceMode2D.Impulse);
                }*//*
                //uncomment below when we have a jump sound that makes sense.
                //jumpSound.Play();
            }
            */
            //*****************************************************************************************

            if (Input.GetKeyDown(KeyCode.J))
            {
                //Debug.Log("Attack");
                protagAnimator.SetBool("JPressed", true);
                meleeSound.Play();
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
    }
    public void OnCollisionEnter2D(Collision2D thingProtagHit)
    {
        //Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);

        if (thingProtagHit.gameObject.CompareTag("ground")) //TODO: also check that you are colliding with the TOP of the ground tile...
        {
            //Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            protagAnimator.SetBool("GroundTapped", true);
            isGrounded = true;
        }

        //ALSO TODO: make canJump false if protag is not touching anything!

        if (thingProtagHit.gameObject.CompareTag("Void"))
        {
            //Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            this.transform.position = new Vector3(thingProtagHit.gameObject.transform.position.x, thingProtagHit.gameObject.transform.position.y, 0);
            this.takeDamage();
            //Destroy(this.gameObject);
            //SceneManager.LoadScene("GameOver");
        }

    }

    public void OnCollisionExit2D(Collision2D thingProtagHit)
    {
        //Debug.Log("Cuddlesworth stopped touching " + thingProtagHit.gameObject.name);

        if (thingProtagHit.gameObject.CompareTag("ground")) //TODO: also check that you are colliding with the TOP of the ground tile...
        {
            //Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            protagAnimator.SetBool("GroundTapped", false);
            isGrounded = false;
        }

    }


    //experiment to make protag not wall(and celing) jump
    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ground")){
            canJump = true;
            protagAnimator.Play("Cuddlesworth_land");
            //Debug.Log("grass");
        }
    }*/

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
            SceneManager.LoadScene("GameOver");
            Destroy(this.gameObject);
        }
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public bool getGoldenNeedle()
    {
        return goldenNeedle;
    }

    public bool getProjAttack()
    {
        return projAttack;
    }

    public bool getGPAttack()
    {
        return gpAttack;
    }

    public int getFear()
    {
        return fear;
    }

    public void setFear(int f)
    {
        fear = f;
    }

    public void setMaxHealth(int i)
    {
        maxHealth = i;
    }

    public void setGoldenNeedle(bool i)
    {
        goldenNeedle = i;
    }

    public void setProjAttack(bool i)
    {
        projAttack = i;
    }

    public void setGPAttack(bool i)
    {
        gpAttack = i;
    }


}

