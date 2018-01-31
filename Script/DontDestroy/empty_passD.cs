﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empty_passD : MonoBehaviour {

    public static empty_passD instance;

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
