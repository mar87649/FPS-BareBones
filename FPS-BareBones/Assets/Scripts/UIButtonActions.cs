using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonActions : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }

    public void ExitApplication()
    {
        //Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void SaveGame()
    {
        Debug.Log("Games Saved");

    }
    public void LoadGame()
    {
        Debug.Log("Game Loaded");

    }
    public void Options()
    {
        UIManager.Instance.OpenOptions();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Restart()
    {
        //restart from last save
    }
}
