using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    Animator camera;
    float enterTime;
    bool buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Animator>();

        camera.Play("MidToUp");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !buttonPressed)
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
