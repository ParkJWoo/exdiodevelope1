using System.Collections;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoad : MonoBehaviour {
    [Serializable]
    public class Person //저장할 사람 정보
    {
        public int age;
        public string name;

        public override string ToString()
        {
            return "age: " + age + "name: " + name;
        }
    }

    string filePath = string.Empty;
    Person person;
	// Use this for initialization
	void Start () {
        filePath = Application.dataPath + "/test.bin"; //저장 경로 
        person = new Person { age = 29, name = "Jake" };
	}

    void OnGUI()
    {
        if (GUILayout.Button("Save")) //저장 버튼을 누를 시
        {
            BinarySerialize(person, filePath); //위 함수를 실행합니다
        }
        if (GUILayout.Button("Load")) //불러오기 버튼을 누를 시
        { 
            if (System.IO.File.Exists(filePath)) //파일이 존재한다면
            {
                person = BinaryDeserilize(filePath); //위 함수를 실행
                Debug.Log(person);
            }
        }
    }

    public void BinarySerialize(Person person,string filePath) //Save 기능 
    {
        BinaryFormatter formatter = new BinaryFormatter(); 
        FileStream stream = new FileStream(filePath, FileMode.Create);
        formatter.Serialize(stream, person);
        stream.Close();
    }

    public Person BinaryDeserilize(string filePath) //Load 기능 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(filePath, FileMode.Open);
        Person person = (Person)formatter.Deserialize(stream);
        stream.Close();

        return person;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
