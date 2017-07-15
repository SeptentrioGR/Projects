using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWidget : MonoBehaviour {
    private static BasicWidget m_Instance;

    public static BasicWidget Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public Canvas m_Canvas;

    private void Awake()
    {
        m_Instance = this;
    }

    public void Toggle()
    {
        bool isActive = m_Canvas.gameObject.activeSelf;
        m_Canvas.gameObject.SetActive(!isActive);
    }

}
