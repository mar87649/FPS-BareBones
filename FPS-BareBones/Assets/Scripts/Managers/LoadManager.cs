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
        //load environment
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("TestScene");
        while (!asyncLoad.isDone)
        {
            Debug.Log("loading");

            yield return null;
        }
        //load weapons, npc, etc
        GameObject weapon = Instantiate(Resources.Load<GameObject>("Prefabs/Gun"), new Vector3(0,1,0), Quaternion.identity); //load a weapon
        weapon.name = Resources.Load<GameObject>("Prefabs/Gun").name;
        Debug.Log("loaded");
    }
    #endregion

    /*    public GameObject InitPlayer(GameObject playerPrefab)
        {
            GameObject player;

            if (GameObject.FindGameObjectWithTag("Player") == null)
            {
                player = Instantiate(playerPrefab, GameObject.Find("GameManager").transform);
                player.name = playerPrefab.name;
            }
            else
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            return player;
        }*/
    /*    public GameObject LoadNewPlayer(GameObject playerPrefab)
        {
            GameObject player = InitPlayer(playerPrefab);

            player.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0,0,0,0));
            return player;
        }*/
/*    public GameObject LoadSavedPlayer(SaveData_FPS save)
    {
        GameObject playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        GameObject player = InitPlayer(playerPrefab);

        player.transform.position = new Vector3(save.PosX * .001f, save.PosY * .001f, save.PosZ * .001f);
        player.transform.eulerAngles = new Vector3(save.RotX * .001f, save.RotY * .001f, save.RotZ * .001f);
        player.GetComponent<PlayerScript>().MaxHealth = save.MaxHealth * .001f;
        player.GetComponent<PlayerScript>().Health = save.Health * .001f;
        player.GetComponent<PlayerScript>().Weapon = LoadSaveWeapon(save.WeaponName);
        if (player.GetComponent<PlayerScript>().Weapon = null)
        {
            player.GetComponent<PlayerScript>().Weapon = player.GetComponent<PlayerScript>().DefaultWeapon;
        }
        return player;
    }*/
    public GameObject LoadNewPlayer()
    {
        GameObject player = GameManager.Instance.Player;

        player.SetActive(true);
        player.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        return player;
    }

    public GameObject LoadSavedPlayer(SaveData_FPS save)
    {
        GameManager.Instance.Player.SetActive(true);
        GameObject player = GameManager.Instance.Player;

        player.transform.position = new Vector3(save.PosX * .001f, save.PosY * .001f, save.PosZ * .001f);
        player.transform.eulerAngles = new Vector3(save.RotX * .001f, save.RotY * .001f, save.RotZ * .001f);
        player.GetComponent<PlayerScript>().MaxHealth = save.MaxHealth * .001f;
        player.GetComponent<PlayerScript>().Health = save.Health * .001f;
        player.GetComponent<PlayerScript>().Weapon = LoadSaveWeapon(save.WeaponName);
        if (player.GetComponent<PlayerScript>().Weapon = null)
        {
            player.GetComponent<PlayerScript>().Weapon = player.GetComponent<PlayerScript>().DefaultWeapon;
        }
        return player;
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
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Additive);
    }
}


