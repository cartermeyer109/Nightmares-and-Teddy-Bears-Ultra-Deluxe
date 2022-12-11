using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShopProtagScript : MonoBehaviour
{
    GameObject trackerObject;
    levelTracker LevelTracker;
    GameObject player;
    MovementScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        trackerObject = GameObject.FindWithTag("LevelTracker");
        LevelTracker = trackerObject.gameObject.GetComponent<levelTracker>();
        //if (LevelTracker.getLevelNum() == 0)
        //{ 
        //    LevelTracker.nextLevel();
        //}
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<MovementScript>();
        playerScript.heal();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space)){
        //    //Debug.Log("test");
        //    SceneManager.LoadScene(LevelTracker.getLevel());
        //    //SceneManager.LoadScene("Tutorial Level");
        //}
        if (Input.GetKeyDown(KeyCode.H))
        {
            //Debuging only
            LevelTracker.nextLevel();
            Debug.Log("current level is set to " + LevelTracker.getLevel());
        }
    }

    public void OnTriggerStay2D(Collider2D thingProtagHit)
    {
        if (thingProtagHit.gameObject.CompareTag("Rope")) 
        {
            //Debug.Log("Rope");
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene(LevelTracker.getLevel());
            }
        }
    }

}
