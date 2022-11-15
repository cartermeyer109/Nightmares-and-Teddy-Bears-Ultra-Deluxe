using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StartTalkTextScript : MonoBehaviour
{
    TextMeshPro text;
    GameObject hopscotch;
    GameObject player;

    float fadeTime = 0.3f;
    //3.666666666 multiplier facedialate
    //Directly equals outline width
    public float fadeTimeCtr;
    public bool enteredRange = false;
    public bool readyToDecline = false;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshPro>();
        text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
        text.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0f);
        hopscotch = GameObject.Find("HopScotchVender");
        player = GameObject.Find("protag");

    }

    // Update is called once per frame
    void Update()
    {
        //If in range
        if (player.transform.position.x >= hopscotch.transform.position.x - 1.4 && player.transform.position.x <= hopscotch.transform.position.x + 1.4)
        {
            enteredRange = true;
            //fadeTimeCtr = 0;
        }
        else
        {
            enteredRange = false;
        }

        if (enteredRange && !readyToDecline)
        {
            if (fadeTimeCtr <= fadeTime)
            {
                fadeTimeCtr += Time.deltaTime;
            }

            if (fadeTimeCtr >= fadeTime)
            {
                readyToDecline = true;
            }
        }
        if (!enteredRange && readyToDecline)
        {
            if (fadeTimeCtr >= 0)
            {
                fadeTimeCtr -= Time.deltaTime;
            }
            if (fadeTimeCtr <= 0)
            {
                readyToDecline = false;
            }
        }

        text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, (fadeTimeCtr * 3.66666666f) - 1);
        text.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, fadeTimeCtr);

    }
}
