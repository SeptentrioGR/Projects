using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWidget : MonoBehaviour {


    public Canvas m_Canvas;


    public void Toggle()
    {
        bool isActive = m_Canvas.gameObject.activeSelf;
        m_Canvas.gameObject.SetActive(!isActive);
    }

}
