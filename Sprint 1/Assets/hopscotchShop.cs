using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hopscotchShop : MonoBehaviour
{
    GameObject player;

    public bool facingLeft;
    public bool hasFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position.x > this.transform.position.x))
        {
            facingLeft = false;
        }
        //Else if player is on the left side of the enemy
        else
        {
            facingLeft = true;
        }

        //If player is on the right of the enemy (facingLeft == true) and the enemy has not flipped yet.
        if (!facingLeft && !hasFlipped)
        {
            //Flip enemy to the right
            this.transform.localScale *= new Vector2(-1, 1);
            //Recognize that the enemy has flipped
            hasFlipped = true;
        }

        //If the player has fliped to the right (meaning they are currently facing right) and the player is on the left side of the enemy
        if (hasFlipped && facingLeft)
        {
            //Flip enemy to the left
            this.transform.localScale *= new Vector2(-1, 1);
            //Recognize the enemy is now facing their default direction
            hasFlipped = false;
        }
    }
}
