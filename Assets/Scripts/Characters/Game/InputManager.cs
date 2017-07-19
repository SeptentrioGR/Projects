using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRun;

public class InputManager
{
    public static InputManager instance = new InputManager();

    public InputManager() { }

    public bool lockCursor = true;
    private bool m_cursorIsLocked = true;


    public static InputManager Instance
    {
        get
        {
            return instance;
        }
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

    public void Update()
    {


    }

    public void SetCursorLock(bool value)
    {
        m_cursorIsLocked = value;
        RefreshCursorLockState();
    }

    public void RefreshCursorLockState()
    {
        if (m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
        else if (!m_cursorIsLocked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
