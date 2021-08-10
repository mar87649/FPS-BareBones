using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
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
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnMainLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnMainLoaded;
    }
    public void OnMainLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "TestScene")
        {
            GameObject player =  Resources.Load<GameObject>("Prefabs/Player");
            player = Instantiate(player);
            GameObject weapon = Resources.Load<GameObject>("Prefabs/Gun");
            weapon = Instantiate(weapon);
            player.GetComponent<PlayerScript>().InitWeapon(weapon);
        }
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }

    public SaveData_FPS CreateSaveData()
    {
        SaveData_FPS save = new SaveData_FPS();

        save.Health     = (int) GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Health*1000;
        save.MaxHealth  = (int) GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().MaxHealth * 1000;
        save.Weapon     =       GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Weapon.name;

        save.PosX = (int) GameObject.FindGameObjectWithTag("Player").transform.position.x * 1000;
        save.PosY = (int) GameObject.FindGameObjectWithTag("Player").transform.position.y * 1000;
        save.PosZ = (int) GameObject.FindGameObjectWithTag("Player").transform.position.z * 1000;

        save.RotX = (int) GameObject.FindGameObjectWithTag("Player").transform.eulerAngles.x * 1000;
        save.RotY = (int)GameObject.FindGameObjectWithTag("Player").transform.eulerAngles.y * 1000;
        save.RotZ = (int)GameObject.FindGameObjectWithTag("Player").transform.eulerAngles.z * 1000;

        save.LastScene = SceneManager.GetActiveScene().name;

        return save;
    }

    public void SaveGameData()
    {
        SaveData_FPS data = CreateSaveData();
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath + "/savefile.json");
        Debug.Log("Game Saved");
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData_FPS data = JsonUtility.FromJson<SaveData_FPS>(json);
            string lastScene = data.LastScene;
            GameObject player = Resources.Load<GameObject>("Prefabs/Player");

            SceneManager.LoadScene(lastScene, LoadSceneMode.Single);
            player = Instantiate(player);

            player.transform.position = new Vector3((float)data.PosX * .001f, (float)data.PosY * .001f, (float)data.PosZ * .001f);
            player.transform.eulerAngles = new Vector3((float)data.RotX * .001f, (float)data.RotY * .001f, (float)data.RotZ * .001f);
            player.GetComponent<PlayerScript>().MaxHealth = data.MaxHealth;
            player.GetComponent<PlayerScript>().Health = data.Health;

            player.GetComponent<PlayerScript>().Weapon = player.GetComponent<PlayerScript>().InitWeapon(Resources.Load<GameObject>("Prefabs/Gun"));
        }
    }
}

