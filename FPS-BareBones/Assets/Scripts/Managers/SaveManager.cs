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
        SavePlayerEquipment(save);
        SavePLayerWorldPosition(save);
        SavePlayerScore(save);
        SaveLastScene(save);

        return save;
    }
    public void WriteNewSaveData(string fileName)
    {
        string json = SaveGameData();
        string path = Path.Combine(Application.persistentDataPath, fileName);
        //if filename already exists, add timestamp
        if (Directory.Exists(path))
        {
            fileName = fileName + DateTime.Now.ToString("yyyy-MM-dd HH.mm.ss");
            path = Path.Combine(Application.persistentDataPath, fileName);
        }

        File.WriteAllText(path, json);
        Debug.Log(path);
        Debug.Log("Game Saved");
    }
    public string SaveGameData()
    {
        SaveData_FPS save = CreateSaveData();
        string json = JsonUtility.ToJson(save);

        return json;

    }
    public void OverwriteSaveData(string fileName)
    {
        string json = SaveGameData();

        File.WriteAllText(Application.persistentDataPath + fileName, json);
        Debug.Log(Application.persistentDataPath + fileName);
        Debug.Log("Game Saved");
    }

    public void SavePLayerWorldPosition(SaveData_FPS save)
    {
        SavePlayerPos(save);
        SavePlayerRot(save);
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
    public void SavePlayerEquipment(SaveData_FPS save)
    {
        save.WeaponName = GameManager.Instance.Player.GetComponent<PlayerScript>().Weapon.name;
    }
    public void SaveLastScene(SaveData_FPS save)
    {
        save.LastScene = SceneManager.GetActiveScene().name;
    }
}
   

