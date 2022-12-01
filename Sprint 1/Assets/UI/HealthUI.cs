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
        switch (playerScript.playerHealth)
        {
            case 0:
                spriteRenderer.sprite = h0Sprite;
                break;
            case 1:
                spriteRenderer.sprite = h1Sprite;
                break;
            case 2:
                spriteRenderer.sprite = h2Sprite;
                break;
            case 3:
                spriteRenderer.sprite = h3Sprite;
                break;
            case 4:
                spriteRenderer.sprite = h4Sprite;
                break;
            case 5:
                spriteRenderer.sprite = h5Sprite;
                break;
            case 6:
                spriteRenderer.sprite = h6Sprite;
                break;
        }
    }
}
