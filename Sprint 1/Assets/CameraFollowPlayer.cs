using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public int startLine;
    public int endLine;
    public int floor;
    public int celing;
    public int yDisplacement = 0;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //startLine = 0;
        //endLine = 156;
        //floor = 0;
        //celing = 4;
        //yDisplacement = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.transform.position.x >= startLine && player.transform.position.x < endLine) //player is to the right of start area and to the left of end area
            {
                if (player.transform.position.y >= (floor - yDisplacement))
                {
                    if (player.transform.position.y < celing - yDisplacement)
                    {
                        this.transform.position = new Vector3(player.transform.position.x, ((player.transform.position.y) + yDisplacement), -10);
                    }
                    else
                    {
                        this.transform.position = new Vector3(player.transform.position.x, celing, -10);
                    }
                }
                else
                {
                    this.transform.position = new Vector3(player.transform.position.x, floor, -10);
                }
            }
            else if (player.transform.position.x < startLine)
            {
                if (player.transform.position.y >= floor - yDisplacement) // above the ground level
                {
                    if (player.transform.position.y < celing) // celing cap
                    {
                        this.transform.position = new Vector3(startLine, ((player.transform.position.y) + yDisplacement), -10);
                    }
                    else //somewhere between the ground level and the celing cap
                    {
                        this.transform.position = new Vector3(startLine, celing, -10);
                    }
                }
                else
                    this.transform.position = new Vector3(startLine, floor, -10);
            }
            else if (player.transform.position.x >= endLine)
            {
                if (player.transform.position.y >= floor - yDisplacement) // above the ground level
                {
                    if (player.transform.position.y < celing - yDisplacement) // celing cap
                    {
                        this.transform.position = new Vector3(endLine, ((player.transform.position.y) + yDisplacement), -10);
                    }
                    else //somewhere between the ground level and the celing cap
                    {
                        this.transform.position = new Vector3(endLine, celing, -10);
                    }
                }
                else
                    this.transform.position = new Vector3(endLine, floor, -10);
            }
        }
    }
}

