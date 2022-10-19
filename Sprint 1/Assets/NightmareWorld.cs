using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareWorld : MonoBehaviour
{

    private GameObject normalBackground;
    private GameObject normalBackObj;
    private GameObject normalTiles;
    

    // Start is called before the first frame update
    void Start()
    {

        normalBackground = GameObject.Find("background");
        normalBackObj = GameObject.Find("Background");
        normalTiles = GameObject.Find("NormalTiles");
        //evilTiles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(glitchTimedCounter());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            normalBackground.SetActive(false);
            normalBackObj.SetActive(false);
            normalTiles.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            normalBackground.SetActive(true);
            normalBackObj.SetActive(true);
            normalTiles.SetActive(true);
        }
    }

    public IEnumerator glitchTimedCounter()
    {
        Debug.Log("start nightmare world");
        normalBackground.SetActive(false);
        normalBackObj.SetActive(false);
        normalTiles.SetActive(false);
        yield return new WaitForSeconds(1);
        //yield return null;
        Debug.Log("end nightmare world");
        normalBackground.SetActive(true);
        normalBackObj.SetActive(true);
        normalTiles.SetActive(true);
    }
}

