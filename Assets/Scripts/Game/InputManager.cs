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
        RefreshCursorLockState();
    }

    public bool Moved()
    {
        return (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("Vertical") < -0.5f);  
    }

    public bool KeyCodeIsPressed(KeyCode Key)
    {
        return Input.GetKeyDown(Key);
    }

    public void SetCursorLock(bool value)
    {
        m_cursorIsLocked = value;
       
    }

    public void RefreshCursorLockState()
    {
        CursorLockMode wantedMode = Cursor.lockState;

        bool Visibility = Cursor.visible;

        if (m_cursorIsLocked)
        {
            wantedMode = CursorLockMode.Locked;
            Visibility = false;

        }
        else if (!m_cursorIsLocked)
        {
            wantedMode = CursorLockMode.None;
            Visibility = true;
        }

        Cursor.lockState = wantedMode;
        Cursor.visible = Visibility;
    }
}
