using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour
{
    #region Singleton Pattern
    public static LoadManager Instance { get; private set; }
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

    public GameObject LoadPlayer(SaveData_FPS save)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        GameObject player = Instantiate(playerPrefab);
        player.name = playerPrefab.name;
        if (save == null)
        {            
            player.transform.SetPositionAndRotation(new Vector3(0,0,0), new Quaternion(0, 0, 0, 0));
            player.GetComponent<PlayerScript>().MaxHealth = playerPrefab.GetComponent<PlayerScript>().MaxHealth;
            player.GetComponent<PlayerScript>().Health = playerPrefab.GetComponent<PlayerScript>().Health;
            return player;
        }else
        {
            GameObject weapon = LoadSaveWeapon(save.WeaponName);
            player.GetComponent<PlayerScript>().InitWeapon(weapon);
           
            player.transform.position = new Vector3(save.PosX * .001f, save.PosY * .001f, save.PosZ * .001f);
            player.transform.eulerAngles = new Vector3(save.RotX * .001f, save.RotY * .001f, save.RotZ * .001f);
            player.GetComponent<PlayerScript>().MaxHealth = save.MaxHealth;
            player.GetComponent<PlayerScript>().Health = save.Health;

            return player;
        }
    }
    public GameObject LoadSaveWeapon(string weaponName)
    {
        if (weaponName == null)
        {
            return null;
        }
        else
        {
            GameObject weaponPrefab = Resources.Load<GameObject>("Prefabs/" + weaponName);
            GameObject weapon = Instantiate(weaponPrefab);
            weapon.name = weaponPrefab.name;
            return weapon;
        }
    }
    public int LoadScoreFromSave(SaveData_FPS save)
    {
        return save.Score;
    }
    #region Load scene and do after load
    IEnumerator DoAfterSceneLoad(string SceneName, List<Action> functionList)
    {
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneName);
        while (!asyncLoad.isDone)
        {
            Debug.Log("Game loading");

            yield return null;
        }
        Debug.Log("Game loaded");
        foreach (Action func in functionList)
        {
            func();
        }
    }
    public void LoadAsyncSceneThenDo(string SceneName, List<Action> functionList)
    {
        StartCoroutine(DoAfterSceneLoad(SceneName, functionList));
    }
    #endregion
    #region Load New Game
    public void LoadNewGame()
    {
        StartCoroutine(LoadNewGameEnum());
    }
    IEnumerator LoadNewGameEnum()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("TestScene");
        while (!asyncLoad.isDone)
        {
            Debug.Log("loading");

            yield return null;
        }
        Debug.Log("loaded");
        GameObject player = LoadPlayer(null);
        // TODO - maybe change to load empty weapon or dynamic
        GameObject weapon = Instantiate(Resources.Load<GameObject>("Prefabs/Gun"));
        weapon.name = Resources.Load<GameObject>("Prefabs/Gun").name;
        player.GetComponent<PlayerScript>().Weapon = player.GetComponent<PlayerScript>().InitWeapon(weapon);
        GameManager.Instance.Player = player;
        GameManager.Instance.InitLevel();
    }
    #endregion
}


