using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    GameObject player;
    public GameObject gremlin;
    GameObject blackBarsHolder;
    Animator protagAnimator;
    Animator blackBarsAnimator;

    bool cutsceneActivated = false;
    bool cutsceneOver = true;
    float cutsceneStartTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gremlin = GameObject.FindGameObjectWithTag("Enemy");
        blackBarsHolder = GameObject.FindGameObjectWithTag("Black Bars");
        blackBarsAnimator = blackBarsHolder.GetComponent<Animator>();
        protagAnimator = player.GetComponent<Animator>();
        blackBarsHolder.SetActive(false);
        gremlin.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
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
            player.transform.position = new Vector2(35, -0.986007f);
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
    }
}
