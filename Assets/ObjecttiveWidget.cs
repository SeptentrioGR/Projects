using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjecttiveWidget : MonoBehaviour {
    private static ObjecttiveWidget m_Instance;
    public static ObjecttiveWidget Instance
    {
        get
        {
            return m_Instance;
        }
    }
    public Text m_ObjectiveText;
    
	// Use this for initialization
	void Start () {
        m_Instance = this;

    }

    public void setObjective(string text)
    {
        m_ObjectiveText.text = string.Format("Objective:{0}",text);
    }
}
