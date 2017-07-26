using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZombieRun;
using System.Reflection;

public enum ButtonAction
{
    Play, Exit, Back, Resume
}

public class GuiManager : MonoBehaviour
{
    private static GuiManager m_Instance;
    public static GuiManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AssingActionToButton(ButtonAction action,Button butt)
    {
        switch (action)
        {
            case ButtonAction.Back:
                butt.onClick.AddListener(Back);
                break;
            case ButtonAction.Exit:
                butt.onClick.AddListener(Exit);
                break;
            case ButtonAction.Play:
                butt.onClick.AddListener(Play);
                break;
            case ButtonAction.Resume:
                butt.onClick.AddListener(Resume);
                break;
        }

    }

    public void Resume()
    {
        GameManager.Instance.TogglePause();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
