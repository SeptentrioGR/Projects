using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputActionId
{
    Pause, escape, Map
}

public class InputAction{

    public delegate void TriggerHandler();
    public event TriggerHandler Triggered = null;
    KeyCode[] m_KeyCode;
    InputActionId m_ActionId;

   
    public InputAction(InputActionId actionId,KeyCode[] keycodes)
    {
        m_ActionId = actionId;
        m_KeyCode = keycodes;
    }

    public KeyCode[] GetKeyCodes()
    {
        return m_KeyCode;
    }

    public InputActionId GetActionId()
    {
        return m_ActionId;
    }

    //----------------------------------------------------------------------------------------------------
    public void Subscribe(TriggerHandler handler)
    {
        Triggered += new TriggerHandler(handler);
    }
    //----------------------------------------------------------------------------------------------------
    public void Fire()
    {
        if (Triggered != null)
        {
            Triggered.Invoke();
        }
    }
}
