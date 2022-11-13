using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    //uncomment this when you have the enemy script
    GooGremlinScript myGremlinScript;
    ShadowImp myImpScript;
    GooGremlinDefaultScript myGremlinDefaultScript;
    //GameObject[] enemy;

    void Start()
    {
            //enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {//uncomment this when you have the enemy script
            //Debug.Log("Player attack hit");
            myGremlinScript = collision.gameObject.GetComponent<GooGremlinScript>();
            myGremlinScript.takeDamage();
        }
        if (collision.gameObject.CompareTag("EnemyDF"))
        {//uncomment this when you have the enemy script
            //Debug.Log("Player attack hit");
            myGremlinDefaultScript = collision.gameObject.GetComponent<GooGremlinDefaultScript>();
            myGremlinDefaultScript.takeDamage();
        }
        if (collision.gameObject.CompareTag("Imp"))
        {//uncomment this when you have the enemy script
            //Debug.Log("Player attack hit");
            myImpScript = collision.gameObject.GetComponent<ShadowImp>();
            myImpScript.takeDamage();
        }

    }
}
