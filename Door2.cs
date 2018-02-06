using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour {

    private GameObject door1, follower, target;

	// Use this for initialization
	void Start () {
        door1 = GameObject.Find("문");
        follower = GameObject.Find("남주");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("door1 도착");
            if(Input.GetMouseButton(0))
            {
                if(follower.GetComponent<Follow>().enabled == false)
                {
                    CastRay();
                    if(target == this.gameObject)
                    {
                        Destroy(door1);
                        Destroy(follower);
                        Debug.Log("destroyed");
                    }
                    else
                    {
                        Debug.Log("ㅁㄴㅇㄹ");
                    }
                }
            }
        }
    }

    void CastRay()
    {
        target = null;
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Ray2D ray = new Ray2D(pos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            target = hit.collider.gameObject;
        }
    }
}
