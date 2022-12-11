//Carter Meyer

//TODO add some text to display when all the items are taken,
//Also test that nothing breaks when all items are sold
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class shopManagerScript : MonoBehaviour
{
    //Text Assets initialized in unity not in script
    public TextMeshProUGUI heartPriceText;
    public Text textbox;

    //All of the shopitems
    ShopItems heartItem;
    ShopItems dashItem;
    ShopItems needleItem;
    ShopItems sandNeedleItem;
    ShopItems shadowNeedleItem;
    ShopItems projAttackItem;
    ShopItems gpAttackItem;
    ShopItems waveItem;
    ShopItems healItem;

    //Variables for the shopitems objects array
    int maxItems = 9; ////Change this number with whatever the max size could be (Right now we only have 4 items made)
    ShopItems[] Items = new ShopItems[9]; //change this too
    int itemsSize = 0;

    //the text of the items to be put on the list (made for ease of putting it into the shopitem object
    GameObject heart;
    GameObject needle;
    GameObject projAttack;
    GameObject gpAttack;
    GameObject dash;
    GameObject shadowNeedle;
    GameObject sandNeedle;
    GameObject heal;
    GameObject wave;

    //PREVIEWS
    GameObject heartPrev;
    GameObject needlePrev;
    GameObject projAttackPrev;
    GameObject gpAttackPrev;
    GameObject dashPrev;
    GameObject shadowNeedlePrev;
    GameObject sandNeedlePrev;
    GameObject healPrev;
    GameObject wavePrev;

    //Player and its stats
    GameObject player;
    MovementScript playerStats;

    //GameObject itemHighlighter;
    GameObject itemHighlighter;
    RectTransform itemHighlighterTF;
    Vector3 highlightSpot;

    //The buy text highlighter
    GameObject buyTextHighlighter;

    //Tracks what part of the menu we are on
    int menuProgress = 0;

    //selector highlighter
    int slotSelected = 0;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("protag");
        playerStats = player.GetComponent<MovementScript>();

        //Herat item
        heart = GameObject.Find("Content").transform.GetChild(0).gameObject;
        heartPrev = GameObject.Find("ItemPrevs").transform.GetChild(0).gameObject;
        heartItem = new ShopItems(heart, heart.GetComponent<RectTransform>(), heartPrev, ((playerStats.getMaxHealth() - 4) * 100), 0);

        //Needle Item
        needle = GameObject.Find("Content").transform.GetChild(1).gameObject;
        needlePrev = GameObject.Find("ItemPrevs").transform.GetChild(1).gameObject;
        needleItem = new ShopItems(needle, needle.GetComponent<RectTransform>(), needlePrev, 500, 1);

        //Projectile Attack Item
        projAttack = GameObject.Find("Content").transform.GetChild(2).gameObject;
        projAttackPrev = GameObject.Find("ItemPrevs").transform.GetChild(2).gameObject;
        projAttackItem = new ShopItems(projAttack, projAttack.GetComponent<RectTransform>(), projAttackPrev, 200, 2);

        //Gp Attack Item
        gpAttack = GameObject.Find("Content").transform.GetChild(3).gameObject;
        gpAttackPrev = GameObject.Find("ItemPrevs").transform.GetChild(3).gameObject;
        gpAttackItem = new ShopItems(gpAttack, gpAttack.GetComponent<RectTransform>(), gpAttackPrev, 200, 3);

        //Dash Item
        dash = GameObject.Find("Content").transform.GetChild(4).gameObject;
        dashPrev = GameObject.Find("ItemPrevs").transform.GetChild(4).gameObject;
        dashItem = new ShopItems(dash, dash.GetComponent<RectTransform>(), dashPrev, 200, 4);

        //Shadow Needle Item
        shadowNeedle = GameObject.Find("Content").transform.GetChild(5).gameObject;
        shadowNeedlePrev = GameObject.Find("ItemPrevs").transform.GetChild(5).gameObject;
        shadowNeedleItem = new ShopItems(shadowNeedle, shadowNeedle.GetComponent<RectTransform>(), shadowNeedlePrev, 200, 5);

        //Sand Needle Item
        sandNeedle = GameObject.Find("Content").transform.GetChild(6).gameObject;
        sandNeedlePrev = GameObject.Find("ItemPrevs").transform.GetChild(6).gameObject;
        sandNeedleItem = new ShopItems(sandNeedle, sandNeedle.GetComponent<RectTransform>(), sandNeedlePrev, 200, 6);
       
        //Heal Item
        heal = GameObject.Find("Content").transform.GetChild(7).gameObject;
        healPrev = GameObject.Find("ItemPrevs").transform.GetChild(7).gameObject;
        healItem = new ShopItems(heal, heal.GetComponent<RectTransform>(), healPrev, 200, 7);

        //Wave Item
        wave = GameObject.Find("Content").transform.GetChild(8).gameObject;
        wavePrev = GameObject.Find("ItemPrevs").transform.GetChild(8).gameObject;
        waveItem = new ShopItems(wave, wave.GetComponent<RectTransform>(), wavePrev, 200, 8);


        itemHighlighter = transform.GetChild(4).gameObject;
        itemHighlighterTF = itemHighlighter.GetComponent<RectTransform>();
        highlightSpot = new Vector3(-45.52f, 23f, 0);
        buyTextHighlighter = transform.GetChild(3).gameObject;

        readPlayerStats();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("MenuProgress is " + menuProgress);
        Debug.Log("Fear is " + playerStats.getFear());
        Debug.Log("Slot Selected is " + slotSelected);
        Debug.Log("Hearts Price is " + Items[0].getItemPrice());

        //Constantly updates heartprice cost text
        heartPriceText.SetText("Cost:    " + heartItem.getItemPrice());

        //Constantly updates higlighter to be in the correct spot
        itemHighlighterTF.anchoredPosition = highlightSpot;

        //Constantly updated the locations of the item name visuals in case items get removed
        for (int i = 0; i < itemsSize; i++)
        {
            Items[i].PlaceItem(i);
        }

        //Goes through each item, only having the preview of the one selected shown
        for (int k = 0; k < itemsSize; k++)
        {
            if (slotSelected == k)
            {
                Items[k].setItemPrev(true);
            }
            else
            {
                Items[k].setItemPrev(false);
            }
        }

        //Allows changing of item selectoin if you are in the base shop
        if (menuProgress == 0)
        {
            if (slotSelected > 0 && Input.GetKeyDown(KeyCode.W))
            {
                slotSelected--;
                highlightSpot += new Vector3(0, 8.13f, 0);
            }

            if (slotSelected < itemsSize - 1 && Input.GetKeyDown(KeyCode.S))
            {
                slotSelected++;
                highlightSpot += new Vector3(0, -8.13f, 0);
            }
        }

        //Does not let the menu progress go out of bounds
        if (Input.GetKeyDown(KeyCode.Return) && menuProgress < 2)
        {
            menuProgress++;
        }
        if (Input.GetKeyDown(KeyCode.Backspace) && menuProgress >= 0)
        {
            menuProgress--;
        }

        //if you select an item, then make the buy highlighter turn on, and the item selector highlighter turn off
        //The item selector highlighter doens't neccessarily need to turn off if we dont want it to
        if (menuProgress > 0)
        {
            buyTextHighlighter.SetActive(true);
            itemHighlighter.SetActive(false);
        }
        else
        {
            buyTextHighlighter.SetActive(false);
            itemHighlighter.SetActive(true);
        }

        //If the menu ever drops below 0 (such as -1), turn off the meny after doing some final stuff
        if (menuProgress < 0)
        {
            menuProgress = 0;
            textbox.text = "BUY MORE STUFF!!!";
            gameObject.SetActive(false);
        }

        //If you have attempted to purchase an item
        if (menuProgress ==2)
        {
            //purchasing
            if (playerStats.getFear() >= Items[slotSelected].getItemPrice())
            {
                playerStats.setFear(playerStats.getFear() - Items[slotSelected].getItemPrice());
                //PUT SWITCH CASE HERE WITH NEW ITEMS EVERYTIME WE ADD ONE
                switch (Items[slotSelected].getItemCode())
                {
                    case 0:
                        playerStats.setMaxHealth(playerStats.getMaxHealth() + 2);
                        Items[slotSelected].setItemPrice((playerStats.getMaxHealth() - 4) * 100);
                        if (playerStats.getMaxHealth() == 12)
                        {
                            removeItem(slotSelected);
                        }
                        break;
                    case 1:
                        playerStats.setGoldenNeedle(true);
                        removeItem(slotSelected);
                        break;
                    case 2:
                        playerStats.setProjAttack(true);
                        removeItem(slotSelected);
                        break;
                    case 3:
                        playerStats.setGPAttack(true);
                        removeItem(slotSelected);
                        break;
                    case 4:
                        playerStats.setDash(true);
                        removeItem(slotSelected);
                        break;
                    case 5:
                        playerStats.setShadowNeedle(true);
                        removeItem(slotSelected);
                        break;
                    case 6:
                        playerStats.setSandNeedle(true);
                        removeItem(slotSelected);
                        break;
                    case 7:
                        playerStats.setHealer(true);
                        removeItem(slotSelected);
                        break;
                    case 8:
                        playerStats.setWave(true);
                        removeItem(slotSelected);
                        break;
                }

                menuProgress = 0;

                if (slotSelected >= itemsSize)
                {
                    slotSelected--;
                    highlightSpot += new Vector3(0, 8.13f, 0);
                }
                textbox.text = "Nice purchase";
            }
            else
            {
                textbox.text = "Not enough fear!";
                menuProgress = 0;
            }
        }

        if (itemsSize <= 0)
        {
            textbox.text = "All out of items!";
            menuProgress = -1;
        }
    }
    void removeItem(int i)
    {
        //This works directly with the array declared in start
        Items[i].Deactivate();
        for (int j = i; j < itemsSize - 1; j++)
        {
            Items[j] = Items[j + 1];
        }
        Items[itemsSize - 1] = null;
        itemsSize--;
    }

    void readPlayerStats()
    {
        //Individually goes through each stat to see if it should be included in the shop/array 
        //I didn't know a better way to do this because you have to check each player stat individually.
        if (playerStats.getMaxHealth() == 12)
        {
            heartItem.Deactivate();
        }
        else
        {
            Items[itemsSize] = heartItem;
            itemsSize++;
        }

        if (playerStats.getDash())
        {
            dashItem.Deactivate();
        }
        else
        {
            Items[itemsSize] = dashItem;
            itemsSize++;
        }

        if (playerStats.getGoldenNeedle())
        {
            needleItem.Deactivate();
        }
        else
        {
            Items[itemsSize] = needleItem;
            itemsSize++;
        }

        if (playerStats.getShadowNeedle())
        {
            shadowNeedleItem.Deactivate();
        }
        else
        {
            Items[itemsSize] = shadowNeedleItem;
            itemsSize++;
        }

        if (playerStats.getSandNeedle())
        {
            sandNeedleItem.Deactivate();
        }
        else
        {
            Items[itemsSize] = sandNeedleItem;
            itemsSize++;
        }

        if (playerStats.getProjAttack())
        {
            projAttackItem.Deactivate();
        }
        else
        {
            Items[itemsSize] = projAttackItem;
            itemsSize++;
        }

        if (playerStats.getWave())
        {
            waveItem.Deactivate();
        }
        else
        {
            Items[itemsSize] = waveItem;
            itemsSize++;
        }

        if (playerStats.getGPAttack())
        {
            gpAttackItem.Deactivate();
        }
        else
        {
            Items[itemsSize] = gpAttackItem;
            itemsSize++;
        }

        if (playerStats.getHealer())
        {
            healItem.Deactivate();
        }
        else
        {
            Items[itemsSize] = healItem;
            itemsSize++;
        }

    }
}