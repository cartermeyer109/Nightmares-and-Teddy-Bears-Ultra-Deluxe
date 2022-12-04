using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    //Health
    private GameObject health;
    private SpriteRenderer healthSpriteRenderer;
    public Sprite h12Sprite;
    public Sprite h11Sprite;
    public Sprite h10Sprite;
    public Sprite h9Sprite;
    public Sprite h8Sprite;
    public Sprite h7Sprite;
    public Sprite h6Sprite;
    public Sprite h5Sprite;
    public Sprite h4Sprite;
    public Sprite h3Sprite;
    public Sprite h2Sprite;
    public Sprite h1Sprite;
    public Sprite h0Sprite;
    private GameObject nightmareHealth;

    //Mana
    private GameObject mana;
    private GameObject manaBar;
    private RectTransform manaBarTransform;

    //Fear
    private GameObject fearStat;
    private GameObject fearBar;
    private RectTransform fearBarTransform;


    //Player Stats
    private GameObject player;
    private MovementScript playerScript;


    // Start is called before the first frame update
    void Start()
    {
        //Health
        health = GameObject.Find("Health");
        healthSpriteRenderer = health.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<MovementScript>();
        nightmareHealth = health.transform.GetChild(0).gameObject;

        //Mana
        mana = GameObject.Find("Mana");
        manaBar = mana.transform.GetChild(0).gameObject;
        manaBarTransform = manaBar.GetComponent<RectTransform>();

        //Fear
        fearStat = GameObject.Find("FearStat");
        fearBar = fearStat.transform.GetChild(0).gameObject;
        fearBarTransform = fearBar.GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        //Health
        switch (playerScript.playerHealth)
        {
            case 0:
                healthSpriteRenderer.sprite = h0Sprite;
                break;
            case 1:
                healthSpriteRenderer.sprite = h1Sprite;
                break;
            case 2:
                healthSpriteRenderer.sprite = h2Sprite;
                break;
            case 3:
                healthSpriteRenderer.sprite = h3Sprite;
                break;
            case 4:
                healthSpriteRenderer.sprite = h4Sprite;
                break;
            case 5:
                healthSpriteRenderer.sprite = h5Sprite;
                break;
            case 6:
                healthSpriteRenderer.sprite = h6Sprite;
                break;
            case 7:
                healthSpriteRenderer.sprite = h7Sprite;
                break;
            case 8:
                healthSpriteRenderer.sprite = h8Sprite;
                break;
            case 9:
                healthSpriteRenderer.sprite = h9Sprite;
                break;
            case 10:
                healthSpriteRenderer.sprite = h10Sprite;
                break;
            case 11:
                healthSpriteRenderer.sprite = h11Sprite;
                break;
            case 12:
                healthSpriteRenderer.sprite = h12Sprite;
                break;

        }

        if (playerScript.getNightmare())
        {
            nightmareHealth.SetActive(true);
        }
        else
        {
            nightmareHealth.SetActive(false);
        }

        //Mana
        manaBarTransform.localScale = new Vector3(playerScript.getCourage() * 0.336f, 9.62f, 1);
        fearBarTransform.localScale = new Vector3(playerScript.getFearBar() / 14.7710487445f, 13, 1);
    }
}
