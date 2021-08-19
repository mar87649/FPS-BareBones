using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    #region NewGameVariables
    [SerializeField] GameObject NewGameWeapon;
    [SerializeField] GameObject player;
    public int Score;

    #endregion
    #region Singleton Pattern
    public static GameManager Instance { get; private set; }
    public GameObject Player { get => player; set => player = value; }

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
    private void Awake()
    {
        Singleton();

    }
    private void Start()
    {
       SceneManager.LoadScene("Main Menu", LoadSceneMode.Additive);
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
            SaveData_FPS save = JsonUtility.FromJson<SaveData_FPS>(json);
            string lastScene = save.LastScene;
            List<Action> functions = new List<Action>
            {
                () => Player = LoadManager.Instance.LoadPlayer(save),
                () => Score = LoadManager.Instance.LoadScoreFromSave(save),
                () => UIManager.Instance.ScoreBoard.GetComponent<ScoreBoard>().UpdateScore(Score)
            };
            LoadManager.Instance.LoadAsyncSceneThenDo("TestScene", functions);   
        }else
        {
            Debug.Log("No SaveFile Found.");
        }
    }
    /// <summary>
    /// initialize game level
    /// </summary>
    public void InitLevel()
    {
        GameObject enemyPrefab = Resources.Load<GameObject>("Prefabs/Enemy");
        GameObject spawnManager = GameObject.Find("Spawn Manager");
        //TODO - change game object find to something more flexible. dont use strings
        List<GameObject> spawnedList = SpawnManager.Instance.InstantiateXTimes(15, enemyPrefab);
        foreach (GameObject item in spawnedList)
        {
            item.name = enemyPrefab.name;
            item.transform.parent = spawnManager.transform;
            item.transform.position = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        }
    }

}
   
 