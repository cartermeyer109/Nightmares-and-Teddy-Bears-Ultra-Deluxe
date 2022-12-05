using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour
{
    GameObject trackerObject;
    levelTracker LevelTracker;

    // Start is called before the first frame update
    void Start()
    {
        trackerObject = GameObject.FindWithTag("LevelTracker");
        LevelTracker = trackerObject.gameObject.GetComponent<levelTracker>();
        if (LevelTracker.getLevelNum() == 0)
        {
            SceneManager.LoadScene("TutorialLevel");
        }
        else
        {
            StartCoroutine(respawnDelay());
        }
    }

    public IEnumerator respawnDelay()
    {
        yield return new WaitForSeconds(5);
        LevelTracker.reloadShop();
    }
}
