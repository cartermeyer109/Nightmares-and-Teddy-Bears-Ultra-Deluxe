using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEventsScript : MonoBehaviour
{
    //Player Fields
    GameObject player;
    Animator animator;

    //Goo Gremlin Fields
    GameObject[] gremlin;

    // Start is called before the first frame update
    void Start()
    {
        //Player initiations
        player = GameObject.FindGameObjectWithTag("Player");
        animator = player.gameObject.GetComponent<Animator>();
        animator.SetBool("NeedleObtained", true);

        //Gremlin initiations
        gremlin = GameObject.FindGameObjectsWithTag("EnemyDF");
        //enemyAnimator = gremlin.GetComponent<Animator>();
        for (int i = 0; i < gremlin.Length; i++)
        {
            gremlin[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gremlin.Length; i++)
        {
            if (gremlin[i] != null)
            {
                if (Mathf.Abs(player.transform.position.x - gremlin[i].transform.position.x) <= 6 && Mathf.Abs(player.transform.position.y - gremlin[i].transform.position.y) <= 5)
                {
                    gremlin[i].SetActive(true);
                }
            }
        }
    }
}
