using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    #region Public Fields

    public static GameControl Instance;
    public GameData gameData = new GameData();
    public Scene openScene;

    private string savePath;
    public string SavePath
    {
        get
        {
            if (savePath != null)
            {
                return savePath;
            }
            else
            {
                savePath = Application.persistentDataPath + "/SavedGames/";
                return savePath;
            }
        }
    }

    #endregion Public Fields

    #region Private Fields

    private const string FILE_EXTENTION = ".xml";

    private string saveFile;

    #endregion Private Fields

    #region Public Methods

    public void DeleteSaveFile(string saveFile)
    {
        if (File.Exists(SavePath + saveFile + FILE_EXTENTION))
        {
            File.Delete(SavePath + saveFile + FILE_EXTENTION);
        }
        else
        {
            Debug.LogError("Failed to delete non exitence file" + SavePath + saveFile + FILE_EXTENTION);
        }
    }

    public bool DoesFileExist(string testFileName)
    {
        foreach(GameData data in GetAllSaveFiles())
        {
            if (data.lastSaveFile == testFileName)
            {
                return true;
            }
        }
        return false;
    }

    public string GenerateNewSaveName()
    {
        int attempt = 0;
        string newSaveName = "";

        while (newSaveName == "")
        {
            string checkString = gameData.playerName;

            if (attempt != 0) checkString += attempt;

            if (!File.Exists(SavePath + checkString))
            {
                newSaveName = checkString;
            }
            attempt++;
        }
        return newSaveName;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            SceneManager.sceneLoaded += OnSceneLoaded;
            openScene = SceneManager.GetActiveScene();
        }

        else if (Instance != this)
        {
            Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }
    }

    private void CheckDirectory()
    {
        if (!Directory.Exists(SavePath))
        {
            Directory.CreateDirectory(SavePath);
        }
    }


    public List<GameData> GetAllSaveFiles()
    {
        List<GameData> allSaves = new List<GameData>();

        foreach(string fileName in Directory.GetFiles(SavePath))
        {
            allSaves.Add(GetSaveFile(fileName));
        }
        return allSaves;
    }

    public int GetFlag(string flagName)
    {
        GameFlag flag = gameData.gameFlags.Find(x => x.flag == flagName);

        if (flag == null)
        {
            SetFlag(flagName, 0);
            return 0;
        }
    }

    public void LoadGame(string gameName)
    {
        CheckDirectory();

        String fullFilePath = SavePath + saveFile + FILE_EXTENTION;

        if (File.Exists(fullFilePath))
        {
            Debug.Log("Deserializing " + fullFilePath);

            FileStream fs = File.Open(fullFilePath, FileMode.Open);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameData));
            XmlReader reader = XmlReader.Create(fs);
            gameData = xmlSerializer.Deserialize(reader) as GameData;
            fs.Close();

            SceneManager.LoadSceneAsync(gameData.savedScene, LoadSceneMode.Single);
        }

        else
        {
            Debug.Log("Failed to save to file " + fullFilePath);
        }
    }

    public void SaveGame(string saveFile)
    {
        CheckDirectory(); 

        if (saveFile == null)
        {
            saveFile = GenerateNewSaveName();
        }

        this.saveFile = saveFile;

        UpdateSaveData(saveFile);

        string fullSavePath = SavePath + saveFile + FILE_EXTENTION;

        FileStream fs;

        if (!File.Exists(fullSavePath))
        {
            fs = File.Create(fullSavePath);
        }
        else
        {
            fs = File.OpenWrite(fullSavePath);
        }
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameData));
        TextWriter textWriter = new StreamWriter(fs);
        xmlSerializer.Serialize(textWriter, gameData);
        fs.Close();

        Debug.Log("Game Saved to " + fullSavePath);
    }

    private void UpdateSaveData(string saveFile)
    {
        gameData.lastSaveFile = saveFile;
        gameData.lastSaveTime = DateTime.Now.ToBinary();
        gameData.savedScene = SceneManager.GetActiveScene().name;
    }

    private GameData GetSaveFile(string fullFilePath)
    {
        if (File.Exists(fullFilePath))
        {
            FileStream fs = File.Open(fullFilePath, FileMode.Open);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameData));
            XmlReader reader = XmlReader.Create(fs);
            GameData data = xmlSerializer.Deserialize(reader) as GameData;
            fs.Close();

            return data;
        }
        else
        {
            Debug.LogError("Failed to save to file" + fullFilePath);
            return null;
        }
    }

    public void SetFlag(string flagName,int value)
    {
        GameFlag oldFlag = gameData.gameFlags.Find(x => x.flag == flagName);

        if (oldFlag != null)
        {
            oldFlag.value = value;
        }
        else
        {
            gameData.gameFlags.Add(new GameFlag(flagName, value));
        }
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        CheckDirectory();
    }

    #endregion Public Methods

    [Serializable]
    public class GameFlag
    {
        #region Public Fields

        public string flag;
        public int value;

        #endregion Public Fields

        #region Pubic Constructors

        public GameFlag()
        {

        }

        public GameFlag(string flag,int value)
        {
            this.flag = flag;
            this.value = value;
        }

        #endregion Public Constructors
    }

    [Serializable]
    public class GameData
    {
        #region Public Fields

        public int currentChapter;

        public List<GameFlag> gameFlags;

        public string playerName;

        [NonSerialized]
        public Vector3 playerPosition;

        public string lastSaveFile;

        public long lastSaveTime;

        public string savedScene;

        public int upgradePoints = 0;

        public int upgradePointsSpent = 0;

        #endregion Public Fields

        #region Public Constructors

        public GameData()
        {
            playerPosition = Vector2.zero;
            playerName = "JiYeon";
            upgradePoints = 0;
            upgradePointsSpent = 0;
            currentChapter = 1;
            gameFlags = new List<GameFlag>();
            savedScene = "";
        }

        #endregion Public Constructors

        #region Public Properties

        public float PlayerPositionX
        {
            get
            {
                return playerPosition.x;
            }
            set
            {
                playerPosition.x = value;
            }
        }

        public float PlayerPositionY
        {
            get
            {
                return playerPosition.y;
            }
            set
            {
                playerPosition.y = value;
            }
        }
        
    }
    #endregion Public Properties
}
