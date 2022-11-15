using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFireBallScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    public float timer;

    Animator animator;

    MovementScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector2 direction = (player.transform.position + new Vector3(0,0.6f,0)) - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation - 50);

        playerScript = player.gameObject.GetComponent<MovementScript>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Imp"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playerScript.takeDamage();
            }
            //Debug.Log("Collision Detected with" + other.name);
            rb.velocity = new Vector3(0, 0, 0);
            animator.SetBool("Destroyed", true);

        }
    }
}
