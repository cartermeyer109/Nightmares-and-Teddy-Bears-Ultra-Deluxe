using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossText : MonoBehaviour
{
    public Text textbox;
    public TextMeshProUGUI enter;
    public int textNum;
    public float timeButtonHit = 0f;

    public RectTransform textTransformer;

    // Start is called before the first frame update
    void Start()
    {
        textTransformer = transform.parent.gameObject.GetComponent<RectTransform>();
        this.enter.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
        textbox.text = "So, you’ve made it to the end. I’m impressed.";
        textNum = 0;
        timeButtonHit = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        //Code going through dialogue
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 0)
        {
            textbox.text = "You remind me a lot of - ";
            textNum = 1;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 1 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "the last dream guardian to make it here.";
            textNum = 2;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 2 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "He was bold and courageous, like you.";
            textNum = 3;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 3 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "Nearly killed the Boogyman, but ultimately met his demise.";
            textNum = 4;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 4 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "The Boogyman became weak after their fight.";
            textNum = 5;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 5 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "Had to posses the guardians dead corpse";
            textNum = 6;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 6 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "just to keep a physical form.";
            textNum = 7;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 7 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "But thanks to you and all the fear you gave me…";
            textNum = 8;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 8 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "I’ve become strong again.";
            textNum = 9;
            timeButtonHit = Time.time;
        }




        if (Input.GetKeyDown(KeyCode.Return) && textNum == 9 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "";
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