using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    public Transform warpTarget;

    IEnumerator OnTriggerEnter2D(Collider2D other) 
    {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent <ScreenFader>();
        // "Fader" = 태그이름, 스크린페이더 스크립트 속 ScreenFader()컴포넌트를 가져옴
        
        yield return StartCoroutine(sf.FadeToBlack());
        // 코루틴으로 FadeToBlack 함수 실행
        other.gameObject.transform.position = warpTarget.position;
        Camera.main.transform.position = warpTarget.position;

            yield return StartCoroutine(sf.FadeToClear() );
    }
}
