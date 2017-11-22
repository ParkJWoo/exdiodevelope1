using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0))                 //화면상의 픽셀 좌표를 게임 월드 좌표로 반환
        {
            Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
	}
    void Move(Vector3 target)
    {
        target.z = 0;                               //2d 평면 이동이므로 z좌표는 0
        target.y = this.transform.position.y;       //y좌표는 캐릭터의 현재 y좌표로 고정
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //이 함수를 호출할 때마다 target과 조금씩 가까워진다
    }
}
