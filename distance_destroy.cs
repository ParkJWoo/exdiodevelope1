using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reopenD : MonoBehaviour
{


    public bool reopen = false;

    public bool hallway_sub = true;

    public bool hallway_sub2 = true;

    public bool largeroom_sub = true;

    public bool largeroom_sub2 = true;

    public bool toilet_sub = true;



    public static reopenD instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }

    void Update()
    {

        if (SceneManager.GetActiveScene().name == "Game over")
            Destroy(this.gameObject);
    }
}
openD>().largeroom_sub == true