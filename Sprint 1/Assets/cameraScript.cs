using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    GameObject player;
    public GameObject gremlin;
    Animator protagAnimator;

    bool cutsceneActivated = false;
    bool cutsceneOver = true;
    float cutsceneStartTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gremlin = GameObject.FindGameObjectWithTag("Enemy");
        protagAnimator = player.GetComponent<Animator>();
        gremlin.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (cutsceneOver)
        {
            this.transform.position = new Vector3(player.transform.position.x, 1, -10);
        }
        if (player.transform.position.x >= 32 && !cutsceneActivated)
        {
            cutsceneStartTime = Time.time;
            cutsceneActivated = true;
        }
        if (Time.time - cutsceneStartTime < 4.5 && cutsceneActivated)
        {
            cutsceneOver = false;
            protagAnimator.SetBool("cutsceneIdle", true);
            player.transform.position = new Vector2(32, -0.986007f);
            this.transform.position = new Vector3(32, 1, -10);

            if (Time.time-cutsceneStartTime >= 1)
            {
                gremlin.SetActive(true);
            }
        }
        else
        {
            protagAnimator.SetBool("cutsceneIdle", false);
            cutsceneOver = true;
        }
    }
}
