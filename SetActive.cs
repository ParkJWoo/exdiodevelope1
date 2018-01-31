using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour {
    private GameObject mirror_pass;
    private GameObject strong_box;
    private GameObject pswd;

    void Start () {
        mirror_pass = GameObject.Find("mirror_password");
        mirror_pass.SetActive(false);

        strong_box = GameObject.Find("strong_box");
        strong_box.SetActive(false);
    }
	
}
