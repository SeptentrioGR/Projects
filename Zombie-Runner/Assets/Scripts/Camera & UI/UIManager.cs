using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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




    public void Awake()
    {
        m_Instance = this;
    }

    public void TogglePausePanel(bool value)
    {
        GameObject panel = PrefabManager.Instance.GetItemInList("PauseMenu");
        bool IsActive = panel.activeSelf;
        panel.SetActive(value);
    }

    public void ToggleWinPanel(bool value)
    {
        GameObject panel = PrefabManager.Instance.GetItemInList("WinMenu");
        bool IsActive = panel.activeSelf;
        panel.SetActive(value);
    }
}
