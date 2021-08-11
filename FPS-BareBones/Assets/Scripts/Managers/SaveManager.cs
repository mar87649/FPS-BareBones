using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class SaveManager : MonoBehaviour
{
    #region Singleton Pattern
    public static SaveManager Instance { get; private set; }
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
    public SaveData_FPS CreateSaveData()
    {
        SaveData_FPS save = new SaveData_FPS();

        SavePlayerStats(save);

        save.WeaponName = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Weapon.name;

        SavePlayerPos(save);
        SavePlayerRot(save);

        save.LastScene = SceneManager.GetActiveScene().name;

        return save;
    }

    public void SaveGameData()
    {
        SaveData_FPS save = CreateSaveData();
        string json = JsonUtility.ToJson(save);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(Application.persistentDataPath + "/savefile.json");
        Debug.Log("Game Saved");
    }

    public void SavePlayerPos(SaveData_FPS save)
    {
        save.PosX = (int)GameObject.FindGameObjectWithTag("Player").transform.position.x * 1000;
        save.PosY = (int)GameObject.FindGameObjectWithTag("Player").transform.position.y * 1000;
        save.PosZ = (int)GameObject.FindGameObjectWithTag("Player").transform.position.z * 1000;
    }
    public void SavePlayerRot(SaveData_FPS save)
    {
        save.RotX = (int)GameObject.FindGameObjectWithTag("Player").transform.eulerAngles.x * 1000;
        save.RotY = (int)GameObject.FindGameObjectWithTag("Player").transform.eulerAngles.y * 1000;
        save.RotZ = (int)GameObject.FindGameObjectWithTag("Player").transform.eulerAngles.z * 1000;
    }
    public void SavePlayerStats(SaveData_FPS save)
    {
        save.Health = (int)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().Health * 1000;
        save.MaxHealth = (int)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().MaxHealth * 1000;
    }
}
   

