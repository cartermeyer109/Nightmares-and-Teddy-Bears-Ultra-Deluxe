using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.ParticleSystem;

public class enemyRangeImp : MonoBehaviour
{//This script attacks only if the the player is in a certain range

    //Fields
    GameObject player;
    Animator enemyAnimator;

    public GameObject fireBall;
    public Transform fireBallPos;

    public float timer = 2.5f;
    public bool startTimer = false;
    public float fireBallTimer = 0;



    // Start is called before the first frame update
    void Start()
    {
        //spawnSpot = GameObject.Find("Spawn");

        //If you dont have the tag "Player" on the player object then you will need to change this to work
        player = GameObject.FindGameObjectWithTag("Player");
        enemyAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        //Makes sure a "player" exists
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            float distancex = Mathf.Abs(transform.position.x - player.transform.position.x);
            float distancey = Mathf.Abs(transform.position.y - player.transform.position.y);
            //Debug.Log("Timer = " + timer);

            timer += Time.deltaTime;

            //This checks distance between the this enemy and the player
            //I have it set to 2 difference x, and 3 difference y. But I don't know the
            //dimensions of the player we're using or if we are going to scale them.
            //(My GooGremlin is currently set to a scale of 5)
            if (distancex <= 4.5 && distancey <= 8)
            {
                if (timer >= 2.5)
                {
                    enemyAnimator.SetBool("attacked", true);
                    timer = 0;
                }
            }

            if (enemyAnimator.GetBool("CurrentlyAttacking"))
            {
                fireBallTimer += Time.deltaTime;
            }

            if (fireBallTimer >= 0.5)
            {
                shoot();
                fireBallTimer = 0f;
                timer = 0;
                enemyAnimator.SetBool("CurrentlyAttacking", false);
            }

        }
    }

    void shoot()
    {
        Instantiate(fireBall, fireBallPos.position, Quaternion.identity);
    }
}