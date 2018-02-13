using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicWidget : MonoBehaviour {


    public GameObject m_Panel;


    public void Enabled(bool value)
    {
        m_Panel.gameObject.SetActive(value);
    }

    public void Toggle()
    {
        bool isActive = m_Panel.gameObject.activeSelf;
        m_Panel.gameObject.SetActive(!isActive);
    }

}
