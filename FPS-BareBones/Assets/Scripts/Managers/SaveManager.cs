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

        save.WeaponName = GameManager.Instance.Player.GetComponent<PlayerScript>().Weapon.name;

        //save.WeaponName = GameManager.Instance.Player.GetComponent<PlayerScript>().Weapon.name;

        SavePlayerPos(save);
        SavePlayerRot(save);

        save.Score = GameManager.Instance.Score;
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
        save.PosX = (int)GameManager.Instance.Player.transform.position.x * 1000;
        save.PosY = (int)GameManager.Instance.Player.transform.position.y * 1000;
        save.PosZ = (int)GameManager.Instance.Player.transform.position.z * 1000;
    }
    public void SavePlayerRot(SaveData_FPS save)
    {
        save.RotX = (int)GameManager.Instance.Player.transform.eulerAngles.x * 1000;
        save.RotY = (int)GameManager.Instance.Player.transform.eulerAngles.y * 1000;
        save.RotZ = (int)GameManager.Instance.Player.transform.eulerAngles.z * 1000;
    }
    public void SavePlayerStats(SaveData_FPS save)
    {
        save.Health = (int)GameManager.Instance.Player.GetComponent<PlayerScript>().Health * 1000;
        save.MaxHealth = (int)GameManager.Instance.Player.GetComponent<PlayerScript>().MaxHealth * 1000;
    }
    public void SavePlayerScore(SaveData_FPS save)
    {
        save.Score = GameManager.Instance.Score;
    }
}
   

