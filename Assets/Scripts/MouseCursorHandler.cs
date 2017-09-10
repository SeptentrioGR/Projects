using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorHandler : MonoBehaviour {

    private static MouseCursorHandler m_Instance;
    public static MouseCursorHandler Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public bool lockCursor = true;
    private bool m_cursorIsLocked = true;

    private void Awake()
    {
        m_Instance = this;
    }
	
	void Update () {
        RefreshCursorLockState();
    }

    public void ToggleMouseLock()
    {
        m_cursorIsLocked = !m_cursorIsLocked;
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
