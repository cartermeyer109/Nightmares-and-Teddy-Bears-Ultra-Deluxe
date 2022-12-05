using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class thankYouText : MonoBehaviour
{
    //Padlock Fields
    GameObject padlock;
    Animator lockAnimator;

    GameObject door;
    Animator doorAnimator;

    public Text textbox;
    public TextMeshProUGUI enter;
    public int textNum;
    public float timeButtonHit = 0f;

    GameObject cam;
    float distanceToLock;
    float camStartX;

    bool transitionCam = false;
    //bool doorCanOpen = false;


    // Start is called before the first frame update
    void Start()
    {

        padlock = GameObject.FindGameObjectWithTag("Lock");
        lockAnimator = padlock.GetComponent<Animator>();

        door = GameObject.FindGameObjectWithTag("Door");
        doorAnimator = door.GetComponent<Animator>();

        cam = GameObject.FindGameObjectWithTag("MainCamera");

        distanceToLock = 71 - cam.transform.position.x;
        camStartX = cam.transform.position.x;


        this.enter.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
        textbox.text = "Nice job!";
        textNum = 0;
        timeButtonHit = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        //Code going through dialogue
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 0)
        {
            textbox.text = "Thanks for killing that monster.";
            textNum = 1;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 1 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "What just went inside you was fear.";
            textNum = 2;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 2 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "Don't worry, I'll buy it off of you!";
            textNum = 3;
            transitionCam = true;
            timeButtonHit = Time.time;

         
        }
        if (transitionCam)
        {
            if (Time.time - timeButtonHit < 1.5)
            {                                                                           //this number here equals to how many frames will be in the transition
                cam.transform.position = new Vector3(camStartX + (60 * ((distanceToLock / 90) * (Time.time - timeButtonHit))), cam.transform.position.y, -10);
            }
            if (Time.time - timeButtonHit >= 1.5)
            {
                cam.transform.position = new Vector3(71, cam.transform.position.y, -10);
            }
            if (Time.time - timeButtonHit > 2 && padlock != null)
            {
                lockAnimator.SetBool("enemyBeat", true);
            }

        }


        if (Input.GetKeyDown(KeyCode.Return) && textNum == 3 && Time.time - timeButtonHit > 3)
        {
            textbox.text = "Just jump into my shop over there";
            textNum = 4;
            timeButtonHit = Time.time;
            transitionCam = false;
            //doorCanOpen = true;
            door.GetComponent<doorOpeningScript>().enabled = false;
            doorAnimator.SetBool("doorCanOpen", true);
        }


        if (Input.GetKeyDown(KeyCode.Return) && textNum == 4 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "";
            door.GetComponent<doorOpeningScript>().enabled = true;
            transform.parent.gameObject.SetActive(false);
        }

        //"Press Enter" text code
        if (Time.time - timeButtonHit > 1)
        {
            if (Time.time - timeButtonHit < 2)
            {
                this.enter.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1 + (Time.time - timeButtonHit - 1));
            }
            else
            {
                this.enter.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, 0);
            }
        }
        else
        {
            this.enter.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1);
        }
    }
}
