using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    public static UIManager Instance { get; private set; }
    public GameObject PauseMenu { get => pauseMenu; private set => pauseMenu = value; }
    public GameObject OptionsMenu { get => optionsMenu; private set => optionsMenu = value; }

    private enum State { MainMenu, GameMenu, OptionsMenu, Inacttive }

    private State state;
    private State previousState;

    private void Awake()
    {
        Singleton();
        state = State.Inacttive;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void OpenGameMenu()
    {
        previousState = state;
        state = State.GameMenu;
        pauseMenu.SetActive(true);
    }
    public void CloseGameMenu()
    {
        previousState = State.Inacttive;
        state = State.Inacttive;
        pauseMenu.SetActive(false);
    }
    public void OpenOptions()
    {
        previousState = state;
        state = State.OptionsMenu;
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void CloseOptions()
    {
        previousState = state;
        state = previousState;
        OptionsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void Logic()
    {        
        if (state == State.Inacttive)
        {
            PauseGame();
            OpenGameMenu();
        }
        else if(state == State.GameMenu)
        {
            CloseOptions();
            CloseGameMenu();
            ResumeGame();
        }
        else if (state == State.OptionsMenu)
        {
            CloseOptions();
            OpenGameMenu();
        }
        Debug.Log(state);
    }
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
}
