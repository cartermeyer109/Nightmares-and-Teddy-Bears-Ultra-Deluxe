using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoogeyManScript : MonoBehaviour
{
    private GameObject player;
    private Animator boogeyAnimator;
    private float attackTimer;
    private float attackTimerHelper;
    private bool canAttack;
    public float attackFreq;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boogeyAnimator = GetComponent<Animator>();
        attackFreq = 5;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculates x axis of player
        //1.7 is added because the protags and boogeymans x axis don't really line up for some reason
        if (player.transform.position.x >= transform.position.x + 1.7f)
        {
            boogeyAnimator.SetBool("PlayerRight", true);
        }
        else
        {
            boogeyAnimator.SetBool("PlayerRight", false);
        }
        

        //Calulates attack time and if a swipe will happen
        attackTimer += Time.deltaTime;
        attackTimerHelper += Time.deltaTime;
        if (Mathf.RoundToInt(attackTimer) % attackFreq == 0 && canAttack)
        {
            swipeDecider();
            boogeyAnimator.SetBool("Attack", true);
            attackTimerHelper = 0;
            canAttack = false;

        }
        if (Mathf.RoundToInt(attackTimerHelper) == 2)
        {
            canAttack = true;
        }
    }

    private int swipeDecider()
    {
        int rand = Random.Range(0, 4);
        Debug.Log("Rand is " + rand);

        if (rand == 0)
        {
            boogeyAnimator.SetBool("SwipeEnabled", true);
            return 1;
        }
        boogeyAnimator.SetBool("SwipeEnabled", false);
        return 0;
    }
}
