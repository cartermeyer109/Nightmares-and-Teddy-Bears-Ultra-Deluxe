using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cuddlesworth_movement : MonoBehaviour
{
    Vector3 moveRight, moveLeft;
    Vector2 jumpForce;
    Rigidbody2D myPhysics;

    float fallForce;
    float speed;
    bool canJump;
    bool facingRight;

    Animator protagAnimator;
    public GameObject theProjectileHolder;
    private GameObject currentProjectile;
    public Transform spawnSpot;

    void Start()
    {
        Debug.Log("Starting...");

        canJump = false;
        facingRight = true;

        moveRight = new Vector3(1, 0, 0);
        moveLeft = new Vector3(-1, 0, 0);

        myPhysics = GetComponent<Rigidbody2D>();
        protagAnimator = GetComponent<Animator>();

        speed = 2.5f;
        fallForce = 0f;
        jumpForce = new Vector2(0, 22);
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.D) /*|| Input.GetKey(KeyCode.RightArrow)*/) ^ (Input.GetKey(KeyCode.A) /*|| Input.GetKey(KeyCode.LeftArrow)*/))
        {
            if (Input.GetKey(KeyCode.D) /*|| Input.GetKey(KeyCode.RightArrow)*/)
            {
                fallForce = myPhysics.velocity.y;
                myPhysics.velocity = new Vector2(speed, fallForce);
                facingRight = true;
            }
            if (Input.GetKey(KeyCode.A) /*|| Input.GetKey(KeyCode.LeftArrow)*/)
            {
                fallForce = myPhysics.velocity.y;
                myPhysics.velocity = new Vector2(-1 * speed, fallForce);
                facingRight = false;
            }
        }
        if ((Input.GetKey(KeyCode.W) /*|| Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)*/) && canJump)
        {
            myPhysics.AddForce(jumpForce, ForceMode2D.Impulse);
            //if (myPhysics.velocity.y < 10)
            //{
            //    myPhysics.AddForce(jumpForce, ForceMode2D.Impulse);
            //}
            canJump = false;
        }
        if (Input.GetKey(KeyCode.J))
        {
            Debug.Log("Attack");
            protagAnimator.Play("protag_attack_anim");
        }
        if (Input.GetKey(KeyCode.K))
        {
            //do stuff
        }
        if (Input.GetKey(KeyCode.L))
        {

        }
        if (facingRight)
        {

        }
        else
        {

        }
    }

    public void OnCollisionEnter2D(Collision2D thingProtagHit)
    {
        if (thingProtagHit.gameObject.CompareTag("ground")) //TODO: also check that you are colliding with the TOP of the ground tile...
        {
            Debug.Log("Cuddlesworth ran into " + thingProtagHit.gameObject.name);
            canJump = true;
        }
        //ALSO TODO: make canJump false if protag is not touching anything!
    }
}