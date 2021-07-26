using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        Singleton();
    } 
    private void Singleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Additive);
    }

    [System.Serializable]
    class SaveData
    {
        //data to be saved
    }

    public void SaveGameData()
    {
        SaveData data = new SaveData();
        //save the number of enemies left
        //save their positions
        //save the score and number of lives
        //save the amount of health 
        //data.[variable or data to be saved] = [variable for data]

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            //load the number of enemies left
            //load their positions
            //load the score and number of lives
            //load the amount of health 
            //[assign data to variable]
        }
    }
}

