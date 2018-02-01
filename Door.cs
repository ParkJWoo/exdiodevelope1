using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private GameObject target = null;
    private GameObject target2;

    public float movement = 2.0f;
    public float doormovement = 1.0f;

    Vector2 currentPos;
    Vector2 targetPos;

    public GameObject follower;

    // Use this for initialization
    void Start()
    {
        target = GameObject.Find("크리쳐");

        currentPos = new Vector2(43f, -2.5f);
        targetPos = new Vector2(43f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (target.transform.position.x <= 24f)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, targetPos, doormovement * Time.deltaTime);
        //}
        //else
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, currentPos, doormovement * Time.deltaTime);
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //주인공이 문과 충돌하면
        if (collision.tag == "Player")
        {
            Debug.Log("We arrived at the door");
            if(Input.GetMouseButton(0))
            {
                CastRay();
                if(target2 == this.gameObject)
                {
                    follower.GetComponent<Follow>().enabled = false;    //남주가 움직이지 않는다
                }
            }
        }
    }

    void CastRay()
    {
        target2 = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if(hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            target2 = hit.collider.gameObject;
        }
    }
}
