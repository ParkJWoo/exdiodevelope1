using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryD : MonoBehaviour {

    public static inventoryD instance;

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
