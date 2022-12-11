using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    //Health
    private GameObject health;
    private SpriteRenderer healthSpriteRenderer;

    //6MaxHearts
    public Sprite m12h12Sprite;
    public Sprite m12h11Sprite;
    public Sprite m12h10Sprite;
    public Sprite m12h9Sprite;
    public Sprite m12h8Sprite;
    public Sprite m12h7Sprite;
    public Sprite m12h6Sprite;
    public Sprite m12h5Sprite;
    public Sprite m12h4Sprite;
    public Sprite m12h3Sprite;
    public Sprite m12h2Sprite;
    public Sprite m12h1Sprite;
    public Sprite m12h0Sprite;

    //5MaxHears
    public Sprite m10h10Sprite;
    public Sprite m10h9Sprite;
    public Sprite m10h8Sprite;
    public Sprite m10h7Sprite;
    public Sprite m10h6Sprite;
    public Sprite m10h5Sprite;
    public Sprite m10h4Sprite;
    public Sprite m10h3Sprite;
    public Sprite m10h2Sprite;
    public Sprite m10h1Sprite;
    public Sprite m10h0Sprite;

    //4MaxHears
    public Sprite m8h8Sprite;
    public Sprite m8h7Sprite;
    public Sprite m8h6Sprite;
    public Sprite m8h5Sprite;
    public Sprite m8h4Sprite;
    public Sprite m8h3Sprite;
    public Sprite m8h2Sprite;
    public Sprite m8h1Sprite;
    public Sprite m8h0Sprite;

    //3MaxHearts
    public Sprite m6h6Sprite;
    public Sprite m6h5Sprite;
    public Sprite m6h4Sprite;
    public Sprite m6h3Sprite;
    public Sprite m6h2Sprite;
    public Sprite m6h1Sprite;
    public Sprite m6h0Sprite;


    private GameObject nightmareHealth;

    //Mana
    private GameObject mana;
    private GameObject manaBar;
    private RectTransform manaBarTransform;

    //Fear
    private GameObject fearStat;
    private GameObject fearBar;
    private RectTransform fearBarTransform;
    public TextMeshProUGUI fearCtrNum;
    private GameObject fearCooldown;
    private Image fearCooldownImage;
    private Image fearCooldownCover;


    //Player Stats
    private GameObject player;
    private MovementScript playerScript;


    // Start is called before the first frame update
    void Start()
    {
        //Health
        health = transform.GetChild(0).gameObject;
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
        fearCooldown = transform.GetChild(4).gameObject;
        fearCooldownImage = fearCooldown.GetComponent<Image>();
        fearCooldownCover = fearCooldown.transform.GetChild(0).gameObject.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        //Health
        if (playerScript.getMaxHealth() == 6)
        {
            switch (playerScript.playerHealth)
            {
                case 0:
                    healthSpriteRenderer.sprite = m6h0Sprite;
                    break;
                case 1:
                    healthSpriteRenderer.sprite = m6h1Sprite;
                    break;
                case 2:
                    healthSpriteRenderer.sprite = m6h2Sprite;
                    break;
                case 3:
                    healthSpriteRenderer.sprite = m6h3Sprite;
                    break;
                case 4:
                    healthSpriteRenderer.sprite = m6h4Sprite;
                    break;
                case 5:
                    healthSpriteRenderer.sprite = m6h5Sprite;
                    break;
                case 6:
                    healthSpriteRenderer.sprite = m6h6Sprite;
                    break;
            }
        }
        else if (playerScript.getMaxHealth() == 8)
        {
            switch (playerScript.playerHealth)
            {
                case 0:
                    healthSpriteRenderer.sprite = m8h0Sprite;
                    break;
                case 1:
                    healthSpriteRenderer.sprite = m8h1Sprite;
                    break;
                case 2:
                    healthSpriteRenderer.sprite = m8h2Sprite;
                    break;
                case 3:
                    healthSpriteRenderer.sprite = m8h3Sprite;
                    break;
                case 4:
                    healthSpriteRenderer.sprite = m8h4Sprite;
                    break;
                case 5:
                    healthSpriteRenderer.sprite = m8h5Sprite;
                    break;
                case 6:
                    healthSpriteRenderer.sprite = m8h6Sprite;
                    break;
                case 7:
                    healthSpriteRenderer.sprite = m8h7Sprite;
                    break;
                case 8:
                    healthSpriteRenderer.sprite = m8h8Sprite;
                    break;
            }
        }
        else if (playerScript.getMaxHealth() == 10)
        {
            switch (playerScript.playerHealth)
            {
                case 0:
                    healthSpriteRenderer.sprite = m10h0Sprite;
                    break;
                case 1:
                    healthSpriteRenderer.sprite = m10h1Sprite;
                    break;
                case 2:
                    healthSpriteRenderer.sprite = m10h2Sprite;
                    break;
                case 3:
                    healthSpriteRenderer.sprite = m10h3Sprite;
                    break;
                case 4:
                    healthSpriteRenderer.sprite = m10h4Sprite;
                    break;
                case 5:
                    healthSpriteRenderer.sprite = m10h5Sprite;
                    break;
                case 6:
                    healthSpriteRenderer.sprite = m10h6Sprite;
                    break;
                case 7:
                    healthSpriteRenderer.sprite = m10h7Sprite;
                    break;
                case 8:
                    healthSpriteRenderer.sprite = m10h8Sprite;
                    break;
                case 9:
                    healthSpriteRenderer.sprite = m10h9Sprite;
                    break;
                case 10:
                    healthSpriteRenderer.sprite = m10h10Sprite;
                    break;
            }
        }
        else if (playerScript.getMaxHealth() == 12)
        {
            switch (playerScript.playerHealth)
            {
                case 0:
                    healthSpriteRenderer.sprite = m12h0Sprite;
                    break;
                case 1:
                    healthSpriteRenderer.sprite = m12h1Sprite;
                    break;
                case 2:
                    healthSpriteRenderer.sprite = m12h2Sprite;
                    break;
                case 3:
                    healthSpriteRenderer.sprite = m12h3Sprite;
                    break;
                case 4:
                    healthSpriteRenderer.sprite = m12h4Sprite;
                    break;
                case 5:
                    healthSpriteRenderer.sprite = m12h5Sprite;
                    break;
                case 6:
                    healthSpriteRenderer.sprite = m12h6Sprite;
                    break;
                case 7:
                    healthSpriteRenderer.sprite = m12h7Sprite;
                    break;
                case 8:
                    healthSpriteRenderer.sprite = m12h8Sprite;
                    break;
                case 9:
                    healthSpriteRenderer.sprite = m12h9Sprite;
                    break;
                case 10:
                    healthSpriteRenderer.sprite = m12h10Sprite;
                    break;
                case 11:
                    healthSpriteRenderer.sprite = m12h11Sprite;
                    break;
                case 12:
                    healthSpriteRenderer.sprite = m12h12Sprite;
                    break;
            }
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

        //FearBar
        if (playerScript.getFearBar() >= 0)
        {
            fearBarTransform.localScale = new Vector3(playerScript.getFearBar() / 14.7710487445f, 13, 1);
        }

        //FearCurrency
        fearCtrNum.text = "" + playerScript.getFear();

        fearCooldownCover.fillAmount = playerScript.getNightmareCooldown() * 0.04f;

        if (playerScript.nightmareReady())
        {
            fearCooldownImage.color = new Color(255, 255, 255);
        }
        else
        {
            fearCooldownImage.color = new Color(100, 100, 100);
        }
    }
}
