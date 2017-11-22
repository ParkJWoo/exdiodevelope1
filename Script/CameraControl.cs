using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    private GameObject player = null;
    private Vector3 position_offset = Vector3.zero;

	// Use this for initialization
	void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player");                               //플레이어 오브젝트에 플레이어 태그가 설정된 오브젝트(캐릭터)를 할당
        this.position_offset = this.transform.position - this.player.transform.position;        //카메라와 캐릭터 위치 차이를 계산하고 변수 position_offset에 저장
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate() {
        Vector3 new_position = this.transform.position;                                         //카메라의 현재 위치를 new_position에
        new_position.x = this.player.transform.position.x + this.position_offset.x;             //카메라의 현재 위치에 위치 차이를 더해서 new_position의 x값 변경
        this.transform.position = new_position;
    }
}