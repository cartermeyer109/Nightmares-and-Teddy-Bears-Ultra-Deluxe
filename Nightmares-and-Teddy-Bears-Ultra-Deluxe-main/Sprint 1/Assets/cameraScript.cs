using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
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
<<<<<<< HEAD
        transform.position = new Vector3(player.transform.position.x, 2, -10);
=======
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, -10);
>>>>>>> b25a4cebddf2e657b0341af6e3c19760e4f7f5d8
    }
}
