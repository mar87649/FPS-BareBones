using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    #region NewGameVariables
    [SerializeField] GameObject NewGameWeapon;
    #endregion
    #region Singleton Pattern
    public static GameManager Instance { get; private set; }
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
    #endregion
    private void Start()
    {
       SceneManager.LoadScene("Main Menu", LoadSceneMode.Additive);
    }
    private void Awake()
    {
        Singleton();        
    }
    public void StartNewGame()
    {
        LoadManager.Instance.LoadNewGame();
    }

    public void LoadFromSave()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData_FPS data = JsonUtility.FromJson<SaveData_FPS>(json);
            string lastScene = data.LastScene;
            List<Action> functions = new List<Action>();
            functions.Add(()=> LoadManager.Instance.LoadPlayer(data));
            LoadManager.Instance.LoadAsyncSceneThenDo("TestScene", functions);
        }
    }
}

