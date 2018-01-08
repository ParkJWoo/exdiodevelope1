using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SETACTIVE : MonoBehaviour
{
  public int c = 0;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {       
            ++c;

        }


        if (c % 2 == 0)
        {
            GameObject.Find("esc").SetActive(false);
            Time.timeScale = 1.0f;
        }
 

         if (c % 2 == 1) { 


           GameObject.Find("ugotmemother").transform.Find("esc").gameObject.SetActive(true);

            Time.timeScale = 0.0f;


        }
       
    }
}
