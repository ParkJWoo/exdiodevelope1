using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour {
    private bool move_it = false;       //이동에 대한 변수
    public Camera cam;                  //카메라
    private Vector3 target_pos;         //이동할 지점을 저장하는 벡터
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //마우스로 클릭한 지점의 좌표를 반환
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                target_pos = hit.point;
            }
            move_it = true;
        }
        //이동이 활성화되고 목표지점에 근접했을 때 멈춤
        if(move_it == true)
        {
            if (target_pos.x < this.transform.position.x)
                this.transform.Translate(Vector3.left * speed * Time.deltaTime);
            else if (target_pos.x > this.transform.position.x)
                this.transform.Translate(Vector3.right * speed * Time.deltaTime);
            //벡터 간 거리를 재는 변수
            float dis = Vector3.Distance(transform.position, target_pos);
            //일정 거리 안으로 들어오면 이동을 멈춘다
            if(dis < 0.01f)                                                                                        
            {
                move_it = false;
            }
        }
	}
}
