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
    #region Game Variables
    [SerializeField] private GameObject player;
    [SerializeField] private bool gameOver;
    [SerializeField] private int score;
    public GameObject Player { get => player; set => player = value; }
    public bool GameOver { get => gameOver; set => gameOver = value; }
    public int Score { get => score; set => score = value; }

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
    private void Awake()
    {
        Singleton();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Start()
    {
        Player.SetActive(false);
        LoadManager.Instance.LoadMainMenu();


    }
    public void StartNewGame()
    {
        Player.SetActive(true);
        LoadManager.Instance.LoadNewGame();
        GameManager.Instance.Score = 0;
        UIManager.Instance.ScoreBoard.GetComponent<ScoreBoard>().ResetScore();
        StartSpawner();
    }

    public void LoadFromSave(string fileName)
    {
        Player.SetActive(true);
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData_FPS save = JsonUtility.FromJson<SaveData_FPS>(json);
            string lastScene = save.LastScene;
            List<Action> functions = new List<Action>
            {
                () => Player = LoadManager.Instance.LoadSavedPlayer(save),
                () => Score = LoadManager.Instance.LoadScoreFromSave(save),
                () => UIManager.Instance.ScoreBoard.GetComponent<ScoreBoard>().SetScore(Score),
                () => gameOver = false,
                () => ResumeGame(),
                () => StartSpawner()
            };
            LoadManager.Instance.LoadAsyncSceneThenDo("TestScene", functions);
        }
        else
        {
            Debug.Log("No SaveFile Found.");
        }
    }
    public void StartSpawner()
    {
        SpawnManager.Instance.GetComponent<SpawnEnemyScript>().SpawnEnemyRepeating();
    }
    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
        if (Player.gameObject != null)
        {
            Player.GetComponent<PlayerController>().enabled = false;
        }
    }
    public void ResumeGame()
    {
        if (!GameOver)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            if (Player.gameObject != null)
            {
                Player.GetComponent<PlayerController>().enabled = true;
            }
        }

    }
    public void GameOverLogic()
    {
        SpawnManager.Instance.GetComponent<SpawnEnemyScript>().StopAllCoroutines();
        PauseGame();
        UIManager.Instance.ShowGameOver();
    }


}
   
 