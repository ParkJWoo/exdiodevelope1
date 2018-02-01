using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 1.5f;              //캐릭터의 이동속도(Inspector에서 변경 가능)
    public Vector2 target;                 //캐릭터
    public Animator animator;
    public bool isFacingRight = true;      //캐릭터가 오른쪽을 보고있는지 확인하는 변수
    new SpriteRenderer renderer;
    public GameObject PlayerRef;

    // Use this for initialization
    void Start()
    {
        target = transform.position;
        animator = this.GetComponent<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        PlayerRef = GameObject.FindGameObjectWithTag("player");
            
    }
    // Update is called once per frame
    void Update()
    {
        //마우스를 버튼을 눌렀다 떼거나 클릭을 유지하면
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);       //캐릭터의 위치를 마우스로 클릭한 좌표로
            target.y = transform.position.y;                                    //캐릭터의 y좌표는 처음 위치의 y좌표(즉 y좌표 고정)
        }

        //마우스로 찍은 위치의 x좌표가 캐릭터의 x좌표보다 크고(캐릭터보다 오른쪽에 있는 위치 클릭), 캐릭터가 왼쪽을 보고 있으면
        if (target.x > transform.position.x && isFacingRight == false)
        {
            isFacingRight = !isFacingRight;                                     //false를 true로
            animator.SetBool("move_it", true);                                  //move_it은 이동을 정하는 파라미터
            renderer.flipX = false;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);   //마우스로 찍은 좌표로 캐릭터 이동
           // GetComponent<AudioSource>().UnPause();
        }

        //마우스로 찍은 위치의 x좌표가 캐릭터의 x좌표보다 작고(캐릭터보다 왼쪽에 있는 위치 클릭), 캐릭터가 오른쪽을 보고 있으면
        else if (target.x < transform.position.x && isFacingRight == true)
        {
            isFacingRight = !isFacingRight;
            animator.SetBool("move_it", true);
            renderer.flipX = true;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
           // GetComponent<AudioSource>().UnPause();
        }
        animator.SetBool("move_it", true);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //GetComponent<AudioSource>().UnPause();

        float dis = Vector2.Distance(transform.position, target);               //마우스 좌표와 캐릭터 사이의 거리를 계산하는 변수 dis
        if (dis < 0.01f)
        {                           //둘 사이의 거리가 일정 거리 이내가 되면
            animator.SetBool("move_it", false);
           // GetComponent<AudioSource>().Pause();
        }
        //이동을 멈춤

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position); //캐릭터의 월드 좌표를 뷰포트 좌표계로 변환해준다.
        viewPos.x = Mathf.Clamp01(viewPos.x); //x값을 0이상, 1이하로 제한한다.
        viewPos.y = Mathf.Clamp01(viewPos.y); //y값을 0이상, 1이하로 제한한다.
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos); //다시 월드 좌표로 변환한다.
        transform.position = worldPos; //좌표를 적용한다.
    }



}