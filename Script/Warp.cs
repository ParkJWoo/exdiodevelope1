using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Warp : MonoBehaviour
{
    IEnumerator OnTriggerStay2D(Collider2D other)
    {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        // "Fader" = 태그이름, 스크린페이더 스크립트 속 ScreenFader()컴포넌트를 가져옴
        if (Input.GetMouseButtonDown(0))
        {
            yield return StartCoroutine(sf.FadeToBlack());
            // 코루틴으로 FadeToBlack 함수 실행

            SceneManager.LoadScene("scene test"); //씬 이름 넣을것.

            // 카메라가 캐릭터를 향해 이동
            yield return StartCoroutine(sf.FadeToClear());
            // 코루틴으로 FadeToClear 함수 실행
        }
    }
}
