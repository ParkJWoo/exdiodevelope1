using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item2 : MonoBehaviour {

    public static item2 instance;

    // Use this for initialization
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
}
