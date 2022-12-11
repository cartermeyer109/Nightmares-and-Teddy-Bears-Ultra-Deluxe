using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftAttackingScript : MonoBehaviour
{
    private BoogeyManScript boogeyScript;
    private Animator boogeyAnimator;
    private SpriteRenderer boogeyMan;

    private GameObject player;
    private MovementScript playerScript;


    // Start is called before the first frame update
    void Start()
    {
        boogeyScript = transform.GetComponentInParent<BoogeyManScript>();
        boogeyAnimator = transform.GetComponentInParent<Animator>();
        boogeyMan = transform.GetComponentInParent<SpriteRenderer>();

        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<MovementScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (boogeyAnimator.GetBool("leftAttacking"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                playerScript.takeDamage();
                Debug.Log("Damage player");
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Needle"))
            {
                boogeyScript.takeDamage();
                boogeyMan.color = new Color(255, 0, 0);
                Debug.Log("Damage boogeyspecialized");
            }
        }
    }
}
