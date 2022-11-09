using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class tutorialText : MonoBehaviour
{
    public Text textbox;
    public TextMeshProUGUI enter;
    public int textNum;
    public float timeButtonHit = 0f;

    public RectTransform textTransformer;

    public GameObject player;
    public Animator protagAnim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        protagAnim = player.GetComponent<Animator>();

        textTransformer = transform.parent.gameObject.GetComponent<RectTransform>();
        this.enter.fontMaterial.SetFloat(ShaderUtilities.ID_FaceDilate, -1f);
        textbox.text = "HEY YOU, DOWN THERE!!!";
        textNum = 0;
        timeButtonHit = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        //Code going through dialogue
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 0) {
            textbox.text = "DO YOU THINK YOU CAN KILL THAT GUY!?";
            textNum = 1;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 1 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "He's been hassling me all day, honestly.";
            textNum = 2;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 2 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "Take this needle!!!!!!";
            textNum = 3;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 3 && Time.time - timeButtonHit > 1)
        {
            protagAnim.SetBool("NeedleObtained", true);
            textTransformer.anchoredPosition = new Vector3(-61.00611f, -1080, -18936.94f);
            textbox.text = "You have obtained a Needle";
            textNum = 4;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 4 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "Use J to Attack";
            textNum = 5;
            timeButtonHit = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.Return) && textNum == 5 && Time.time - timeButtonHit > 1)
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
