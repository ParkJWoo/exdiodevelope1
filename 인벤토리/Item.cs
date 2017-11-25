using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{
    public string Name;
    public enum Type { equip, consumable, misc };
    public Type type;
    public Sprite sprite;

    void Start()
    {

    }
    void Update()
    {

    }

    void OnMouseEnter()
    {
        transform.parent.parent.GetComponent<InventoryCtr>().selectedItem = this.transform;
    }
}