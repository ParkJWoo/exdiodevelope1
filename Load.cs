using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour {

	Save savedData;
	PlayerData data;
	public bool isLoaded; 

	private void Start()
	{
		savedData = GameObject.FindGameObjectWithTag("player").GetComponent<Save>();
		isLoaded = false;
	}

	public void Loader()
	{
		if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);

			//transform.position = new Vector2 (data.playerPosX_L, data.playerPosY_L);


			Debug.Log("Loading");

			//SceneManager.LoadSceneAsync("large_room", LoadSceneMode.Single);

			//  SceneManager.LoadScene("large_room");
		}

		else
		{
			Debug.Log("파일이 안읽혀요 ㅠㅠ");
		}

	}

	public void callScene()
	{
		isLoaded = true;
		Loader ();
		Application.LoadLevel (3);

	}

	//씬을 불러오는 코드

	[Serializable]
	class PlayerData
	{
		public float playerPosX_L;
		public float playerPosY_L;
		//public int playerPosScene;
	}
}