using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Follow : MonoBehaviour {

    public float xDis = 0;
    public float speed = 1.0f;
    private GameObject target = null;
    private Vector2 follower;
    private Vector2 left;
    private Vector2 right;
    Rigidbody2D C_rigid;

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        left = new Vector2(24.0f, transform.position.y);
        right = new Vector2(34.0f, transform.position.y);
        C_rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector2.Distance(transform.position, target.transform.position);

        //행동가능 범위 이내
        if (transform.position.x >= 23.0f && transform.position.x <= 35.0f)
        {
            if (dis > xDis)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            }
        }
        //행동가능 범위 밖
        else if (transform.position.x < 23.0f || transform.position.x > 35.0f)
        {
            if(transform.position.x < 23.0f)
            {
                C_rigid.constraints = RigidbodyConstraints2D.FreezePositionX;   //x축 이동을 고정시켜 더 이상 움직이지 않는다(떨림 방지)
            }
            else if(transform.position.x > 35.0f)
            {
                C_rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            }
        }
    }
}
