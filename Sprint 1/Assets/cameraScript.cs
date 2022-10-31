using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cameraScript : MonoBehaviour
{
    //GameObject runTextHolder;
    //public TextMeshPro runText;

    GameObject tutorialText;

    //Player Fields
    GameObject player;
    Animator protagAnimator;

    //Goo Gremlin Fields
    GameObject gremlin;
    Animator enemyAnimator;
    float gremPositionCS2;

    //Black Bar Fields
    GameObject blackBarsHolder;
    Animator blackBarsAnimator;

    //Cutscene 1 Fields
    bool cutsceneActivated = false;
    bool cutsceneOver = true;
    float cutsceneStartTime = 0f;

    //Cutscene 2 Fields
    bool cutsceneActivated2 = false;
    bool cutsceneOver2 = true;
    float cutsceneStartTime2 = 0f;


    // Start is called before the first frame update
    void Start()
    {
        //runTextHolder = GameObject.FindGameObjectWithTag("RunText");
        //runTextHolder.SetActive(false);

        tutorialText = GameObject.FindGameObjectWithTag("Tutorial Text");
        tutorialText.SetActive(false);

        //Player initiations
        player = GameObject.FindGameObjectWithTag("Player");
        protagAnimator = player.GetComponent<Animator>();

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
        //CUTSCENE ONE
        if (cutsceneOver)
        {
            this.transform.position = new Vector3(player.transform.position.x, 1, -10);
        }
        if (player.transform.position.x >= 35 && !cutsceneActivated)
        {
            cutsceneStartTime = Time.time;
            cutsceneActivated = true;
        }

        if (Time.time - cutsceneStartTime < 5 && cutsceneActivated)
        {
            cutsceneOver = false;
            blackBarsHolder.SetActive(true);
            protagAnimator.SetBool("cutsceneIdle", true);
            player.transform.position = new Vector2(35, player.transform.position.y);
            this.transform.position = new Vector3(35, 1, -10);

            if (Time.time - cutsceneStartTime >= 1 && Time.time - cutsceneStartTime < 4.5)
            {
                gremlin.SetActive(true);
                enemyAnimator.SetBool("cutsceneIdle", true);
            }
            else if (Time.time - cutsceneStartTime >= 4.5)
            {
                enemyAnimator.SetBool("cutsceneIdle", false);
            }

            /*if (Time.time - cutsceneStartTime >= 3)
            {
                runTextHolder.SetActive(true);
            }*/
        }
        else
        {
            protagAnimator.SetBool("cutsceneIdle", false);
            cutsceneOver = true;
            blackBarsAnimator.SetBool("hideBars", true);
        }

        //CUTSCENE TWO

        if (cutsceneOver)
        {
            if (player.transform.position.x >= 56 && !cutsceneActivated2)
            {
                cutsceneStartTime2 = Time.time;
                cutsceneActivated2 = true;
                gremPositionCS2 = gremlin.transform.position.x;
                //runTextHolder.SetActive(false);
                //Debug.Log("Time logged");
            }

            if (Time.time - cutsceneStartTime2 < .6 && cutsceneActivated2 || tutorialText.activeSelf && cutsceneActivated2)
            {

                cutsceneOver2 = false;
                blackBarsAnimator.SetBool("hideBars", false);
                protagAnimator.SetBool("cutsceneIdle", true);
                enemyAnimator.SetBool("cutsceneIdle", true);
                gremlin.transform.position = new Vector2(gremPositionCS2, gremlin.transform.position.y);
                player.transform.position = new Vector2(56, player.transform.position.y);
                this.transform.position = new Vector3(56, 1, -10);

                if (Time.time - cutsceneStartTime2 > .5)
                {
                    tutorialText.SetActive(true);
                }

            }
            else
            {
                protagAnimator.SetBool("cutsceneIdle", false);
                cutsceneOver2 = true;
                blackBarsAnimator.SetBool("hideBars", true);
                if (gremlin != null)
                {
                    enemyAnimator.SetBool("cutsceneIdle", false);
                }
            }
        }
    }
}
