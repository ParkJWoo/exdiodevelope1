using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[10]; //인스펙터에 인벤토리 생성
	
    public void AddItem(GameObject item)
    {
        bool itemAdded = false;
        //인벤토리 첫번째 오픈슬롯을 찾음
        for(int i=0; i< inventory.Length; i++)
        {
            if(inventory [i] == null)
            {
                inventory[i] = item;
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
}
