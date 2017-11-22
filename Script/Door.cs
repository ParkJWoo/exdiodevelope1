using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "player") // 캐릭터 이름 태그할 것.
        {
            if (Input.GetMouseButton(0)) //마우스 클릭시
            {
                SceneManager.LoadScene("scene2"); //씬 이름 넣을것.
            }
        }

    }

    // Update is called once per frame
    void Update () {
        
    }
}
