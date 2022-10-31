using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class thankYouText : MonoBehaviour
{
    public Text textbox;
    public TextMeshProUGUI enter;
    public int textNum;
    public float timeButtonHit = 0f;

    // Start is called before the first frame update
    void Start()
    {
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
            textbox.text = "Thank you for killing that monster.";
            textNum = 1;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 1 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "My shop is now open to you";
            textNum = 2;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 2 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "Jump down into the burrow to your right";
            textNum = 3;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 3 && Time.time - timeButtonHit > 1)
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
