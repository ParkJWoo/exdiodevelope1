using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distance_destroy : MonoBehaviour {

    private GameObject target = null;

    

	// Use this for initialization
	void Start () {


        target = GameObject.Find("무케");
	}
	
	// Update is called once per frame
	void Update () {

        
       		
	}

    private void OnMouseDown()
    {

        float xdist = transform.position.x - target.transform.position.x;

        if (xdist < 2.0f) 
        {
            Destroy(GameObject.Find("사슬"));

        }
    }
}
