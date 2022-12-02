using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooGremlinMeleeScript : MonoBehaviour
{// This Script is for the hitbox of the enemy attack animation and contains a collision function when it collides with the player
 //This is under the impression that you have a "takeDamage()" function in your player script to use here

    //Fields
    //I think this may only work if your player script is called "PlayerScript" but idk
    MovementScript playerScript;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //If you dont have the tag "Player" on the player object then you will need to change this to work
        player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log("We found a game object with a name of " + player.name);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if the object we collided with is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("gremlin Attack hit");
            //Destroy(collision.gameObject);

            //Use the takeDamage(); function that they player has to lower the players health.
            playerScript = collision.gameObject.GetComponent<MovementScript>();
            playerScript.takeDamage();
            playerScript.myPhysics.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        }
    }
}
