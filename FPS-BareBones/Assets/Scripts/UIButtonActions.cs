using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonActions : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.StartNewGame();
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
        GameManager.Instance.SaveGameData();
    }
    public void LoadGame()
    {
        GameManager.Instance.LoadGameData();

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
