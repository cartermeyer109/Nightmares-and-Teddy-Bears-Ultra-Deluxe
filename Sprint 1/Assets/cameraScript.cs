using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cameraScript : MonoBehaviour
{

    //Left Border
    GameObject leftWall;
    float wallPosX;
    float playerPosX;

    //Text objects
    GameObject tutorialText;
    GameObject thankYouText;

    //Player Fields
    GameObject player;
    Animator protagAnimator;
    Rigidbody2D protagPhysics;
    float protagPositionCS3;
    GameObject stats;

    //Goo Gremlin Fields
    GameObject gremlin;
    Animator enemyAnimator;
    float gremPositionCS2;

    //Black Bar Fields
    GameObject blackBarsHolder;
    Animator blackBarsAnimator;

    //Cutscene 1 Fields
    bool cutsceneOn = false;
    bool cutsceneCompleted = false;
    float cutsceneStartTime = 0f;

    //Cutscene 2 Fields
    bool cutsceneOn2 = false;
    bool cutsceneCompleted2 = false;

    //Cutscene 3 Fields
    bool cutsceneOn3 = false;
    bool cutsceneCompleted3 = false;



    // Start is called before the first frame update
    void Start()
    {
        leftWall = GameObject.FindGameObjectWithTag("Boundary");
        leftWall.SetActive(false);

        thankYouText = GameObject.FindGameObjectWithTag("Thank You");
        thankYouText.SetActive(false);

        tutorialText = GameObject.FindGameObjectWithTag("Tutorial Text");
        tutorialText.SetActive(false);

        //Player initiations
        player = GameObject.FindGameObjectWithTag("Player");
        protagAnimator = player.GetComponent<Animator>();
        protagPhysics = player.GetComponent<Rigidbody2D>();
        stats = GameObject.FindGameObjectWithTag("Stats");

        //Gremlin initiations
        gremlin = GameObject.FindGameObjectWithTag("Enemy");
        enemyAnimator = gremlin.GetComponent<Animator>();
        gremlin.SetActive(false);

        //Black bars initiations
        blackBarsHolder = GameObject.FindGameObjectWithTag("Black Bars");
        blackBarsAnimator = blackBarsHolder.GetComponent<Animator>();
        blackBarsHolder.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        //Controls boundary
        //If going forward
        if (!cutsceneOn3) //Fixes a specific glitch with cutscene 3 where it wont show the hatch opening
        {
            if (protagPhysics.velocity.x >= 0 && player.transform.position.x >= playerPosX)
            {
                leftWall.transform.position = new Vector2(player.transform.position.x - 11, player.transform.position.y);
                wallPosX = leftWall.transform.position.x;
                playerPosX = player.transform.position.x;

            }
            //If going backwards
            if (player.transform.position.x < playerPosX)
            {
                leftWall.transform.position = new Vector2(wallPosX, player.transform.position.y);
                this.transform.position = new Vector3(playerPosX, this.transform.position.y, -10);
            }
        }

        //Solves an issue where protagAnim's "goingdown" variable wont turn off during cutscenes
        if (protagPhysics.velocity.y < -0.5)
        {
            protagAnimator.SetBool("GoingDown", true);
        }
        else
        {
            protagAnimator.SetBool("GoingDown", false);
        }

        //DEFAULT STUFF
        //Set camera to normal if a cutscene is not on
        if (!cutsceneOn && !cutsceneOn2 && !cutsceneOn3)
        {
            //Camera follows player but has a fixed y axis
            if (player.transform.position.x >= playerPosX)
            {
                this.transform.position = new Vector3(player.transform.position.x, 1, -10);
            }

            //Protag is set to normal behavior
            protagAnimator.SetBool("cutsceneIdle", false);

            //Gremlin is idle during cutscenes unless he doesn't exist!
            if (gremlin != null)
            {
                enemyAnimator.SetBool("cutsceneIdle", false);
            }

        }

        //Goes down through th eorder of cutscenes
        if (!cutsceneCompleted)
        {
            cutsceneOne();
        }

        if (cutsceneCompleted && !cutsceneCompleted2)
        {
            hopscotchTalks();
        }

        if (cutsceneCompleted && cutsceneCompleted2 && !cutsceneCompleted3)
        {
            hopscotchThanks();
        }



    }


    void cutsceneOne()
    {
        //If the custscene hasn't activated yet, but the player is in the cutscene area
        if (player.transform.position.x >= 35 && !cutsceneOn)
        {
            //*Set start time* and mark that the cutscene has started
            cutsceneStartTime = Time.time;
            cutsceneOn = true;
            leftWall.SetActive(true);
        }

        //For the duration of the entire cutscene (5 seconds)
        if (Time.time - cutsceneStartTime < 5 && cutsceneOn)
        {

            //Activate the black bars which start the default animation of them entering the scene
            blackBarsHolder.SetActive(true);
            stats.SetActive(false);

            //Set protag's animation to idle
            protagAnimator.SetBool("cutsceneIdle", true);

            //Set protag's x axis to static, but keep the y axis normal in case the cutscene
            //is activate with the protag mid-air
            player.transform.position = new Vector2(35, player.transform.position.y);

            //Put camera in place of the cutscene line
            this.transform.position = new Vector3(35, 1, -10);

            //Between 1-4.5 seconds into the cutscene
            if (Time.time - cutsceneStartTime >= 1 && Time.time - cutsceneStartTime < 4.5)
            {
                //Activate gremlin, casuing them to do their rise animation
                gremlin.SetActive(true);

                //Set gremlin's animation to idle emedietly
                enemyAnimator.SetBool("cutsceneIdle", true);
            }
            //at 4.5 seconds 
            else if (Time.time - cutsceneStartTime >= 4.5)
            {
                //allow gremlin to enter his normal behavior
                enemyAnimator.SetBool("cutsceneIdle", false);
            }
        }
        //Once the cutscene is over 
        else if (cutsceneOn)
        {
            //hide the black bars
            blackBarsAnimator.SetBool("hideBars", true);
            stats.SetActive(true);

            //Mark that the cutscene has been completed
            cutsceneCompleted = true;

            //mark that the cutscene is over
            cutsceneOn = false;
        }
    }

    void hopscotchTalks()
    {
        //If the second custscene hasn't activated yet, but the player is in the second cutscene area
        if (player.transform.position.x >= 56 && !cutsceneOn2)
        {
            //Turning it off to not cause issues
            if (blackBarsHolder != null) {
                blackBarsHolder.SetActive(false);
            }

            //Mark the current position of the gremlin
            gremPositionCS2 = gremlin.transform.position.x;

            //Start tutorial text and its code
            stats.SetActive(false);
            tutorialText.SetActive(true);

            //Set start time and mark that the cutscene has started
            cutsceneOn2 = true;

        }

        //While the text is on
        if (tutorialText.activeSelf)
        {

            //Set protag and gremlin animations to idle
            protagAnimator.SetBool("cutsceneIdle", true);
            enemyAnimator.SetBool("cutsceneIdle", true);

            //Set gremlin movement to pause at the position he was at when the cutscene started
            gremlin.transform.position = new Vector2(gremPositionCS2, gremlin.transform.position.y);

            //Set protag's x axis to static, but keep the y axis normal in case the cutscene
            //is activate with the protag mid-air
            player.transform.position = new Vector2(56, player.transform.position.y);

            //Keep camera in place
            this.transform.position = new Vector3(56, 1, -10);
        }
        else if (cutsceneOn2)
        {
            stats.SetActive(true);
            cutsceneCompleted2 = true;
            cutsceneOn2 = false;
            protagAnimator.SetBool("JPressed", false);
        }
    }

    void hopscotchThanks()
    {
        //WE WANT THE CAMERA TO BE AT X = 71 60 FPS. (DISTANCE BETWEEN PLAYER AND 71)/ 2 SECONDS (120 FRAMES) IS THE DISTANCE MOVED PER FRAME

        if (gremlin == null && !cutsceneOn3)
        {
            //Start tutorial text and its code
            stats.SetActive(false);
            thankYouText.SetActive(true);

            //Mark that cutscene 3 has started
            cutsceneOn3 = true;

            //Mark the position of the protagonist
            protagPositionCS3 = player.transform.position.x;
        }

        if (thankYouText.activeSelf)
        {
            //Set protagonist to idle animation
            protagAnimator.SetBool("cutsceneIdle", true);

            //Have player stuck in place on his x axis using the position marking
            player.transform.position = new Vector2(protagPositionCS3, player.transform.position.y);

            //Set the camera to keep following
            //this.transform.position = new Vector3(protagPositionCS3, 1, -10);
        }
        else if (cutsceneOn3)
        {
            stats.SetActive(true);
            cutsceneCompleted3 = true;
            cutsceneOn3 = false;
        }
    }
}