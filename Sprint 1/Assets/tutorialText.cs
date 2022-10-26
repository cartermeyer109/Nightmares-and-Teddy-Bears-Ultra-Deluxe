using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class tutorialText : MonoBehaviour
{
    GameObject hopScotch;
    Animator hopscotchAnimator;
    public Text textbox;
    public int textNum;
    public float timeButtonHit = 0f;

    // Start is called before the first frame update
    void Start()
    {
        textbox.text = "HEY YOU, DOWN THERE!!!";
        textNum = 0;
        timeButtonHit = Time.time;
        hopScotch = GameObject.FindGameObjectWithTag("Hopscotch");
        hopscotchAnimator = hopScotch.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        hopscotchAnimator.SetBool("textboxUp", true);
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 0) {
            textbox.text = "DO YOU THINK YOU CAN KILL THAT GUY!!!";
            textNum = 1;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 1 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "He's been hassling me all day, honestly";
            textNum = 2;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 2 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "Use J to attack!!!!!!";
            textNum = 3;
            timeButtonHit = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.Return) && textNum == 3 && Time.time - timeButtonHit > 1)
        {
            textbox.text = "";
            hopscotchAnimator.SetBool("textboxUp", false);
            transform.parent.gameObject.SetActive(false);
        }
    }
}
