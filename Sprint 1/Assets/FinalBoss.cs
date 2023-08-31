using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    GameObject camera;
    GameObject player;
    Rigidbody2D playerPhysics;
    Animator playerAnimator;
    MovementScript playerScript;
    float runTime;

    GameObject boogeyMan;
    Animator BMAnimator;
    float startTime = 0;
    bool introDone = false;
    bool BRStarted = false;
    BoogeyManScript BMScript;
    bool wholeIntroDone = false;

    int order = 0;

    GameObject canvas;

    RectTransform health;

    GameObject finalPage;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");

        camera = GameObject.Find("Main Camera");
        player = GameObject.Find("protag Variant");
        playerScript = player.GetComponent<MovementScript>();
        playerPhysics = player.GetComponent<Rigidbody2D>();
        playerAnimator = player.GetComponent<Animator>();
        runTime = Time.time;
        playerAnimator.Play("BossWalk");

        boogeyMan = GameObject.Find("BoogeyMan");
        BMScript = boogeyMan.GetComponent<BoogeyManScript>();
        
        BMAnimator = boogeyMan.GetComponent<Animator>();

        health = GameObject.Find("EnemyHealth").GetComponent<RectTransform>();

        canvas.transform.GetChild(2).gameObject.SetActive(false);

        finalPage = GameObject.Find("Final Page Holder");
        finalPage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas.transform.GetChild(2).gameObject.activeSelf)
        {
            health.localScale = new Vector3((float)(BMScript.enemyHealth * 2.7675), 60, 1);
        }

        //Intro Sequence
        if (player != null)
        {
            if (boogeyMan != null)
            {
                if (!wholeIntroDone)
                {
                    if (!introDone)
                    {
                        playerAnimator.SetBool("cutsceneIdle", true);
                        canvas.transform.GetChild(1).gameObject.SetActive(true);
                        introDone = true;
                        order++;
                    }
                    if (introDone)
                    {
                        if (!canvas.transform.GetChild(1).gameObject.activeSelf)
                        {
                            BMAnimator.SetBool("battleReady", true);
                            BRStarted = true;
                            order++;
                        }
                        if (order >= 2)
                        {
                            playerAnimator.SetBool("cutsceneIdle", false);
                            canvas.transform.GetChild(2).gameObject.SetActive(true);
                        }
                    }
                }
            }
        }

        if (BMScript.enemyHealth <= 0)
        {
            canvas.transform.GetChild(2).gameObject.SetActive(false);
            finalPage.SetActive(true);
        }

        //***************************************************
    }
}
