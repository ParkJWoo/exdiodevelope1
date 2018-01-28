using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour {

    private GameObject door1, follower;

	// Use this for initialization
	void Start () {
        door1 = GameObject.Find("문");   //사슬문
        follower = GameObject.Find("남주");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(follower.GetComponent<Follow>().enabled == false)
            {
                Debug.Log("door1 open");
                door1.GetComponent<Door>().transform.position = new Vector2(43f, 0.5f);
                Destroy(follower);
                Destroy(door1);
            }
            else
            {
                Debug.Log("Not yet");
            }
        }
    }
}
