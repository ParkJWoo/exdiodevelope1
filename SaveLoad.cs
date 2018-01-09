using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SaveLoad : MonoBehaviour {

    public void Save() //저장
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerData.dat");

        PlayerData data = new PlayerData();

        data.posX = transform.position.x;
        data.posY = transform.position.y;

        formatter.Serialize(file, data);
        file.Close(); 
    }

    public void Load() //로드
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerData.dat", FileMode.Open);
            PlayerData data = (PlayerData)formatter.Deserialize(file);
            file.Close();

            transform.position = new Vector2(data.posX, data.posY);
        }
    }

    [Serializable]
    class PlayerData //플레이어 정보 클래스
    {
        public float posX;
        public float posY;
    }
    
}
