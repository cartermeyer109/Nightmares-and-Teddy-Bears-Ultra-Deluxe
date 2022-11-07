using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class doorOpeningScript : MonoBehaviour
{
    GameObject player;
    Animator animator;
    GameObject padlock;
    GameObject thankYouText;


    // Start is called before the first frame update
    void Start()
    {
        thankYouText = GameObject.FindGameObjectWithTag("Thank You");
        player = GameObject.FindGameObjectWithTag("Player");
        animator = this.gameObject.GetComponent<Animator>();
        padlock = GameObject.FindGameObjectWithTag("Lock");
    }

    // Update is called once per frame
    void Update()
    {
        if (padlock == null && thankYouText == null)
        {
            if (player.transform.position.x >= this.transform.position.x - 5.5 && player.transform.position.x <= this.transform.position.x + 5.5)
            {
                animator.SetBool("doorCanOpen", true);
            }
            else
            {
                animator.SetBool("doorCanOpen", false);
            }
        }
    }
}
