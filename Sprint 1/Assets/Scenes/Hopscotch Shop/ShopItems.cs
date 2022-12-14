using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class ShopItems
{
    //The Locations of each slot possibility (could be stored within the item)
    //private Vector3[] slotsVec = new Vector3[4];
    private Vector3 location = new Vector3(6.5f, 130.7f, 0);

    //Stores the visual in the list
    private GameObject item;

    //Allows us to control the transform of the visual
    private RectTransform itemTF;

    //Stores the visual preview of the item
    private GameObject itemPrev;

    //Stores the price of the item
    private int itemPrice;

    //Item code to be used in a switch case in the main code
    private int itemCode;

    private bool purchased;

    private int equipped;

    public ShopItems(GameObject i, RectTransform it, GameObject ipv, int ipe, int ic)
    {
        item = i;
        itemTF = it;
        itemPrev = ipv;
        itemPrice = ipe;
        itemCode = ic;
        purchased = false;

    }

    public void PlaceItem(int i)
    {
        itemTF.anchoredPosition = location + new Vector3(0, (i * -32), 0);
    }

    public void setItemPrev(bool b)
    {
        itemPrev.SetActive(b);
    }

    public int getItemPrice()
    {
        return itemPrice;
    }

    public void setItemPrice(int i)
    {
        itemPrice = i;
    }

    public int getItemCode()
    {
        return itemCode;
    }

    public bool getItemPurchased()
    {
        return purchased;
    }

    public void setItemPurchased(bool b)
    {
        purchased = b;
    }

    public GameObject getItem()
    {
        return item;
    }

    public void setEquipped(int i)
    {
        equipped = i;
    }

    public int getEquipped()
    {
        return equipped;
    }


}
