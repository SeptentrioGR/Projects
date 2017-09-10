using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour {

    private static LoadingScreen m_Instance;
    public Canvas m_Canvas;

    //===========================================================================
    public void Enabled(bool value)
    {
        m_Canvas.enabled = value;
    }

    //===========================================================================
    public static LoadingScreen Instance
    {
        get
        {
            return m_Instance;
        }
    }

    //===========================================================================
    void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (m_Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }

    //===========================================================================
    void Start () {
		
	}

    //===========================================================================
    void Update () {
		
	}
}
