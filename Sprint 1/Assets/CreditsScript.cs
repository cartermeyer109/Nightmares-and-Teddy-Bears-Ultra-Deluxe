using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    Animator camera;
    float enterTime;
    bool buttonPressed;

    bool firstPage;
    bool secondPage;
    bool finalPage;
    GameObject page1;
    GameObject page2;
    GameObject page3;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Animator>();

        camera.Play("MidToUp");

        page1 = GameObject.Find("Square");
        page2 = GameObject.Find("Square (1)");
        page3 = GameObject.Find("Square (2)");

        firstPage = true;
        secondPage = false;
        finalPage = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !buttonPressed && firstPage)
        {
            page1.SetActive(false);
            firstPage = false;
            secondPage = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !buttonPressed && secondPage)
        {
            page2.SetActive(false);
            secondPage = false;
            finalPage = true;
        }
        else if (Input.GetKeyDown(KeyCode.Return) && !buttonPressed && finalPage)
        {
            enterTime = Time.time;
            buttonPressed = true;
            camera.Play("UpToDown");
        }
        if (Time.time - enterTime >= 0.5666f && buttonPressed)
        {
            SceneManager.LoadScene("Start Screen");//NATE LOAD THE START SCENE IN THIS BOX HERE
        }
    }
}
