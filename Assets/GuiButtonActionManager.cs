using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZombieRun;

public enum ButtonAction
{
    Play, Exit, Back, Resume, Reset, WinToggle
}

public class GuiButtonActionManager{
    private static GuiButtonActionManager m_Instance;

    public static GuiButtonActionManager Instance
    {
        get
        {
            m_Instance = new GuiButtonActionManager();
            return m_Instance;
        }
    }


    ButtonAction m_ButtonAction;


    Dictionary<InputActionId, InputAction> m_InputActionsById = new Dictionary<InputActionId, InputAction>();



    public void AssingActionToButton(ButtonAction action, Button butt)
    {
        switch (action)
        {
            case ButtonAction.Back:
                butt.onClick.AddListener(Back);
                break;
            case ButtonAction.Exit:
                butt.onClick.AddListener(Exit);
                break;
            case ButtonAction.Play:
                butt.onClick.AddListener(Play);
                break;
            case ButtonAction.Resume:
                butt.onClick.AddListener(Resume);
                break;
            case ButtonAction.Reset:
                butt.onClick.AddListener(Reset);
                break;
            case ButtonAction.WinToggle:
                butt.onClick.AddListener(Resume);
                break;
        }
    }
    
  
    public void Resume()
    {
        GameManager.Instance.TogglePause();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.SetGameState(GameState.Game);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        GameManager.Instance.SetGameState(GameState.Menu);
        SceneManager.LoadScene(0);
    }

    public void Reset()
    {
        GameManager.Instance.ResetGame();
    }

    public bool PauseKeyIsPressed()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Pressed Key For Paused");
            return true;
        }
        return false;
    }

    public bool Moved()
    {
        return (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("Vertical") < -0.5f);
    }

    public bool KeyCodeIsPressed(KeyCode Key)
    {
        return Input.GetKeyDown(Key);
    }
}

    
