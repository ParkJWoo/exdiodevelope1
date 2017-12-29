using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distance : MonoBehaviour {

    private GameObject target = null;

    public float movement = 2.0f;

    public float doormovement = 1.0f;

    Vector2 currentPos;

    Vector2 targetPos;

	// Use this for initialization
	void Start () {

        

        target = GameObject.Find("무케");

        currentPos = new Vector2(5.1f, -0.58f);

        targetPos = new Vector2(5.1f, 4.72f);

    }
	
	// Update is called once per frame
	void Update () {

        float xdis = transform.position.x - target.transform.position.x;

        if (xdis > 5.0f)
        {

            transform.position = Vector2.MoveTowards(transform.position, targetPos, doormovement * Time.deltaTime);


        }

        else
        {


            transform.position = Vector2.MoveTowards(transform.position, currentPos, movement * Time.deltaTime);

        }


		
	}
}
