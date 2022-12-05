using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class leaveScript : MonoBehaviour
{
    TextMeshPro text;
    GameObject hopscotch;
    GameObject player;

    float fadeTime = 0.3f;
    public float fadeTimeCtr;
    public bool enteredRange = false;
    public bool readyToDecline = false;

    Animator protagAnimator;

    float playerX;


    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshPro>();
        text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
        text.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0f);
        hopscotch = GameObject.Find("rope");
        player = GameObject.Find("protag");
        protagAnimator = player.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Causes enter: talk text to face in and fade out
        //If player is in range of hopsctotch
        if (player.transform.position.x >= hopscotch.transform.position.x - 1.4 && player.transform.position.x <= hopscotch.transform.position.x + 1.4)
        {
            //Mark that we are now in range of hopscotch
            enteredRange = true;
        }
        //If you are not in range of hopscotch
        else
        {
            //Mark that you are not in the range
            enteredRange = false;
        }
        //If you are in range and the text is not visible
        if (enteredRange)
        {
            //makes the text slowly appear
            if (fadeTimeCtr <= fadeTime)
            {
                fadeTimeCtr += Time.deltaTime;
            }
        }
        //If you are out of range and the text fully apparent
        if (!enteredRange)
        {
            //Makes the text slowly dissapear
            if (fadeTimeCtr >= 0)
            {
                fadeTimeCtr -= Time.deltaTime;
            }
        }
        //If you are not shopping, this will adjust the texts appearance
            text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, (fadeTimeCtr * 3.66666666f) - 1);
            text.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, fadeTimeCtr);
            protagAnimator.SetBool("cutsceneIdle", false);
    }
}
