using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseScreen : MonoBehaviour
{

    GameObject player;
    GameObject enemy;
    GameObject win;
    GameObject lose;
    GameObject camera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        win = GameObject.FindGameObjectWithTag("WinScreen");
        lose = GameObject.FindGameObjectWithTag("LoseScreen");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        //lose screen
        if (player == null)
        {
            //Debug.Log("you lose");
            win.SetActive(false);
        }
        //win screen
        if (enemy == null)
        {
            lose.SetActive(false);
            Destroy(camera);
        }
    }
}
