using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.x >= 0 && player.transform.position.x < 156) //player is to the right of start area and to the left of end area
            {
                if (player.transform.position.y >= 0)
                {
                    if (player.transform.position.y < 4)
                    {
                        this.transform.position = new Vector3(player.transform.position.x, ((player.transform.position.y)), -10);
                    }
                    else
                    {
                        this.transform.position = new Vector3(player.transform.position.x, 4, -10);
                    }
                }
                else
                {
                    this.transform.position = new Vector3(player.transform.position.x, 0, -10);
                }
            }
            else if (player.transform.position.x < 0)
            {
                if (player.transform.position.y >= 0) // above the ground level
                {
                    if (player.transform.position.y < 4) // celing cap
                    {
                        this.transform.position = new Vector3(0, ((player.transform.position.y)), -10);
                    }
                    else //somewhere between the ground level and the celing cap
                    {
                        this.transform.position = new Vector3(0, 4, -10);
                    }
                }
                else
                    this.transform.position = new Vector3(0, 0, -10);
            }
            else if (player.transform.position.x >= 156)
            {
                if (player.transform.position.y >= 0) // above the ground level
                {
                    if (player.transform.position.y < 4) // celing cap
                    {
                        this.transform.position = new Vector3(156, ((player.transform.position.y)), -10);
                    }
                    else //somewhere between the ground level and the celing cap
                    {
                        this.transform.position = new Vector3(156, 4, -10);
                    }
                }
                else
                    this.transform.position = new Vector3(156, 0, -10);
            }
        }
    }
}

