using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDB : MonoBehaviour
{

    public Sprite[] sprites;

    public static List<Item> itemList = new List<Item>();

    void Start()
    {

        Item i0 = new Item();
        i0.name = "AK47";
        i0.type = Item.Type.equip;
        i0.sprite = sprites[0];
        itemList.Add(i0);

        Item i1 = new Item();
        i1.name = "COLT";
        i1.type = Item.Type.equip;
        i1.sprite = sprites[1];
        itemList.Add(i1);

        Item i2 = new Item();
        i2.name = "GAILI";
        i2.type = Item.Type.equip;
        i2.sprite = sprites[2];
        itemList.Add(i2);

        Item i3 = new Item();
        i3.name = "HK";
        i3.type = Item.Type.equip;
        i3.sprite = sprites[3];
        itemList.Add(i3);

        Item i4 = new Item();
        i4.name = "GLOCK17";
        i4.type = Item.Type.equip;
        i4.sprite = sprites[4];
        itemList.Add(i4);
    }

    void Update()
    {

    }
}
