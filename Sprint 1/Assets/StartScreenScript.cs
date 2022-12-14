using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    Transform optionHighlighter;
    bool startSelected = true;
    Animator camera;
    float timer = 0;
    float enterTime;
    bool buttonPressed;

    // Start is called before the first frame update
    void Start()
    {
        optionHighlighter = GameObject.Find("OptionHighlighter").GetComponent<Transform>();
        optionHighlighter.position = new Vector3(-1.279f, 1.04f, 0);
        optionHighlighter.localScale = new Vector3(2, 2, 1);

        camera = GameObject.Find("Main Camera").GetComponent<Animator>();

        timer = 0;

    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (!buttonPressed)
        {
            if (!startSelected && Input.GetKeyDown(KeyCode.W))
            {
                startSelected = true;
                optionHighlighter.position = new Vector3(-1.279f, 1.04f, 0);
                optionHighlighter.localScale = new Vector3(2, 2, 1);
            }

            if (startSelected && Input.GetKeyDown(KeyCode.S))
            {
                startSelected = false;
                optionHighlighter.position = new Vector3(-0.99f, 0.096f, 0);
                optionHighlighter.localScale = new Vector3(1, 1, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) && !buttonPressed)
        {
            buttonPressed = true;
            enterTime = timer;

            if (startSelected)
            {
                camera.Play("StartZoom");
            }
            else
            {
                camera.Play("DownToUp");
            }
        }
        if (buttonPressed && Time.time - enterTime >= 2.66f && startSelected)
        {
            //NATE LOAD THE TUTORIAL SCENE IN THIS BOX HERE
            StartCoroutine(enterScene(2.66f, "TutorialLevel"));
        }
        //if (buttonPressed && Time.time - enterTime >= .56666f && !startSelected)
        //{
        //    //NATE LOAD THE CREDIT SCENE IN THIS BOX HERE YOU BEAUTIFUL MAN
        //    SceneManager.LoadScene("Credits");
        //}
        if (buttonPressed &&/* Time.time - enterTime >= .56666f &&*/ !startSelected) 
            StartCoroutine(enterScene(.56666f, "Credits"));
    }

    public IEnumerator enterScene(float time, string scene)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene(scene);
    }
}
