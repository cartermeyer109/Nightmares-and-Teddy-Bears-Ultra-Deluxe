using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    //uncomment this when you have the enemy script
    GooGremlinScript myGremlinScript;
    ShadowImp myImpScript;
    GooGremlinDefaultScript myGremlinDefaultScript;
    HulkDefuaultScript myHulkDefaultScript;

    MovementScript playerscript;
    Animator playerAnimator;
    //GameObject[] enemy;

    void Start()
    {
        playerscript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementScript>();
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        //enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GremlinHitBox"))
        {//uncomment this when you have the enemy script
            //Debug.Log("Player attack hit");
            myGremlinScript = collision.gameObject.transform.GetComponentInParent<GooGremlinScript>();
            myGremlinScript.takeDamage();
            if (playerscript.getGoldenNeedle() > -1)
            {
                myGremlinScript.takeDamage();

            }
            else if (playerAnimator.GetBool("NightmareSwitch")) {
                myGremlinScript.takeDamage();
                myGremlinScript.takeDamage();
            }
        }
        if (collision.gameObject.CompareTag("GremlinHitBoxDF"))
        {//uncomment this when you have the enemy script
            //Debug.Log("Player attack hit");
            myGremlinDefaultScript = collision.gameObject.transform.GetComponentInParent<GooGremlinDefaultScript>();
            myGremlinDefaultScript.takeDamage();
            if (playerscript.getGoldenNeedle() > -1)
            {
                myGremlinDefaultScript.takeDamage();

            }
            else if (playerAnimator.GetBool("NightmareSwitch")) {
                myGremlinDefaultScript.takeDamage();
                myGremlinDefaultScript.takeDamage();
            }
        }
        if (collision.gameObject.CompareTag("ImpHitBox"))
        {//uncomment this when you have the enemy script
            //Debug.Log("Player attack hit");
            myImpScript = collision.gameObject.transform.GetComponentInParent<ShadowImp>();
            myImpScript.takeDamage();
            if (playerscript.getGoldenNeedle() > -1)
            {
                myImpScript.takeDamage();

            }
            else if (playerAnimator.GetBool("NightmareSwitch")) {
                myImpScript.takeDamage();
                myImpScript.takeDamage();
            }

        }
        if (collision.gameObject.CompareTag("HulkHitBox"))
        {//uncomment this when you have the enemy script
            //Debug.Log("Player attack hit");
            myHulkDefaultScript = collision.gameObject.transform.GetComponentInParent<HulkDefuaultScript>();
            myHulkDefaultScript.takeDamage();
            if (playerscript.getGoldenNeedle() > -1)
            {
                myHulkDefaultScript.takeDamage();

            }
            else if (playerAnimator.GetBool("NightmareSwitch")) {
                myHulkDefaultScript.takeDamage();
                myHulkDefaultScript.takeDamage();
            }

        }
        Debug.Log("Attack Collision Happened");
    }
}
