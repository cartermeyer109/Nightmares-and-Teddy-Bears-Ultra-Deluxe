using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    //uncomment this when you have the enemy script
    GooGremlinScript myEnemyScript;
    //TODO: replace with actual script name
    GameObject enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");//TODO: replace with actual tag name
        Debug.Log("Found " + enemy.name);
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {//uncomment this when you have the enemy script
            Debug.Log("Player attack hit");
            myEnemyScript = collision.gameObject.GetComponent<GooGremlinScript>();
            myEnemyScript.takeDamage();
        }
    }
}
