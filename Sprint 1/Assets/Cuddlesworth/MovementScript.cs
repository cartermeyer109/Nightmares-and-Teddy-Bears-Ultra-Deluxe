using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//TODO still need to make protag invincible during transformation

public class MovementScript : MonoBehaviour
{

    Vector3 moveRight, moveLeft;

    //Stuff im using RN
    public Rigidbody2D myPhysics;
    public float speed;
    private float moveInput;
    private bool isGrounded;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private float switchTimer = 2.5f;

    private Transform pitRespawnPoint;

    public GameObject LevelTracker;
    levelTracker LTScript;
    public int currLevel = -1;

    float fallForce;
    bool canJump;
    bool facingRight;
    bool hasFlipped;

    //Player 
    Animator protagAnimator;

    //Stats
    public static float courage = maxCourage;
    public static int maxCourage ;
    public static int fear;

    //This is for the fear bar, not the currency
    public static float fearBarCtr;
    public static int maxFear;
    public int playerHealth;
    public float fearOverUseTimer = 0;
    public bool nightmareDmg = false;
    public float nightmareDmgTimer = 0;

    public float nightmareCooldown;
    public float nightmareCooldownTime = 25;

    //Audio
    //This now plays in the animation script so that it ONLY plays when the animation actually happens
    //private GameObject meleeSoundObject;
    private GameObject jumpSoundObject;

    private AudioSource meleeSound;
    private AudioSource jumpSound;

    //INVENTORY
    private static int maxHealth; 
    private static bool goldenNeedle = false;
    private static bool projAttack = false;
    private static bool gpAttack = false;

    //UI
    public Animator normAnimator;
    public Animator nightmareAnimator;



    void Start()
    {
        //jumpForce = 10;
        //jumpTime = 0.3f;


        //Debug.Log("Starting...");
        courage = 0;
        fear = 0;
        nightmareCooldown = 0;

        facingRight = true;
        hasFlipped = false;

        moveRight = new Vector3(1, 0, 0);
        moveLeft = new Vector3(-1, 0, 0);

        myPhysics = GetComponent<Rigidbody2D>();
        protagAnimator = GetComponent<Animator>();

        //speed = 3.75f;
        fallForce = 0f;
        //jumpForce = new Vector2(0, 28); //(0,22);

        //meleeSoundObject = GameObject.Find("MeleeSound");
        jumpSoundObject = GameObject.Find("JumpSound");

        //meleeSound = meleeSoundObject.GetComponent<AudioSource>();
        jumpSound = jumpSoundObject.GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().name == "TutorialLevel")
        {
            fear = 150; //Set to 400 for demonstration purposes (150 for normal game if we don't change gremlins particle system)
            maxFear = 500;
            maxHealth = 6;
            fearBarCtr = 5;
            maxCourage = 100;
            courage = maxCourage;
            playerHealth = maxHealth;
            goldenNeedle = false;
            projAttack = false;
            gpAttack = false;
        }
        else
        {
            fear = PlayerPrefs.GetInt("fear");
            maxFear = PlayerPrefs.GetInt("maxFear");
            maxHealth = PlayerPrefs.GetInt("maxHealth");
            fearBarCtr = PlayerPrefs.GetFloat("fearBarCtr");
            maxCourage = PlayerPrefs.GetInt("maxCourage");
            courage = PlayerPrefs.GetFloat("courage");
            playerHealth = PlayerPrefs.GetInt("playerHealth");
            goldenNeedle = intToBool(PlayerPrefs.GetInt("goldenNeedle"));
            projAttack = intToBool(PlayerPrefs.GetInt("projAttack"));
            gpAttack = intToBool(PlayerPrefs.GetInt("gpAttack"));
        }

        if (GameObject.FindWithTag("LevelTracker") == null) //****************************************************************
        {
            Instantiate(LevelTracker);
        }
        LevelTracker = GameObject.FindWithTag("LevelTracker");
        LTScript = LevelTracker.GetComponent<levelTracker>();
        if (currLevel >= 0) { LTScript.setLevel(currLevel); }

    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (this != null && !protagAnimator.GetBool("cutsceneIdle") && !protagAnimator.GetBool("isTransforming"))
        {
            myPhysics.velocity = new Vector2(moveInput * speed, myPhysics.velocity.y);
        }
    }
    void Update()
    {
        if (playerHealth <= 2)
        {
            normAnimator.SetBool("lowHealth", true);
            nightmareAnimator.SetBool("lowHealth", true);
        }
        else
        {
            normAnimator.SetBool("lowHealth", false);
            nightmareAnimator.SetBool("lowHealth", false);
        }

        //SETTING THE STATS
        {
            PlayerPrefs.SetInt("fear", fear);
            PlayerPrefs.SetInt("maxFear", maxFear);
            PlayerPrefs.SetInt("maxHealth", maxHealth);
            PlayerPrefs.SetFloat("fearBarCtr", fearBarCtr);
            PlayerPrefs.SetInt("maxCourage", maxCourage);
            PlayerPrefs.SetFloat("courage", courage);
            PlayerPrefs.SetInt("playerHealth", playerHealth);
            PlayerPrefs.SetInt("goldenNeedle", boolToInt(goldenNeedle));
            PlayerPrefs.SetInt("projAttack", boolToInt(projAttack));
            PlayerPrefs.SetInt("gpAttack", boolToInt(gpAttack));
        }

        if (courage < maxCourage)
        {
            courage += Time.deltaTime * 10;
        }

        if (SceneManager.GetActiveScene().name == "Hopscotch Shop")
        {
            playerHealth = maxHealth;
        }

        if (protagAnimator.GetBool("isTransforming"))
        {
            myPhysics.velocity = new Vector2(0, 0);  
        }

        switchTimer += Time.deltaTime;

        if (this != null && !protagAnimator.GetBool("cutsceneIdle") && !protagAnimator.GetBool("isTransforming"))
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

            if (isGrounded == true && Input.GetKeyDown(KeyCode.W)) //potentially if j is pressed as well
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
                //meleeSound.Play();
            }
            
            if (Input.GetKey(KeyCode.K))
            {
                //do stuff (light/courage magic)
            }

            //2.5 seconds
            //It turns back from fear mode if it is already in it as well. Also it can only be activated if there is fear in the bar
            if (Input.GetKey(KeyCode.L))
            {
                if (fearBarCtr >= 10)
                {
                    if (switchTimer >= 2.5)
                    {
                        if (protagAnimator.GetBool("NightmareSwitch"))
                        {
                            protagAnimator.SetBool("NightmareSwitch", false);
                        }
                        else if (nightmareCooldown == 0)
                        {
                            protagAnimator.SetBool("NightmareSwitch", true);
                        }
                        switchTimer = 0;
                    }
                }
            }

            //deltatime is 1 per second
            if (protagAnimator.GetBool("NightmareSwitch"))
            {
                if (fearBarCtr > 0)
                {
                    fearBarCtr -= Time.deltaTime * 25;
                }
                else
                {
                    fearBarCtr = 0;
                }
                nightmareCooldown = nightmareCooldownTime;
            }
            else
            {
                if (nightmareCooldown > 0)
                {
                    nightmareCooldown -= Time.deltaTime;
                }
                else
                {
                    nightmareCooldown = 0;
                }
                fearOverUseTimer = 0;
            }
            if (fearBarCtr == 0 && protagAnimator.GetBool("NightmareSwitch"))
            {
                fearOverUseTimer += Time.deltaTime;
                nightmareDmgTimer += Time.deltaTime;
                if (Mathf.RoundToInt(fearOverUseTimer) % 5 == 0 && !nightmareDmg)
                {
                    takeDamage();
                    nightmareDmg = true;
                    nightmareDmgTimer = 0;
                }
                if (Mathf.RoundToInt(nightmareDmgTimer) == 2)
                {
                    nightmareDmg = false;
                }

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
        Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);

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
            //Destroy(this.gameObject);
            //SceneManager.LoadScene("GameOver");
            pitRespawnPoint = thingProtagHit.gameObject.GetComponentInChildren<Transform>(true);
            this.transform.position = new Vector3(pitRespawnPoint.position.x, pitRespawnPoint.position.y, 0);
            this.takeDamage();
            //Destroy(this.gameObject);
            //SceneManager.LoadScene("GameOver");
        }
    }

    public void OnCollisionExit2D(Collision2D thingProtagHit)
    {
        Debug.Log("Cuddlesworth stopped touching " + thingProtagHit.gameObject.name);

        if (thingProtagHit.gameObject.CompareTag("ground")) //TODO: also check that you are colliding with the TOP of the ground tile...
        {
            //Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            protagAnimator.SetBool("GroundTapped", false);
            isGrounded = false;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FearBall"))
        {
            fear += 50;
            if (fearBarCtr <=  maxFear - 50)
            {
                fearBarCtr += 50;
            }
            else
            {
                fearBarCtr += maxFear - fearBarCtr;
            }
            Object.Destroy(collision.gameObject);
        }
        else
        {

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

        if (!protagAnimator.GetBool("isTransforming"))
        {
            Debug.Log("Player health before hit: " + playerHealth);

            //Lowers enemy health
            playerHealth--;

            //Plays damage taking animation
            protagAnimator.SetBool("TookDamage", true);
            normAnimator.SetBool("dmgTaken", true);
            nightmareAnimator.SetBool("dmgTaken", true);
            Debug.Log("Player health after hit: " + playerHealth);

            //Kills enemy if they have no health
        }
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");

            //Fixes glitch where fearbar ctr will be out of bounds when revived
            fearBarCtr = 0;
            PlayerPrefs.SetFloat("fearBarCtr", fearBarCtr);

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

    public bool getNightmare()
    {
        if (this != null)
        {
            return protagAnimator.GetBool("NightmareSwitch");
        }
        else
        {
            return false;
        }
    }
    public float getCourage()
    {
        return courage;
    }

    public float getFearBar()
    {
        return fearBarCtr;
    }

    public float getNightmareCooldown()
    {
        return nightmareCooldown;
    }

    public bool nightmareReady()
    {
        if (nightmareCooldown > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        fear += 10;
        if (fearBarCtr < maxFear)
        {
            fearBarCtr += 10;
        }
        Debug.Log("Fear is " + fear);
    }

    private int boolToInt(bool b)
    {
        if (b)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
    private bool intToBool(int i)
    {
        if (i == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void heal() //****************************************************************
    {
        playerHealth = maxHealth;
    }

}

