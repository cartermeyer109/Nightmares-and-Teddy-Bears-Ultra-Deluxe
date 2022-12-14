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

    GameObject equipText;

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

        equipText = GameObject.Find("BuyText").transform.GetChild(0).gameObject;

        readPlayerStats();
    }

    // Update is called once per frame
    void Update()
    {

        update();

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

        if (Items[slotSelected].getItemCode() != 0 && Items[slotSelected].getItemCode() != 1 && Items[slotSelected].getItemPurchased())
        {
            equipText.SetActive(true);
        }
        else
        {
            equipText.SetActive(false);
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

        //If the menu ever drops below 0 (such as -1), turn off the menu after doing some final stuff
        if (menuProgress < 0)
        {
            menuProgress = 0;
            textbox.text = "BUY MORE STUFF!!!";
            gameObject.SetActive(false);
        }

        //If you have attempted to purchase an item
        if (menuProgress ==2)
        {
            //Equipping
            if (Items[slotSelected].getItemPurchased())
            {
                //Switch case. if the playerstat is greater than 0 then it will move stuff around
                //Equipping text
                switch (Items[slotSelected].getItemCode())
                {
                    case 1:
                        if (Items[1].getItemPurchased())
                        {
                            textbox.text = "Already equipped!";
                            menuProgress = 0;
                        }
                        break;

                    case 2:
                        if (playerStats.getProjAttack() == 0)
                        {
                            for (int i = 0; i < itemsSize; i++)
                            {
                                if (i != 0 || i != 1 || i != 5 || i != 6)
                                {
                                    if (Items[slotSelected].getEquipped() == 2)
                                    {
                                        Items[slotSelected].setEquipped(0);

                                    }
                                    if (Items[slotSelected].getEquipped() == 1)
                                    {
                                        Items[slotSelected].setEquipped(2);
                                    }
                                }
                            }
                            playerStats.setProjAttack(1);
                            Items[slotSelected].setEquipped(1);

                        }
                        else if (playerStats.getProjAttack() > 0)
                        {
                            textbox.text = "Already equipped!";
                            menuProgress = 0;
                        }
                        break;

                    case 3:
                        if (playerStats.getGPAttack() == 0)
                        {

                            for (int i = 0; i < itemsSize; i++)
                            {
                                if (i != 0 || i != 1 || i != 5 || i != 6)
                                {
                                    if (Items[slotSelected].getEquipped() == 2)
                                    {
                                        Items[slotSelected].setEquipped(0);
                                    }
                                    if (Items[slotSelected].getEquipped() == 1)
                                    {
                                        Items[slotSelected].setEquipped(2);
                                    }
                                }
                            }
                            playerStats.setGPAttack(1);
                            Items[slotSelected].setEquipped(1);

                        }
                        else if (playerStats.getGPAttack() > 0)
                        {
                            textbox.text = "Already equipped!";
                            menuProgress = 0;
                        }
                        break;

                    case 4:
                        if (playerStats.getDash() == 0)
                        {
                            for (int i = 0; i < itemsSize; i++)
                            {
                                if (i != 0 || i != 1 || i != 5 || i != 6)
                                {
                                    if (Items[slotSelected].getEquipped() == 2)
                                    {
                                        Items[slotSelected].setEquipped(0);
                                    }
                                    if (Items[slotSelected].getEquipped() == 1)
                                    {
                                        Items[slotSelected].setEquipped(2);
                                    }
                                }
                            }
                            playerStats.setDash(1);
                            Items[slotSelected].setEquipped(1);
                        }
                        else if (playerStats.getDash() > 0)
                        {
                            textbox.text = "Already equipped!";
                            menuProgress = 0;
                        }
                        break;

                    case 5:
                        if (playerStats.getShadowNeedle() == 0)
                        {
                            if (Items[6].getEquipped() == 1)
                            {
                                Items[6].setEquipped(0);
                            }

                            playerStats.setShadowNeedle(1);
                            Items[slotSelected].setEquipped(1);
                        }
                        else if (playerStats.getShadowNeedle() > 0)
                        {
                            textbox.text = "Already equipped!";
                            menuProgress = 0;
                        }
                        break;

                    case 6:
                        if (playerStats.getSandNeedle() == 0)
                        {

                            if (Items[5].getEquipped() == 1)
                            {
                                Items[5].setEquipped(0);
                            }
                            playerStats.setSandNeedle(1);
                            Items[slotSelected].setEquipped(1);
                        }
                        else if (playerStats.getSandNeedle() > 0)
                        {
                            textbox.text = "Already equipped!";
                            menuProgress = 0;
                        }
                        break;

                    case 7:
                        if (playerStats.getHealer() == 0)
                        {

                            for (int i = 0; i < itemsSize; i++)
                            {
                                if (i != 0 || i != 1 || i != 5 || i != 6)
                                {
                                    if (Items[slotSelected].getEquipped() == 2)
                                    {
                                        Items[slotSelected].setEquipped(0);
                                    }
                                    if (Items[slotSelected].getEquipped() == 1)
                                    {
                                        Items[slotSelected].setEquipped(2);
                                    }
                                }
                            }
                            playerStats.setHealer(1);
                            Items[slotSelected].setEquipped(1);
                        }
                        else if (playerStats.getHealer() > 0)
                        {
                            textbox.text = "Already equipped!";
                            menuProgress = 0;
                        }
                        break;


                    case 8:
                        if (playerStats.getWave() == 0)
                        { 

                            for (int i = 0; i < itemsSize; i++)
                            {
                                if (i != 0 || i != 1 || i != 5 || i != 6)
                                {
                                    if (Items[slotSelected].getEquipped() == 2)
                                    {
                                        Items[slotSelected].setEquipped(0);
                                    }
                                    if (Items[slotSelected].getEquipped() == 1)
                                    {
                                        Items[slotSelected].setEquipped(2);
                                    }
                                }
                            }
                            playerStats.setWave(1);
                            Items[slotSelected].setEquipped(1);

                        }
                        else if (playerStats.getWave() > 0)
                        {
                            textbox.text = "Already equipped!";
                            menuProgress = 0;
                        }
                        break;
                }
            }
            //purchasing
            else if (playerStats.getFear() >= Items[slotSelected].getItemPrice())
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
                            purchaseItem(slotSelected);
                        }
                        break;
                    case 1:
                        playerStats.setGoldenNeedle(1);
                        Items[slotSelected].setEquipped(1);
                        purchaseItem(slotSelected);
                        break;
                    case 2:
                        playerStats.setProjAttack(0);
                        projAttackItem.setEquipped(0);
                        purchaseItem(slotSelected);
                        break;
                    case 3:
                        playerStats.setGPAttack(0);
                        gpAttackItem.setEquipped(0);
                        purchaseItem(slotSelected);
                        break;
                    case 4:
                        playerStats.setDash(0);
                        dashItem.setEquipped(0);
                        purchaseItem(slotSelected);
                        break;
                    case 5:
                        playerStats.setShadowNeedle(0);
                        shadowNeedleItem.setEquipped(0);
                        purchaseItem(slotSelected);
                        break;
                    case 6:
                        playerStats.setSandNeedle(0);
                        sandNeedleItem.setEquipped(0);
                        purchaseItem(slotSelected);
                        break;
                    case 7:
                        playerStats.setHealer(0);
                        healItem.setEquipped(0);
                        purchaseItem(slotSelected);
                        break;
                    case 8:
                        playerStats.setWave(0);
                        waveItem.setEquipped(0);
                        purchaseItem(slotSelected);
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
    void purchaseItem(int i)
    {
        Items[i].setItemPurchased(true);
        Items[i].getItem().gameObject.transform.GetChild(0).gameObject.SetActive(true);

    }

    void readPlayerStats()
    {
        //Individually goes through each stat to see if it should be included in the shop/array 
        //I didn't know a better way to do this because you have to check each player stat individually.
        if (playerStats.getMaxHealth() == 12)
        {
            heartItem.setItemPurchased(true);

        }
        Items[itemsSize] = heartItem;
        itemsSize++;

        if (playerStats.getGoldenNeedle() > -1)
        {
            needleItem.setItemPurchased(true);
        }
        Items[itemsSize] = needleItem;
        itemsSize++;
        needleItem.setEquipped(playerStats.getGoldenNeedle());

        if (playerStats.getProjAttack() > -1)
        {
            projAttackItem.setItemPurchased(true);
        }
        Items[itemsSize] = projAttackItem;
        itemsSize++;
        projAttackItem.setEquipped(playerStats.getProjAttack());

        if (playerStats.getGPAttack() > -1)
        {
            gpAttackItem.setItemPurchased(true);
        }
        Items[itemsSize] = gpAttackItem;
        itemsSize++;
        gpAttackItem.setEquipped(playerStats.getGPAttack());

        if (playerStats.getDash() > -1)
        {
            dashItem.setItemPurchased(true);
        }
        Items[itemsSize] = dashItem;
        itemsSize++;
        dashItem.setEquipped(playerStats.getDash());

        if (playerStats.getShadowNeedle() > -1)
        {
            shadowNeedleItem.setItemPurchased(true);
        }
        Items[itemsSize] = shadowNeedleItem;
        itemsSize++;
        shadowNeedleItem.setEquipped(playerStats.getShadowNeedle());    

        if (playerStats.getSandNeedle() > -1)
        {
            sandNeedleItem.setItemPurchased(true);
        }
        Items[itemsSize] = sandNeedleItem;
        itemsSize++;
        sandNeedleItem.setEquipped(playerStats.getSandNeedle());

        if (playerStats.getHealer() > -1)
        {
            healItem.setItemPurchased(true);
        }
        Items[itemsSize] = healItem;
        itemsSize++;
        healItem.setEquipped(playerStats.getHealer());

        if (playerStats.getWave() > -1)
        {
            waveItem.setItemPurchased(true);
        }
        Items[itemsSize] = waveItem;
        itemsSize++;
        waveItem.setEquipped(playerStats.getWave());

    }

    void update()
    {
        playerStats.setGoldenNeedle(Items[1].getEquipped());
        playerStats.setDash(Items[4].getEquipped());
        playerStats.setShadowNeedle(Items[5].getEquipped());
        playerStats.setSandNeedle(Items[6].getEquipped());
        playerStats.setProjAttack(Items[2].getEquipped());
        playerStats.setWave(Items[8].getEquipped());
        playerStats.setGPAttack(Items[3].getEquipped());
        playerStats.setHealer(Items[7].getEquipped());
    }

}