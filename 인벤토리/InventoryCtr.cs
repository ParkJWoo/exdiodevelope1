using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCtr : MonoBehaviour
{

    public Transform selectedItem, selectedSlot, originalSlot;

    public GameObject SlotPb, ItemPb;
    public Vector2 inventorySize = new Vector2(4, 6);
    public float slotSize;
    public Vector2 windowSize;

    // Use this for initialization
    void Start()
    {
        for (int x = 1; x <= inventorySize.x; x++)
        {
            for (int y = 1; y <= inventorySize.y; y++)
            {
                GameObject slot = Instantiate(SlotPb) as GameObject;
                slot.transform.parent = this.transform;
                slot.name = "slot_" + x + "_" + y;
                slot.GetComponent<RectTransform>().anchoredPosition = new Vector3(windowSize.x / (inventorySize.x + 1) * x, windowSize.y / (inventorySize.y + 1) * -y, 0);

                if ((x + (y - 1) * 4) <= GameDB.itemList.Count)
                {
                    GameObject item = Instantiate(ItemPb) as GameObject;
                    item.transform.parent = slot.transform;
                    item.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
                    Item i = item.GetComponent<Item>();

                    i.name = GameDB.itemList[(x + (y - 1) * 4) - 1].name;
                    i.type = GameDB.itemList[(x + (y - 1) * 4) - 1].type;
                    i.sprite = GameDB.itemList[(x + (y - 1) * 4) - 1].sprite;

                    item.name = i.name;
                    item.GetComponent<Image>().sprite = i.sprite;
                }
            }
        }
    }





    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedItem != null)
        {
            originalSlot = selectedItem.parent;
            selectedItem.GetComponent<Collider>().enabled = false;
        }

        if (Input.GetMouseButton(0) && selectedItem != null)
        {
            selectedItem.position = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) && selectedItem != null)
        {
            if (selectedSlot == null) selectedItem.parent = originalSlot;
            else
            {
                selectedItem.parent = selectedSlot;
            }
            selectedItem.localPosition = Vector3.zero;
            selectedItem.GetComponent<Collider>().enabled = true;
        }
    }
}
