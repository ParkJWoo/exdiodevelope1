using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class Load : MonoBehaviour {

    Save savedData;
    PlayerData data;
    
    private void Start()
    {
        savedData = GameObject.FindGameObjectWithTag("player").GetComponent<Save>();
    }

    public void Loader()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            
            transform.position
            
           
            Debug.Log("Loading");

            //SceneManager.LoadSceneAsync("large_room", LoadSceneMode.Single);

            //  SceneManager.LoadScene("large_room");
        }

        else
        {
            Debug.Log("파일이 안읽혀요 ㅠㅠ");
        }

    }

    [Serializable]
    class PlayerData
    {
        public float playerPosX_L;
        public float playerPosY_L;
    }
}
