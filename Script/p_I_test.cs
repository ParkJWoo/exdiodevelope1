using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class p_I_test : MonoBehaviour
{

    // 현재 닿은 오브젝트를 표시하게 됨
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        // "Fader" = 태그이름, 스크린페이더 스크립트 속 ScreenFader()컴포넌트를 가져옴

        if (Input.GetMouseButtonDown(0) && currentInterObj)
        {
            //인벤토리에 저장되었나 보기위해 확인함
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);

            }

            //오브젝트가 opened인지 체크
            if (currentInterObjScript.openable)
            {
                //오브젝트가 locked인지 체크
                if (currentInterObjScript.locked)
                {
                    //우리가 잠금을 풀기위해 필요한 오브젝트를 갖고있는지 체크하기위함
                    //필요한 아이템을 우리 인벤토리에서 찾아본다 - 찾으면 잠금을 품
                    if (inventory.FindItem(currentInterObjScript.itemNeeded))
                    {
                        //필요한 아이템을 찾는다
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");

                        yield return StartCoroutine(sf.FadeToBlack());
                        // 코루틴으로 FadeToBlack 함수 실행
                        SceneManager.LoadScene("scene1");

                        // 카메라가 캐릭터를 향해 이동
                        yield return StartCoroutine(sf.FadeToClear());
                        // 코루틴으로 FadeToClear 함수 실행
                    }
                    else
                    {
                        Debug.Log(currentInterObj.name + " was not unlocked");
                    }
                }
                else
                {
                    //오브젝트가 안잠겼을 때 - 오브젝트를 연다.
                    Debug.Log(currentInterObj.name + " is unlocked");

                }
            }
        }
        if (other.CompareTag("InterObject"))
        {
            Debug.Log(other.name);
            //커렌트인터오브젝트를 현재 닿고있는 오브젝트로 바꿈(인스펙터에 표시됨)
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("InterObject"))
        {
            //오브젝트를 벗어나면 다시 null로 바꿈
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }

    
}
