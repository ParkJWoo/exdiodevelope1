using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subtitle : MonoBehaviour {

    public GUIStyle TextStyle;
   
    Font myFont = (Font)Resources.Load("fonts/NANUMPEN", typeof(Font)); // 네이버 나눔글꼴


    // Use this for initialization
    void Start()
    {

        TextStyle.font = myFont;
        TextStyle.normal.textColor = Color.white;
        TextStyle.fontSize = 20;
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void OnGUI()
    {   
        GUI.Label(new Rect(0.0f, 0.0f, 400.0f, 200.0f), "폭파 시간까지 얼마 남지 않았다.", TextStyle);
    }
}
