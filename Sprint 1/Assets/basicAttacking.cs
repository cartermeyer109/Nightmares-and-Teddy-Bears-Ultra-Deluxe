using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicAttacking : MonoBehaviour
{
    private BoogeyManScript boogeyScript;
    private SpriteRenderer boogeyMan;

    // Start is called before the first frame update
    void Start()
    {
        boogeyScript = transform.GetComponentInParent<BoogeyManScript>();
        boogeyMan = transform.GetComponentInParent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Needle"))
        {
            boogeyScript.takeDamage();
            boogeyMan.color = new Color(255, 0, 0);
            Debug.Log("Damage boogeyspecialized");
        }
    }
}
