using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subtitle : MonoBehaviour
{


    public GUIStyle TextStyle;

    public string[] SUBTITLE;

    private int i = 0;

    private const float WAIT_TIME = 0.1f;

    private float waitTimer = 0.0f;

    

    private string typewriterText = "";

    private int currentIndex = 0;



    // Use this for initialization
    void Start()
    {

        TextStyle.normal.textColor = Color.white;
        TextStyle.fontSize = 20;


    }

    // Update is called once per frame
    void Update()

    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            i++;
            currentIndex = 0;
            typewriterText = "";

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            i--;
            currentIndex = 0;
            typewriterText = "";

        }


        waitTimer += Time.deltaTime;

        if (waitTimer > WAIT_TIME && currentIndex < SUBTITLE[i].Length)
        {
            typewriterText += SUBTITLE[i][currentIndex];
            waitTimer = 0.0f;
            ++currentIndex;
        }
    }



void OnGUI()
    {

        GUI.Label(new Rect(Screen.width / 8, Screen.height / 3, 400.0f, 200.0f), typewriterText);
    }


}

    


       
    

       

    
