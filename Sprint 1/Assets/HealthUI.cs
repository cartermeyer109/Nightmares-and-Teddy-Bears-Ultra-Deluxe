using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite h6Sprite;
    public Sprite h5Sprite;
    public Sprite h4Sprite;
    public Sprite h3Sprite;
    public Sprite h2Sprite;
    public Sprite h1Sprite;
    public Sprite h0Sprite;

    public GameObject player;
    public MovementScript playerScript;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<MovementScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.playerHealth == 6)
        {
            spriteRenderer.sprite = h6Sprite;
        }
        if (playerScript.playerHealth == 5)
        {
            spriteRenderer.sprite = h5Sprite;
        }
        if (playerScript.playerHealth == 4)
        {
            spriteRenderer.sprite = h4Sprite;
        }
        if (playerScript.playerHealth == 3)
        {
            spriteRenderer.sprite = h3Sprite;
        }
        if (playerScript.playerHealth == 2)
        {
            spriteRenderer.sprite = h2Sprite;
        }
        if (playerScript.playerHealth == 1)
        {
            spriteRenderer.sprite = h1Sprite;
        }
        if (playerScript.playerHealth == 0)
        {
            spriteRenderer.sprite = h0Sprite;
        }
    }
}
