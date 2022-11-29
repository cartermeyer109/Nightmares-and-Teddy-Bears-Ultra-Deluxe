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
    GameObject dialogue;
    GameObject shop;

    float fadeTime = 0.3f;
    //3.666666666 multiplier facedialate
    //Directly equals outline width
    public float fadeTimeCtr;
    public bool enteredRange = false;
    public bool readyToDecline = false;
    bool shopping = false;

    Animator protagAnimator;

    float playerX;


    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshPro>();
        text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
        text.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0f);
        hopscotch = GameObject.Find("HopScotchVender");
        player = GameObject.Find("protag");
        protagAnimator = player.GetComponent<Animator>();
        dialogue = GameObject.Find("TextboxHolder");
        shop = GameObject.Find("ShopHolder");

    }

    // Update is called once per frame
    void Update()
    {
        //Causes enter: talk text to face in and fade out
        //If player is in range of hopsctotch
        if (player.transform.position.x >= hopscotch.transform.position.x - 1.4 && player.transform.position.x <= hopscotch.transform.position.x + 1.4)
        {
            //Turn on the text in the textbox
            dialogue.transform.GetChild(0).gameObject.SetActive(true);

            //Mark that we are now in range of hopscotch
            enteredRange = true;

            //If enter is pressed
            if (Input.GetKeyDown(KeyCode.Return))
            {
                //Turn on instructions text
                dialogue.transform.GetChild(1).gameObject.SetActive(true);

                //turn on shop
                shop.transform.GetChild(0).gameObject.SetActive(true);

                playerX = player.transform.position.x;
                //Mark that we are now shopping
                shopping = true;
            }

            //If the shop is not on
            if (!shop.transform.GetChild(0).gameObject.activeSelf)
            {
                //Turn off the instructions
                dialogue.transform.GetChild(1).gameObject.SetActive(false);

                //Mark that we are not shopping
                shopping = false;
            }

        }
        //If you are not in range of hopscotch
        else
        {
            //Mark that you are not in the range
            enteredRange = false;
            //Turn off the text in the textbox
            dialogue.transform.GetChild(0).gameObject.SetActive(false);
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
        if (!shopping)
        {
            text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, (fadeTimeCtr * 3.66666666f) - 1);
            text.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, fadeTimeCtr);
            protagAnimator.SetBool("cutsceneIdle", false);

        } 
        //if you are shopping then the text will dissapear emediately
        else
        {
            text.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
            text.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, 0f);
            player.transform.position = new Vector3(playerX, player.transform.position.y, 0);
            protagAnimator.SetBool("cutsceneIdle", true);
        }

    }
}
