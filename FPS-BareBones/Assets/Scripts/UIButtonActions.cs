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
        SaveManager.Instance.WriteNewSaveData("savefile.json");
    }
    public void LoadGame()
    {
        GameManager.Instance.LoadFromSave("savefile.json");
        UIManager.Instance.CloseGameMenu();
        UIManager.Instance.ResumeGame();
        //TODO - make dynamic
        
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
        SceneManager.UnloadSceneAsync("TestScene");
        GameManager.Instance.StartNewGame();
        UIManager.Instance.HideGameOver();
    }
}
