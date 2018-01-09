using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[10]; //인스펙터에 인벤토리 생성
    public Button[] InventoryButtons = new Button[5]; //인스펙터에 인벤토리 버튼 생성

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
        //인벤토리 첫번째 오픈슬롯을 찾음
        for(int i=0; i< inventory.Length; i++)
        {
            if(inventory [i] == null)
            {
                inventory[i] = item;
                //UI 업데이트
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                item.SendMessage("DoInteraction"); //item.Send~~로 해도 되는듯
                break;
            }
        }

        //인벤토리가 꽉찼을 때
        if(!itemAdded)
        {
            Debug.Log("Inventory Full - Item Not Added");
        }
    }

    public bool FindItem(GameObject item)
    {
        for(int i = 0; i < inventory.Length; i++)
        {
            if(inventory [i] == item)
            {
                //아이템을 찾는다
                return true;
            }
        }
        //아이템을 못찾았을시
        return false;
    }

    public GameObject FindItemByType(string itemType)
    {
        for(int i=0; i<inventory.Length; i++)
        {
            if(inventory[i] != null)
            {
                if (inventory[i].GetComponent <InteractionObject>().itemType == itemType)
                {
                    //우리가 보고있는 아이템을 찾음
                    return inventory[i];
                }
            }
        }
        // 아이템 타입을 찾지못함
        return null;
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory [i] == item)
            {
                //아이템을 찾음 - 그걸 삭제함
                inventory[i] = null;
                Debug.Log(item.name + " was removed from inventory");
                //UI 업데이트
                InventoryButtons[i].image.overrideSprite = null;

                break;
            }
        }
    }
}
