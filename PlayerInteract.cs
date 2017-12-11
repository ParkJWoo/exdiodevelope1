using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    // 현재 닿은 오브젝트를 표시하게 됨
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;

    void Update()
    {
        if(Input.GetButtonDown ("Interact") && currentInterObj)
        {
            //인벤토리에 저장되었나 보기위해 확인함
            if(currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }

            //오브젝트랑 무언가를 함
            currentInterObj.SendMessage("DoInteraction"); //item.Send~~로 해도 되는듯
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            Debug.Log(other.name);
            //커렌트인터오브젝트를 현재 닿고있는 오브젝트로 바꿈(인스펙터에 표시됨)
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject> ();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            //오브젝트를 벗어나면 다시 null로 바꿈
            if(other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }
}
