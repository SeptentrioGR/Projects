using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZombieRun;
using System.Reflection;
using System;

public class InputManager
{

    private static InputManager m_Instance;

    public static InputManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new InputManager();
                return m_Instance;
            }
            else
            {
                return m_Instance;
            }
        }
    }

    public bool KeyPressed(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            Debug.Log(key + " is pressed");
        }
        return Input.GetKeyDown(key);
    }

    private KeyCode PauseKeyCode = KeyCode.P;
    private KeyCode MapKeyCode = KeyCode.M;

    public void Update()
    {
        switch (GameManager.Instance.GetGameState())
        {
            case GameState.Menu:
                break;
            case GameState.Game:
                if (KeyPressed(PauseKeyCode))
                {
                    GameManager.Instance.TogglePause();
                }

                if (KeyPressed(MapKeyCode))
                {
                    MapWidget.Instance.Toggle();
                }

                //if (Moved())
                //{
                //    MapWidget.Instance.Enabled(false);
                //}
                break;
        }

    }

    //===========================================================================
    public bool Moved()
    {
        return (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("Vertical") < -0.5f);
    }

}
