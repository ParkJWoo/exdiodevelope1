using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventory; //트루면 오브젝트가 인벤토리에 저장될 수 있음
    public bool openable; //트루면 오브젝트를 열 수 있음
    public bool locked; //트루면 오브젝트가 잠김 (예를 들어 문을열때)
    public string itemType; //이 오브젝트가 무슨 타입의 아이템인지 말해줄거임

    public GameObject itemNeeded; //이 아이템과 상호작용을 하기 위해 아이템이 필요

    public void DoInteraction()
    {
        //줍고 인벤토리에 저장
        gameObject.SetActive(false);
    }
}
