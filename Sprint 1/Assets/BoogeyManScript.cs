using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoogeyManScript : MonoBehaviour
{
    private GameObject player;
    private MovementScript playerScript;
    private Animator boogeyAnimator;
    private float attackTimer;
    private float attackTimerHelper;
    private bool canAttack;
    public float attackFreq;
    public float enemyHealth;
    private SpriteRenderer boogeyMan;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<MovementScript>();
        boogeyAnimator = GetComponent<Animator>();
        attackFreq = 5;
        enemyHealth = 5;
        boogeyMan = GetComponent<SpriteRenderer>();
        boogeyMan.color = new Color(255, 255, 255);
}

// Update is called once per frame
void Update()
    {
        Debug.Log("enemyHealth is " + enemyHealth);

        //Calculates x axis of player
        //1.7 is added because the protags and boogeymans x axis don't really line up for some reason
        if (player != null)
        {
            if (player.transform.position.x >= transform.position.x + 1.7f)
            {
                boogeyAnimator.SetBool("PlayerRight", true);
            }
            else
            {
                boogeyAnimator.SetBool("PlayerRight", false);
            }
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

        //Color Code
        if (boogeyMan.color.g != 255)
        {
            boogeyMan.color += new Color(0, 1, 0) * Time.deltaTime;
        }
        if (boogeyMan.color.b != 255)
        {
            boogeyMan.color += new Color(0, 0, 1) * Time.deltaTime;
        }
    }

    public void takeDamage()
    {
        if (enemyHealth > 0)
        {
            //hurtSound.Play();

            enemyHealth--;

            //enemyAnimator.SetBool("dmgTaken", true);
        }
        if (enemyHealth <= 0)
        {
            //dieSound.Play();
            boogeyAnimator.SetBool("HealthIsZero", true);
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
