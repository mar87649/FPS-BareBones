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

    public GameObject LoadPlayer(SaveData_FPS data)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        GameObject player = Instantiate(playerPrefab);
        if (data == null)
        {
            player.name = playerPrefab.name;
            player.transform.position = new Vector3(0,0,0);
            player.transform.rotation = new Quaternion(0, 0, 0, 0);
            player.GetComponent<PlayerScript>().MaxHealth = playerPrefab.GetComponent<PlayerScript>().MaxHealth;
            player.GetComponent<PlayerScript>().Health = playerPrefab.GetComponent<PlayerScript>().Health;
            return player;
        }else
        {
            GameObject weapon = LoadSaveWeapon(data.WeaponName);
            player.GetComponent<PlayerScript>().InitWeapon(weapon);

            player.name = playerPrefab.name;
            player.transform.position = new Vector3(data.PosX * .001f, data.PosY * .001f, data.PosZ * .001f);
            player.transform.eulerAngles = new Vector3(data.RotX * .001f, data.RotY * .001f, data.RotZ * .001f);
            player.GetComponent<PlayerScript>().MaxHealth = data.MaxHealth;
            player.GetComponent<PlayerScript>().Health = data.Health;

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

    }
}


