using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterShopScript : MonoBehaviour
{
    public bool isEnd;
    GameObject trackerObject;
    levelTracker LevelTracker;


    // Start is called before the first frame update
    void Start()
    {
        trackerObject = GameObject.FindWithTag("LevelTracker");
        LevelTracker = trackerObject.gameObject.GetComponent<levelTracker>();
        
    }

    //// Update is called once per frame
    //void Update()
    //{
    //}

    public void OnCollisionEnter2D(Collision2D thingHit)
    {
        if (thingHit.gameObject.CompareTag("Player"))
        {
            if (isEnd)
            {
                LevelTracker.progressLevel();
            }
            else
            {
                LevelTracker.reloadShop();
            }
        }
    }
}
