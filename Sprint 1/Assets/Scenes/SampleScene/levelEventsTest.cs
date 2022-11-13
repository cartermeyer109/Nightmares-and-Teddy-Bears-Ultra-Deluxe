using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelEventsTest : MonoBehaviour
{//This was created to set googremlins to not active before they rise from the ground
 // Start is called before the first frame update

    //Player Fields
    GameObject player;
    Animator protagAnimator;
    Rigidbody2D protagPhysics;

    //Goo Gremlin Fields
    GameObject gremlin;
    Animator enemyAnimator;

    void Start()
    {
        //Player initiations
        player = GameObject.FindGameObjectWithTag("Player");
        protagAnimator = player.GetComponent<Animator>();
        protagPhysics = player.GetComponent<Rigidbody2D>();

        //Gremlin initiations
        //gremlin = GameObject.FindGameObjectWithTag("EnemyDF");
        //enemyAnimator = gremlin.GetComponent<Animator>();
        //gremlin.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //goo gremlin is at x == 5 in this example (Im doing a range of +3/-3)
        //if (player.transform.position.x >= 2 && player.transform.position.x <= 8)
        //{
        //    gremlin.SetActive(true);
        //}
    }
}
