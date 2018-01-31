using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class Save : MonoBehaviour {

	public void Saver()
	{
		//바이너리 파일 생성
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

		//저장하고자 하는 오브젝트의 정보
		PlayerData data = new PlayerData();

		data.playerPosX = transform.position.x;
		data.playerPosY = transform.position.y;
		//data.playerPosScene= //현재 씬 번호 불러오는 거
		bf.Serialize(file, data);
		file.Close();

		Debug.Log("saving..");

	}

	[Serializable]
	class PlayerData
	{
		public float playerPosX;
		public float playerPosY;
		//public int playerPosScene;
	}
}
