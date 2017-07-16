using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRun;

public class InputManager {
	public static InputManager instance = new InputManager();

	public InputManager(){}

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.SetState(GameStates.Menu);
        }

    }

    public bool KeyIsPressed(KeyCode kc)
    {
        return Input.GetKeyDown(kc);
    }

    public void SetCursorLock(bool value)
    {
        m_cursorIsLocked = value;
        SetCursorLockState();
    }

    public void SetCursorLockState()
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

    public void CheckIsLocked(bool value)
    {
        m_cursorIsLocked = value;
    }

    public void ResetGame()
    {
        SetCursorLock(true);
    }


}
