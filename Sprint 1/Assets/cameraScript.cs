using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    //Player Fields
    GameObject player;
    Animator protagAnimator;

    //Goo Gremlin Fields
    public GameObject gremlin;
    Animator enemyAnimator;

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
        if (Time.time - cutsceneStartTime < 4 && cutsceneActivated)
        {
            cutsceneOver = false;
            blackBarsHolder.SetActive(true);
            protagAnimator.SetBool("cutsceneIdle", true);
            player.transform.position = new Vector2(35, player.transform.position.y);
            this.transform.position = new Vector3(35, 1, -10);

            if (Time.time-cutsceneStartTime >= 1)
            {
                gremlin.SetActive(true);
            }
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
            if (cutsceneOver2)
            {
                this.transform.position = new Vector3(player.transform.position.x, 1, -10);
            }
            if (player.transform.position.x >= 56 && !cutsceneActivated2)
            {
                cutsceneStartTime2 = Time.time;
                cutsceneActivated2 = true;
            }
            if (Time.time - cutsceneStartTime2 < 4 && cutsceneActivated2)
            {
                cutsceneOver2 = false;
                blackBarsAnimator.SetBool("hideBars", false);
                protagAnimator.SetBool("cutsceneIdle", true);
                enemyAnimator.SetBool("cutsceneIdle", true);
                player.transform.position = new Vector2(56, player.transform.position.y);
                this.transform.position = new Vector3(56, 1, -10);
            }
            else
            {
                protagAnimator.SetBool("cutsceneIdle", false);
                enemyAnimator.SetBool("cutsceneIdle", false);
                cutsceneOver2 = true;
                blackBarsAnimator.SetBool("hideBars", true);
            }
        }
    }
}
