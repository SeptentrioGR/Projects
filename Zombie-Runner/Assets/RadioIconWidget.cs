﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioIconWidget : MonoBehaviour {

    private static RadioIconWidget m_instace;
    public static RadioIconWidget Instance
    {
        get
        {
            return m_instace;
        }
    }
    public Canvas m_Canvas;
    public Image m_Icon;

    private void Awake()
    {
        m_instace = this;
        Toggle();
    }

    public bool Enabled()
    {
        return enabled;
    }

    public void Toggle()
    {
        m_Canvas.enabled = !m_Canvas.enabled;
    }

    public void ChangeIconColor(Color color)
    {
        m_Icon.color = color;
    }
}
