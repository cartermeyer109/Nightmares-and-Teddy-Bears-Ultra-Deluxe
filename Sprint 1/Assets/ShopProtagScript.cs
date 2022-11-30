using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ShopProtagScript : MonoBehaviour
{
    GameObject trackerObject;
    levelTracker LevelTracker;


    // Start is called before the first frame update
    void Start()
    {
        trackerObject = GameObject.Find("LevelTracker");
        LevelTracker = trackerObject.gameObject.GetComponent<levelTracker>();
        LevelTracker.nextLevel();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            //Debug.Log("test");
            SceneManager.LoadScene(LevelTracker.getLevel());
            //SceneManager.LoadScene("Tutorial Level");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            //Debuging only
            LevelTracker.nextLevel();
            Debug.Log("current level is set to " + LevelTracker.getLevel());
        }
    }
}
