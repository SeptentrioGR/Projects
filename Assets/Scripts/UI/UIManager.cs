using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ZombieRun;

public class UIManager : MonoBehaviour
{
    private static UIManager m_Instance;
    public static UIManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public Button m_PlayButton;
    public Button m_ResetButton;


    public void Awake()
    {
        m_Instance = this;
    }

    private void Start()
    {
        m_PlayButton.onClick.AddListener(OnClickMenu);
        m_ResetButton.onClick.AddListener(OnClickReset);
    }

    public void TogglePausePanel(bool value)
    {
        GameObject panel = PrefabManager.Instance.GetItemInList("PauseMenu");
        panel.SetActive(value);
    }

    public void ToggleWinPanel(bool value)
    {
        GameObject panel = PrefabManager.Instance.GetItemInList("WinMenu");
        panel.SetActive(value);
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickReset()
    {
        GameManager.Instance.ResetGame();
    }
}
