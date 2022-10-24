using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareWorld : MonoBehaviour
{

    private GameObject evilBackground;
    private GameObject evilBackObj;
    private GameObject evilTiles;
    public bool didGlitch;
    public bool isNightmareScene;

    // Start is called before the first frame update
    void Start()
    {
        evilBackground = GameObject.Find("evilBackground");
        evilBackObj = GameObject.Find("EvilBackground");
        evilTiles = GameObject.Find("EvilTiles");
        didGlitch = false;
        endNightmareMode();
        isNightmareScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartCoroutine(glitchTimedCounter());
        //}

        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    setNightmareMode();
        //}

        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    endNightmareMode();
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mushroom"))
        {
            //Debug.Log("hit mushroom");
            if (!didGlitch)
            {
                StartCoroutine(glitchTimedCounter());
                didGlitch = true;
            }
        }

        if (other.gameObject.CompareTag("NightmareLine"))
        {
            if (!isNightmareScene)
            {
                setNightmareMode();
            }
        }
    }

    public IEnumerator glitchTimedCounter()
    {
        Debug.Log("start nightmare world");
        setNightmareMode();
        yield return new WaitForSeconds(1);
        //yield return null;
        Debug.Log("end nightmare world");
        endNightmareMode();
    }

    void setNightmareMode()
    {
        evilBackground.SetActive(true);
        evilBackObj.SetActive(true);
        evilTiles.SetActive(true);
        isNightmareScene = true;
    }

    void endNightmareMode()
    {
        evilBackground.SetActive(false);
        evilBackObj.SetActive(false);
        evilTiles.SetActive(false);
        isNightmareScene = false;
    }

}

